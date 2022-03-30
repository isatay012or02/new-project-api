using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tasks.Application.Interfaces;
using Tasks.Application.Common.Exceptions;
using Tasks.Domain;

namespace Tasks.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler
    {
        private readonly ITasksDbContext _dbContext;

        public DeleteTaskCommandHandler(ITasksDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteTaskCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.STasks
                .FindAsync(new object[] { request.ID }, cancellationToken);

            if (entity == null || entity.UserID != request.UserID)
            {
                throw new NotFoundException(nameof(TaskD), request.ID);
            }

            _dbContext.STasks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
