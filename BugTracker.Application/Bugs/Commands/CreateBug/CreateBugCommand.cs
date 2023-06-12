using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Bugs.Commands.CreateBug
{
    public class CreateBugCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Environment { get; set; }
    }
}
