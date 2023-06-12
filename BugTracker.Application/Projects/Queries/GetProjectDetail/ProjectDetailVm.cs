using AutoMapper;
using AutoMapper.Execution;
using BugTracker.Application.Common.Mappings;
using BugTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Projects.Queries.GetProjectDetail
{
    public class ProjectDetailVm : IMapFrom<Project>
    {
        public string Name { get; set; }
        public string BugName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectDetailVm>()
                .ForMember(p => p.BugName, map => map.MapFrom<BugNameResolver>());
                
        }

        public class BugNameResolver : IValueResolver<Project, object, string>
        {
            public string Resolve(Project source, object destination, string destMember, ResolutionContext context)
            {
                if (source.Bugs is not null && source.Bugs.Any())
                {
                    var lastBug = source.Bugs.OrderByDescending(p => p.CreatedAt).FirstOrDefault();

                    return lastBug.Name;
                }

                return string.Empty;
            }
        }
    }
}
