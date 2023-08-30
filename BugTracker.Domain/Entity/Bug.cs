using BugTracker.Domain.Common;

namespace BugTracker.Domain.Entity
{
    public class Bug : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Environment { get; set; }
        public byte[]? Image { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
