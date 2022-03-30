using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tasks.Application.Interfaces;

namespace Tasks.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<TasksDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<ITasksDbContext>(provider =>
                provider.GetService<TasksDbContext>());
            return services;
        }
    }
}
