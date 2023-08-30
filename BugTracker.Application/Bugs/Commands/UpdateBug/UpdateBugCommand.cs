using MediatR;

namespace BugTracker.Application.Bugs.Commands.UpdateBug
{
    public class UpdateBugCommand : IRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Environment { get; set; }
    }
}
