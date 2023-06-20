using BugTracker.Application.Common.Interfaces;
using BugTracker.Domain.Entity;
using BugTracker.Persistance;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BugTracker.UnitTests.Common
{
    public static class BugDbContextFactory
    {
        public static Mock<BugDbContext> Create()
        {
            var dateTime = new DateTime(2000, 1, 1);
            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now).Returns(dateTime);

            var currentUserMock = new Mock<ICurrentUserService>();
            currentUserMock.Setup(m => m.Email).Returns("user@user.pl");
            currentUserMock.Setup(m => m.IsAuthenticated).Returns(true);

            var options = new DbContextOptionsBuilder<BugDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;


            var mock = new Mock<BugDbContext>(options, dateTimeMock.Object, currentUserMock.Object)
            {
                CallBase = true
            };

            var context = mock.Object;

            context.Database.EnsureCreated();
            
            var bug = new Bug() { ProjectId = 2, Name = "Bug2", Description = "Another stupid bug", Environment = "PROD"};
            context.Bugs.Add(bug);

            var project = new Project() { Id = 2, Name = "Second project", Description = "Another business project" };
            context.Projects.Add(project);

            context.SaveChanges();

            return mock;
        }

        public static void Destroy(BugDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
