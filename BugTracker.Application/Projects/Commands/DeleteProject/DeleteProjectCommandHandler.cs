using BugTracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IBugDbContext _dbContext;

        public DeleteProjectCommandHandler(IBugDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task IRequestHandler<DeleteProjectCommand>.Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.Where(p => p.Id == request.ProjectId).FirstOrDefaultAsync(cancellationToken);
            _dbContext.Projects.Remove(project);

            await _dbContext.SaveChangesAsync(cancellationToken);

            //return Unit.Value;
        }
    }
}
