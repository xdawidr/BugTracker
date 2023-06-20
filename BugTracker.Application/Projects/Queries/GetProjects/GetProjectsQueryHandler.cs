using AutoMapper;
using AutoMapper.QueryableExtensions;
using BugTracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Projects.Queries.GetProjects
{
    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, ProjectsVm>
    {
        private readonly IBugDbContext _context;
        private IMapper _mapper;

        public GetProjectsQueryHandler(IBugDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectsVm> Handle(GetProjectsQuery projectsQuery, CancellationToken none)
        {
            var projects = await _context.Projects.AsNoTracking().ProjectTo<ProjectDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new ProjectsVm() { Projects = projects};
        }
    }
}
