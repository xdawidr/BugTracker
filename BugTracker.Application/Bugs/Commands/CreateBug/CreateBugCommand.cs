using MediatR;

namespace BugTracker.Application.Bugs.Commands.CreateBug
{
    public class CreateBugCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Environment { get; set; }
    }
}
