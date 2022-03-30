using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tasks.Persistence.EntityTypeConfiguration
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskD>
    {
        public void Configure(EntityTypeBuilder<TaskD> builder)
        {
            builder.HasKey(task => task.ID);
            builder.HasIndex(task => task.ID).IsUnique();
            builder.Property(task => task.NameTask).HasMaxLength(2);
        }
    }
}
