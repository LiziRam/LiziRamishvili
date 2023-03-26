namespace EventsManagement.Domain.Periods
{
    public class Period
    {
        public Period()
        {
            EditPeriod = 3;
            BookingPeriod = 3;
        }

        public int Id { get; set; }
        public int EditPeriod { get; set; }
        public int BookingPeriod { get; set; }
    }
}
