using EventsManagement.Domain.Base;
using EventsManagement.Domain.Events;
using EventsManagement.Domain.Users;

namespace EventsManagement.Domain.Transactions
{
    public class Transaction : BaseEntity
    {
        public Transaction()
        {
            CreatedAt = DateTime.UtcNow;
            ModifiedAt = DateTime.UtcNow;
        }

        public TransactionType TransactionType { get; set; }
        public double TicketPrice { get; set; }

        public int UserId { get; set; }
        public int EventId { get; set; }

        //Nav Prop
        public User User { get; set; }
        public Event Event { get; set; }
    }
}
