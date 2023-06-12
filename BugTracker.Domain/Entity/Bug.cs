using BugTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Entity
{
    public class Bug : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Environment { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
