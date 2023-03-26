using EventsManagement.Domain.Periods;

namespace EventsManagement.Application.Periods.Repositories
{
    public interface IPeriodRepository
    {
        Task CreatePeriodAsync(CancellationToken cancellationToken, Period initialCreate);
        Task<int> GetBookingPeriodAsync(CancellationToken cancellationToken);
        Task<int> GetEditPeriodAsync(CancellationToken cancellationToken);
        Task<Period> GetPeriodsAsync(CancellationToken cancellationToken);
        Task UpdatePeriodAsync(CancellationToken cancellationToken, Period periodToUpdate);
    }
}
