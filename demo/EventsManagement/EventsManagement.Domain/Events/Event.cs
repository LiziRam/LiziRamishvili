using EventsManagement.Domain.Base;
using EventsManagement.Domain.Transactions;
using EventsManagement.Domain.Users;

namespace EventsManagement.Domain.Events
{
    public class Event : BaseEntity
    {
        public Event()
        {
            CreatedAt = DateTime.UtcNow;
            ModifiedAt = DateTime.UtcNow;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Location { get; set; }
        public int Tickets { get; set; }
        public double TicketPrice { get; set; }

        public bool IsAdmitted { get; set; }

        public bool IsArchived { get; set; }
        public int TicketsAvailable { get; set; }

        public int UserId { get; set; }

        //Nav Prop
        public User User { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
