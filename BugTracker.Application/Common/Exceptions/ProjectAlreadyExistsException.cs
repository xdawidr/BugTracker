using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Common.Exceptions
{
    public class ProjectAlreadyExistsException : Exception
    {
        public ProjectAlreadyExistsException(string project, int id, Exception ex) : base($"Project {project} already exists for id: {id}", ex)
        {
            
        }
    }
}
