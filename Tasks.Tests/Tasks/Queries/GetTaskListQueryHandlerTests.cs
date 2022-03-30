using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Tasks.Application.Tasks.Queries.GetTaskList;
using Tasks.Persistence;
using Tasks.Tests.Common;
using Shouldly;
using Xunit;

namespace Tasks.Tests.Tasks.Queries
{
    [Collection("QueryCollection")]
    public class GetTaskListQueryHandlerTests
    {
        private readonly TasksDbContext Context;
        private readonly IMapper Mapper;

        public GetTaskListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetTaskListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetTaskListQuery
                {
                    UserID = TaskContextFactory.UserBId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<TaskListVm>();
            result.Tasks.Count.ShouldBe(2);
        }
    }
}
