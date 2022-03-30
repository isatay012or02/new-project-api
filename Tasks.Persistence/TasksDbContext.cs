using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Tasks.Application.Interfaces;
using Tasks.Domain;
using Tasks.Persistence.EntityTypeConfiguration;

namespace Tasks.Persistence
{
    public class TasksDbContext : DbContext, ITasksDbContext
    {
        public DbSet<TaskD> STasks { get; set; }

        public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TaskConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
