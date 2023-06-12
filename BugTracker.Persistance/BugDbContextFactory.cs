using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Persistance
{
    public class BugDbContextFactory : DesignTimeDbContextFactoryBase<BugDbContext>
    {
        protected override BugDbContext CreateNewInstance(DbContextOptions<BugDbContext> options)
        {
            return new BugDbContext(options);
        }
    }
}
