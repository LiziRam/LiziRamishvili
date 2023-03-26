namespace EventsManagement.Application.Periods
{
    public interface IPeriodService
    {
        Task<int> GetEditDaysAsync(CancellationToken cancellationToken);
        Task<int> GetBookingDaysAsync(CancellationToken cancellationToken);
        Task UpdateEditDaysAsync(CancellationToken cancellationToken, int newDays);
        Task UpdateBookingDaysAsync(CancellationToken cancellationToken, int newDays);
    }
}
