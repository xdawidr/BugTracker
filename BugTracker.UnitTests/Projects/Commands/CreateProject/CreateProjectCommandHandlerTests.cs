using BugTracker.Application.Projects.Commands.CreateProject;
using BugTracker.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.UnitTests.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandlerTests : CommonTestBase
    {
        private readonly CreateProjectCommandHandler _handler;

        public CreateProjectCommandHandlerTests() : base()
        {
            _handler = new CreateProjectCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertProject()
        {
            var command = new CreateProjectCommand()
            {
                Description = "description",
                Name = "name",
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var project = await _context.Projects.FirstAsync(x => x.Id == result, CancellationToken.None);

            project.ShouldNotBeNull();
        }
    }
}
