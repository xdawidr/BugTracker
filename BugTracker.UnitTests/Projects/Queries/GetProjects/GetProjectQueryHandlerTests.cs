using AutoMapper;
using BugTracker.Application.Projects.Queries.GetProjects;
using BugTracker.Persistance;
using BugTracker.UnitTests.Common;
using Shouldly;

namespace BugTracker.UnitTests.Projects.Queries.GetProjects
{
    public class GetProjectQueryHandlerTests
    {
        [Collection("QueryCollection")]
        public class GetProjectDetailQueryHandlerTests
        {
            private readonly BugDbContext _context;
            private readonly IMapper _mapper;

            public GetProjectDetailQueryHandlerTests(QueryTextFixtures fixtures)
            {
                _context = fixtures.Context;
                _mapper = fixtures.Mapper;
            }

            [Fact]
            public async Task CanGetProjects()
            {
                var handler = new GetProjectsQueryHandler(_context, _mapper);
                var result = await handler.Handle(new GetProjectsQuery(), CancellationToken.None);

                result.ShouldBeOfType<ProjectsVm>();
                result.Projects.Count.ShouldBe(2);
            }
        }
    }
}
