using BugTracker.Application.Common.Interfaces;
using BugTracker.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Application.Bugs.Commands.UpdateBug
{
    public class UpdateBugCommandHandler : IRequestHandler<UpdateBugCommand>
    {
        private readonly IBugDbContext _bugDbContext;

        public UpdateBugCommandHandler(IBugDbContext bugDbContext)
        {
            _bugDbContext = bugDbContext;
        }

        async Task IRequestHandler<UpdateBugCommand>.Handle(UpdateBugCommand request, CancellationToken cancellationToken)
        {
            Bug bug = new()
            {
                Name = request.Name,
                Description = request.Description,
                Environment = request.Environment

            };
            
            _bugDbContext.Bugs.Update(bug);
            await _bugDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
