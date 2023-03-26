using EventsManagement.Domain.Transactions;

namespace EventsManagement.Application.Transactions.Responses
{
    public class TransactionResponseModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public TransactionType TransactionType { get; set; }
        public double TicketPrice { get; set; }
    }
}
