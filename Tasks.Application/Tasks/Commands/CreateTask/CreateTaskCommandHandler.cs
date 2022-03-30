using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Tasks.Application.Interfaces;
using Tasks.Domain;
using System.Threading;

namespace Tasks.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly ITasksDbContext _dbContext;

        public CreateTaskCommandHandler(ITasksDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskD
            {
                UserID = request.UserID,
                ID = Guid.NewGuid(),
                NameTask = request.NameTask,
                DiscriptionTask = request.DiscriptionTask
            };

            await _dbContext.STasks.AddAsync(task, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return task.ID;
        }
    }
}
