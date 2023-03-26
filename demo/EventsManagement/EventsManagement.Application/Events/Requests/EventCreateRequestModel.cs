namespace EventsManagement.Application.Events.Requests
{
    public class EventCreateRequestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Location { get; set; }
        public int Tickets { get; set; }
        public double TicketPrice { get; set; }
    }
}
