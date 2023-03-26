using EventsManagement.Application.Periods.Repositories;
using EventsManagement.Domain.Periods;

namespace EventsManagement.Application.Periods
{
    public class PeriodService : IPeriodService
    {
        private readonly IPeriodRepository _repository;

        public PeriodService(IPeriodRepository repository) => _repository = repository;

        public async Task<int> GetEditDaysAsync(CancellationToken cancellationToken)
        {
            var editPeriod = await _repository.GetEditPeriodAsync(cancellationToken).ConfigureAwait(false);
            return editPeriod;
        }

        public async Task<int> GetBookingDaysAsync(CancellationToken cancellationToken)
        {
            var bookingPeriod = await _repository.GetBookingPeriodAsync(cancellationToken).ConfigureAwait(false);
            return bookingPeriod;
        }

        public async Task UpdateEditDaysAsync(CancellationToken cancellationToken, int newDays)
        {
            var editPeriodToUpdate = await _repository.GetPeriodsAsync(cancellationToken).ConfigureAwait(true);
            if (editPeriodToUpdate == null)
            {
                var initialCreate = new Period();
                initialCreate.EditPeriod = newDays;
                await _repository.CreatePeriodAsync(cancellationToken, initialCreate).ConfigureAwait(false);
            }
            else
            {
                editPeriodToUpdate.EditPeriod = newDays;
                await _repository.UpdatePeriodAsync(cancellationToken, editPeriodToUpdate).ConfigureAwait(false);
            }
        }

        public async Task UpdateBookingDaysAsync(CancellationToken cancellationToken, int newDays)
        {
            var bookingPeriodToUpdate = await _repository.GetPeriodsAsync(cancellationToken).ConfigureAwait(false);
            if (bookingPeriodToUpdate == null)
            {
                var initialCreate = new Period();
                initialCreate.BookingPeriod = newDays;
                await _repository.CreatePeriodAsync(cancellationToken, initialCreate).ConfigureAwait(false);
            }
            else
            {
                bookingPeriodToUpdate.BookingPeriod = newDays;
                await _repository.UpdatePeriodAsync(cancellationToken, bookingPeriodToUpdate).ConfigureAwait(false);
            }
        }
    }
}
