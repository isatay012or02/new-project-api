using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Tasks.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks.Application.Interfaces
{
    public interface ITasksDbContext
    {
        DbSet<TaskD> STasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
