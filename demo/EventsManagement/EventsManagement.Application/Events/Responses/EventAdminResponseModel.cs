namespace EventsManagement.Application.Events.Responses
{
    public class EventAdminResponseModel
    {
        public int Id { get; set; }
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
    }
}
