using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Projects.Queries.GetProjects
{
    public class ProjectsVm
    {
        public ICollection<ProjectDto> Projects { get; set; }
    }
}
