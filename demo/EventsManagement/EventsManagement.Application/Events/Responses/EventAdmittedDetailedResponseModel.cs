namespace EventsManagement.Application.Events.Responses
{
    public class EventAdmittedDetailedResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Location { get; set; }
        public int Tickets { get; set; }
        public double TicketPrice { get; set; }
    }
}
