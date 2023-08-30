using BugTracker.Domain.Common;

namespace BugTracker.Domain.Entity
{
    public class Comment : AuditableEntity
    {
        public string Value { get; set; }
        public byte[]? Image { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}