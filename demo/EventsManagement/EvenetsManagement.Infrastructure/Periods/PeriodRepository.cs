using EventsManagement.Application.Periods.Repositories;
using EventsManagement.Domain.Periods;
using EventsManagement.Persistence.Context;

namespace EvenetsManagement.Infrastructure.Periods
{
    public class PeriodRepository : BaseRepository<Period>, IPeriodRepository
    {
        public PeriodRepository(EventsManagementContext context) : base(context)
        {
        }

        public async Task CreatePeriodAsync(CancellationToken cancellationToken, Period initialCreate) =>
            await AddAsync(cancellationToken, initialCreate).ConfigureAwait(false);

        public async Task<int> GetBookingPeriodAsync(CancellationToken cancellationToken)
        {
            var period = await GetAsync(cancellationToken, 1).ConfigureAwait(false);
            return period.BookingPeriod;
        }

        public async Task<int> GetEditPeriodAsync(CancellationToken cancellationToken)
        {
            var period = await GetAsync(cancellationToken, 1).ConfigureAwait(false);
            return period.EditPeriod;
        }

        public async Task<Period> GetPeriodsAsync(CancellationToken cancellationToken) =>
            await GetAsync(cancellationToken, 1).ConfigureAwait(false);

        public async Task UpdatePeriodAsync(CancellationToken cancellationToken, Period periodToUpdate) =>
            await UpdateAsync(cancellationToken, periodToUpdate).ConfigureAwait(false);
    }
}
