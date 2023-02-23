using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Todos;

namespace Todo.Persistence.Configurations
{
    public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.ToTable("TodoInfo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Status).IsRequired().HasConversion<string>();
            builder.Property(x => x.TargetCompletionDate).HasColumnType("Datetime");
            builder.Property(x => x.CreatedAt).IsRequired().HasColumnType("Datetime");
            builder.Property(x => x.ModifiedAt).IsRequired().HasColumnType("Datetime");

            builder.HasMany(x => x.Subtasks).WithOne(y => y.ToDo); 
        }
    }
}

