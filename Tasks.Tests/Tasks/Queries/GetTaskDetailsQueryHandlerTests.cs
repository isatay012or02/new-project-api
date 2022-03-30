using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tasks.Application.Tasks.Queries.GetTaskDetails;
using Tasks.Persistence;
using Tasks.Tests.Common;
using Shouldly;
using Xunit;

namespace Tasks.Tests.Tasks.Queries
{
    [Collection("QueryCollection")]
    public class GetTaskDetailsQueryHandlerTests
    {
        private readonly TasksDbContext Context;
        private readonly IMapper Mapper;

        public GetTaskDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetTaskDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetTaskDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetTaskDetailsQuery
                {
                    UserID = TaskContextFactory.UserBId,
                    ID = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<GetTaskVm>();
            result.NameTask.ShouldBe("Title2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
