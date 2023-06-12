using AutoMapper;
using BugTracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BugTracker.Application.Projects.Queries.GetProjectDetail
{
    public class GetProjectDetailQueryHandler : IRequestHandler<GetProjectDetailQuery, ProjectDetailVm>
    {
        private readonly IBugDbContext _bugDbContext;
        private IMapper _mapper;
        private readonly ICurrentUserService currentUserService;


        public GetProjectDetailQueryHandler(IBugDbContext bugDbContext, IMapper mapper, ICurrentUserService currentUserService)
        {
            _bugDbContext = bugDbContext;
            _mapper = mapper;
            this.currentUserService = currentUserService;
        }

        public async Task<ProjectDetailVm> Handle(GetProjectDetailQuery request, CancellationToken cancellationToken)
        {
            var project = await _bugDbContext.Projects.Include(p => p.Bugs).Where(p => p.Id == request.ProjectId).FirstOrDefaultAsync(cancellationToken);

            var projectVm = _mapper.Map<ProjectDetailVm>(project);

            return projectVm;
        }
    }
}
