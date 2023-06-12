using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Bugs.Queries.GetBugDetail
{
    public class GetBugDetailQuery : IRequest<BugDetailVm>
    {
        public int BugId { get; set; }
    }
}
