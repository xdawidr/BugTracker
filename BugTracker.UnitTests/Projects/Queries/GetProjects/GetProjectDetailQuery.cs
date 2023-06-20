using AutoMapper;
using BugTracker.Application.Projects.Queries.GetProjectDetail;
using BugTracker.Persistance;
using BugTracker.UnitTests.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.UnitTests.Projects.Queries.GetProjects
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
        public async Task CanGetProjectDetailById()
        {
            var handler = new GetProjectDetailQueryHandler(_context, _mapper);
            var projectId = 2;

            var result = await handler.Handle(new GetProjectDetailQuery { ProjectId = projectId }, CancellationToken.None);

            result.ShouldBeOfType<ProjectDetailVm>();
            result.Name.ShouldBe("Second project");
        }
    }
}
