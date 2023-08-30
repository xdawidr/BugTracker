using BugTracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Application.Bugs.Commands.DeleteBug
{
    public class DeleteBugCommandHandler : IRequestHandler<DeleteBugCommand>
    {
        private readonly IBugDbContext _dbContext;

        public DeleteBugCommandHandler(IBugDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteBugCommand request, CancellationToken cancellationToken)
        {
            var bug = await _dbContext.Bugs.Where(p => p.Id == request.BugId).FirstOrDefaultAsync(cancellationToken);
            _dbContext.Bugs.Remove(bug);

            await _dbContext.SaveChangesAsync(cancellationToken);   
        }
    }
}
