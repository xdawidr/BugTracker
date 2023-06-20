using BugTracker.Domain.Entity;
using BugTracker.Persistance;

namespace BugTracker.IntegrationTests.Common
{
    public class Utilities
    {
        public static void InitilizeDbForTests(BugDbContext context)
        {
            var bug = new Bug() { ProjectId = 2, Name = "Bug2", Description = "Another stupid bug", Environment = "PROD" };
            context.Bugs.Add(bug);

            var project = new Project() { Id = 2, Name = "Second project", Description = "Another business project" };
            context.Projects.Add(project);

            context.SaveChanges();

        }
    }
}
