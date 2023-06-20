using AutoMapper;
using BugTracker.Application.Common.Mappings;
using BugTracker.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.UnitTests.Common
{
    public class QueryTextFixtures : IDisposable
    {
        public BugDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTextFixtures()
        {
            Context = BugDbContextFactory.Create().Object;

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }
        public void Dispose()
        {
            BugDbContextFactory.Destroy(Context);
        }

        [CollectionDefinition("QueryCollection")]
        public class QueryCollection : ICollectionFixture<QueryTextFixtures> { }
    }
}
