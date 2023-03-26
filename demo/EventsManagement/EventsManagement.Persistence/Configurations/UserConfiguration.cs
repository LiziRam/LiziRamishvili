using EventsManagement.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsManagement.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasIndex(u => u.UserName).IsUnique();
            builder.Property(u => u.UserName).IsUnicode(false).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsUnicode(false).IsRequired().HasMaxLength(50);
            builder.Property(u => u.FirstName).IsUnicode(false).HasMaxLength(50);
            builder.Property(u => u.LastName).IsUnicode(false).HasMaxLength(50);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.IsDeleted).HasDefaultValue(false);
            builder.Property(u => u.CreatedAt).IsRequired().HasColumnType("Datetime");
            builder.Property(u => u.ModifiedAt).IsRequired().HasColumnType("Datetime");

            builder.HasMany(u => u.Events).WithOne(e => e.User).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.Transactions).WithOne(t => t.User).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
