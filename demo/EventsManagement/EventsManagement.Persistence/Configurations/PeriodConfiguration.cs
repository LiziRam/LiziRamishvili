using EventsManagement.Domain.Periods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsManagement.Persistence.Configurations
{
    public class PeriodConfiguration : IEntityTypeConfiguration<Period>
    {
        public void Configure(EntityTypeBuilder<Period> builder)
        {
            builder.ToTable("Periods");
            builder.Property(p => p.BookingPeriod).IsRequired();
            builder.Property(p => p.EditPeriod).IsRequired();
        }
    }
}
