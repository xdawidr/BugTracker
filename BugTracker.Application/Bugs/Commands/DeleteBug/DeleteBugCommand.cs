using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Bugs.Commands.DeleteBug
{
    public class DeleteBugCommand : IRequest
    {
        public int BugId { get; set; }
    }
}
