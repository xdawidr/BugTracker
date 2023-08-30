using BugTracker.Domain.Common;

namespace BugTracker.Domain.Entity
{
    public class Project : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Bug> Bugs { get; set; }
    }
}
