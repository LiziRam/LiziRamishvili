using EventsManagement.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsManagement.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");
            builder.HasIndex(u => u.Title).IsUnique();

            builder.Property(e => e.Title).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Description).HasMaxLength(300);
            builder.Property(e => e.StartDateTime).IsRequired().HasColumnType("Datetime");
            builder.Property(e => e.EndDateTime).IsRequired().HasColumnType("Datetime");
            builder.Property(e => e.Location).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Tickets).IsRequired();
            builder.Property(e => e.TicketPrice).IsRequired();
            builder.Property(e => e.IsAdmitted).HasDefaultValue(false);
            builder.Property(e => e.CreatedAt).IsRequired().HasColumnType("Datetime");
            builder.Property(e => e.ModifiedAt).IsRequired().HasColumnType("Datetime");
            builder.Property(e => e.IsDeleted).HasDefaultValue(false);

            builder.HasMany(e => e.Transactions).WithOne(t => t.Event).OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
