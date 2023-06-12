using AutoMapper;
using BugTracker.Application.Common.Interfaces;
using BugTracker.Application.Projects.Queries.GetProjectDetail;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BugTracker.Application.Bugs.Queries.GetBugDetail
{
    public class GetBugDetailQueryHandler : IRequestHandler<GetBugDetailQuery, BugDetailVm>
    {
        public readonly IBugDbContext _bugDbContext;
        private IMapper _mapper;

        public GetBugDetailQueryHandler(IBugDbContext bugDbContext, IMapper mapper)
        {
            _bugDbContext = bugDbContext;
            _mapper = mapper;
        }

        public async Task<BugDetailVm> Handle(GetBugDetailQuery request, CancellationToken cancellationToken)
        {
            var bug = await _bugDbContext.Bugs.Where(p => p.Id == request.BugId).FirstOrDefaultAsync(cancellationToken);

            var bugVm = _mapper.Map<BugDetailVm>(bug);

            return bugVm;
        }
    }
}
