using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tasks.Application.Common.Exceptions;
using Tasks.Application.Tasks.Commands.DeleteTask;
using Tasks.Application.Tasks.Commands.CreateTask;
using Tasks.Tests.Common;
using Xunit;

namespace Tasks.Tests.Tasks.Commands
{
    public class DeleteTaskCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteTaskCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteTaskCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteTaskCommand
            {
                ID = TaskContextFactory.TaskIdForDelete,
                UserID = TaskContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.STasks.SingleOrDefault(note =>
                note.ID == TaskContextFactory.TaskIdForDelete));
        }

        [Fact]
        public async Task DeleteTaskCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteTaskCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteTaskCommand
                    {
                        ID = Guid.NewGuid(),
                        UserID = TaskContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteTaskCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteTaskCommandHandler(Context);
            var createHandler = new CreateTaskCommandHandler(Context);
            var noteId = await createHandler.Handle(
                new CreateTaskCommand
                {
                    NameTask = "NoteTitle",
                    UserID = TaskContextFactory.UserAId
                }, CancellationToken.None);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteTaskCommand
                    {
                        ID = noteId,
                        UserID = TaskContextFactory.UserBId
                    }, CancellationToken.None));
        }
    }
}
