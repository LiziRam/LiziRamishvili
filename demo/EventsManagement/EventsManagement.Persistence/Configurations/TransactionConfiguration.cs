using EventsManagement.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsManagement.Persistence.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");
            builder.Property(t => t.TransactionType).IsRequired().HasConversion<string>();
            builder.Property(t => t.TicketPrice)
                .IsRequired(); 
            builder.Property(t => t.CreatedAt).IsRequired().HasColumnType("Datetime");
            builder.Property(t => t.ModifiedAt).IsRequired().HasColumnType("Datetime");
            builder.Property(t => t.IsDeleted).HasDefaultValue(false);
        }
    }
}
