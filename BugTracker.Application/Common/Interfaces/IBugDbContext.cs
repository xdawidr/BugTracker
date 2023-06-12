using BugTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BugTracker.Application.Common.Interfaces
{
    public interface IBugDbContext
    {
        DbSet<Bug> Bugs { get; set; }
        DbSet<Project> Projects { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
