using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasks.Application.Tasks.Commands.CreateTask;
using Tasks.Tests.Common;
using Xunit;

namespace Tasks.Tests.Common
{
    public class CreateTaskCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateTaskCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateTaskCommandHandler(Context);
            var taskName = "note name";
            var taskDisription = "note details";

            // Act
            var taskId = await handler.Handle(
                new CreateTaskCommand
                {
                    NameTask = taskName,
                    DiscriptionTask = taskDisription,
                    UserID = TaskContextFactory.UserAId
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.STasks.SingleOrDefaultAsync(task =>
                    task.ID == taskId && task.NameTask == taskName &&
                    task.DiscriptionTask == taskDisription));
        }
    }
}
