namespace EventsManagement.Application.Events.Responses
{
    public class EventAdmittedResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Location { get; set; }
        public double TicketPrice { get; set; }
    }
}
