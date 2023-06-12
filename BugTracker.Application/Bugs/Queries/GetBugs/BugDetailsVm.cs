using BugTracker.Application.Projects.Queries.GetProjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Bugs.Queries.GetBugs
{
    public class BugDetailsVm
    {
        ICollection<BugDto> Bugs { get; set; }
    }
}
