using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Subtasks;
using Todo.Domain.Todos;

namespace Todo.Persistence.Configurations
{
	public class SubtaskConfiguration : IEntityTypeConfiguration<Subtask>
    {
        public void Configure(EntityTypeBuilder<Subtask> builder)
        {
            builder.ToTable("SubtaskInfo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedAt).IsRequired().HasColumnType("Datetime"); 
            builder.Property(x => x.ModifiedAt).IsRequired().HasColumnType("Datetime");
        }
    }
}

