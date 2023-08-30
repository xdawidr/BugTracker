using BugTracker.Application.Common.Interfaces;
using BugTracker.Domain.Entity;
using MediatR;

namespace BugTracker.Application.Bugs.Commands.CreateBug
{
    public class CreateBugCommandHandler : IRequestHandler<CreateBugCommand, int>
    {
        private readonly IBugDbContext _bugDbContext;

        public CreateBugCommandHandler(IBugDbContext bugDbContext)
        {
            _bugDbContext = bugDbContext;
        }

        public async Task<int> Handle(CreateBugCommand request, CancellationToken cancellationToken)
        {
            Bug bug = new()
            {
                Name = request.Name,
                Description = request.Description,
                Environment = request.Environment

            };

            _bugDbContext.Bugs.Add(bug);

            await _bugDbContext.SaveChangesAsync(cancellationToken);

            return bug.Id;
        }
    }
}
