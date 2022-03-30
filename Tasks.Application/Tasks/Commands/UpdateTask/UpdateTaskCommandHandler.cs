using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Tasks.Application.Interfaces;
using Tasks.Application.Common.Exceptions;
using Tasks.Domain;

namespace Tasks.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly ITasksDbContext _dbContext;

        public UpdateTaskCommandHandler(ITasksDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.STasks.FirstOrDefaultAsync(task => task.ID == request.ID, cancellationToken);
            if (entity == null || entity.UserID != request.ID)
            {
                throw new NotFoundException(nameof(TaskD), request.ID);
            }

            entity.ID = request.ID;
            entity.NameTask = request.NameTask;
            entity.DiscriptionTask = request.DiscriptionTask;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
