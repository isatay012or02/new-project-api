using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasks.Application.Common.Exceptions;
using Tasks.Application.Tasks.Commands.UpdateTask;
using Tasks.Tests.Common;
using Xunit;

namespace Tasks.Tests.Tasks.Commands
{
    public class UpdateTaskCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateTaskCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateTaskCommandHandler(Context);
            var updatedName = "new Name";

            // Act
            await handler.Handle(new UpdateTaskCommand
            {
                ID = TaskContextFactory.TaskIdForUpdate,
                UserID = TaskContextFactory.UserBId,
                NameTask = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.STasks.SingleOrDefaultAsync(task =>
                task.ID == TaskContextFactory.TaskIdForUpdate &&
                task.NameTask == updatedName));
        }

        [Fact]
        public async Task UpdateTaskCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateTaskCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateTaskCommand
                    {
                        ID = Guid.NewGuid(),
                        UserID = TaskContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateTaskCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateTaskCommand
                    {
                        ID = TaskContextFactory.TaskIdForUpdate,
                        UserID = TaskContextFactory.UserAId
                    },
                    CancellationToken.None);
            });
        }
    }
}
