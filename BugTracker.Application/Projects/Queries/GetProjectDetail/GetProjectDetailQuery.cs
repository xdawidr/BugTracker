using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Projects.Queries.GetProjectDetail
{
    public class GetProjectDetailQuery : IRequest<ProjectDetailVm>
    {
        public int ProjectId { get; set; }
    }
}
