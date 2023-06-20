using BugTracker.Application.Common.Interfaces;
using BugTracker.Persistance;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.UnitTests.Common
{
    public class CommonTestBase : IDisposable
    {
        protected readonly BugDbContext _context;
        protected readonly Mock<BugDbContext> _mock;

        public CommonTestBase()
        {
            
            _mock = BugDbContextFactory.Create();
            _context = _mock.Object;
        }

        public void Dispose()
        {
            BugDbContextFactory.Destroy(_context);
        }
    }
}
