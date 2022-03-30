using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tasks.Application.Interfaces;

namespace Tasks.Application.Tasks.Queries.GetTaskList
{
    public class GetTaskListQueryHandler
    {
        private readonly ITasksDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskListQueryHandler(ITasksDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TaskListVm> Handle(GetTaskListQuery request,
            CancellationToken cancellationToken)
        {
            var notesQuery = await _dbContext.STasks
                .Where(task => task.UserID == request.UserID)
                .ProjectTo<TaskLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TaskListVm { Tasks = notesQuery };
        }
    }
}
