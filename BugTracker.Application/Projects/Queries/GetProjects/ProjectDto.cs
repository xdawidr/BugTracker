using AutoMapper;
using BugTracker.Application.Common.Mappings;
using BugTracker.Application.Projects.Queries.GetProjectDetail;
using BugTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Projects.Queries.GetProjects
{
    public class ProjectDto : IMapFrom<Project>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectDto>();
        }
    }
}
