using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Users;

namespace Todo.Persistence.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("UserInfo");
            builder.HasIndex(x => x.Username).IsUnique();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).IsUnicode(false).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired().HasColumnType("Datetime"); 
            builder.Property(x => x.ModifiedAt).IsRequired().HasColumnType("Datetime");

            builder.HasMany(x => x.ToDos).WithOne(y => y.User); 
        }
    }
}

