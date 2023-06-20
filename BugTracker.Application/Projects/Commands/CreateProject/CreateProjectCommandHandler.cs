using BugTracker.Application.Common.Interfaces;
using BugTracker.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BugTracker.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IBugDbContext _bugDbContext;

        public CreateProjectCommandHandler(IBugDbContext bugDbContext)
        {
            _bugDbContext = bugDbContext;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = new ()
            {
                Name = request.Name,
                Description = request.Description,
            };

            _bugDbContext.Projects.Add(project);

            await _bugDbContext.SaveChangesAsync(cancellationToken);

            return project.Id;
        }
    }
}
