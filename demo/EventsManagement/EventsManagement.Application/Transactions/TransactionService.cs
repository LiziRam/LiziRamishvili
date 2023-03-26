using EventsManagement.Application.Events;
using EventsManagement.Application.ExceptionHandling.CustomExceptions;
using EventsManagement.Application.Periods;
using EventsManagement.Application.Transactions.Repositories;
using EventsManagement.Application.Transactions.Responses;
using EventsManagement.Domain.Transactions;
using Mapster;

namespace EventsManagement.Application.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly IContextWrapper _contextWrapper;
        private readonly IEventService _eventService;

        private readonly IPeriodService _periodService;

        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transRepo, IEventService eventService,
            IPeriodService periodService, IContextWrapper contextWrapper)
        {
            _transactionRepository = transRepo;
            _eventService = eventService;
            _periodService = periodService;
            _contextWrapper = contextWrapper;
        }

        public async Task<TransactionResponseModel> GetAsync(CancellationToken cancellationToken, int id, int userId)
        {
            var transtoGet = await _transactionRepository.GetAsync(cancellationToken, id).ConfigureAwait(false);
            if (transtoGet == null)
                throw new TransactionNotFoundException();

            if (transtoGet.UserId != userId)
                throw new WrongUserException();

            return transtoGet.Adapt<TransactionResponseModel>();
        }

        public async Task<List<TransactionResponseModel>> GetAllAsync(CancellationToken cancellationToken, int userId)
        {
            var transtoGet = await _transactionRepository.GetAllAsync(cancellationToken, userId).ConfigureAwait(false);
            var transResponse = transtoGet.Adapt<List<TransactionResponseModel>>();
            return transResponse;
        }

        public async Task<TransactionResponseModel> CreateBookingAsync(CancellationToken cancellationToken, int eventId,
            int userId)
        {
            var bookingExists = await _transactionRepository.BookingExists(cancellationToken, eventId, userId).ConfigureAwait(false);
            if (bookingExists)
                throw new AlreadyBookedException();

            var currEvent =
                await _eventService.GetAsync(cancellationToken, eventId).ConfigureAwait(false);

            if (!currEvent.IsAdmitted)
                throw new EventNotPublicException();

            if (currEvent.TicketsAvailable < 1)
                throw new TicketsSoldOutException();

            var bookingToExecute = new Transaction();
            bookingToExecute.TransactionType = TransactionType.Booked;
            bookingToExecute.EventId = eventId;
            bookingToExecute.TicketPrice = currEvent.TicketPrice;
            bookingToExecute.UserId = userId;

            await _eventService.UpdateTicketAvailability(cancellationToken, eventId, -1).ConfigureAwait(false);

            var response = await _transactionRepository.CreateTransactionAsync(cancellationToken, bookingToExecute).ConfigureAwait(false);

            return response.Adapt<TransactionResponseModel>();
        }

        public async Task<TransactionResponseModel> CreatePurchaseAsync(CancellationToken cancellationToken,
            int eventId, int userId)
        {
            var bookingExists = await _transactionRepository.BookingExists(cancellationToken, eventId, userId).ConfigureAwait(false);
            if (bookingExists)
            {
                var booking = await _transactionRepository.GetByEventIdAsync(cancellationToken, eventId, userId).ConfigureAwait(false);
                booking.TransactionType = TransactionType.Purchased;
                await _transactionRepository.UpdateAsync(cancellationToken, booking).ConfigureAwait(false);
                return booking.Adapt<TransactionResponseModel>();
            }

            var madeBooking = await CreateBookingAsync(cancellationToken, eventId, userId).ConfigureAwait(false);
            return await CreatePurchaseAsync(cancellationToken, eventId, userId).ConfigureAwait(false);
        }

        public async Task<bool> BookingExists(CancellationToken cancellationToken, int eventId, int userId) =>
            await _transactionRepository.BookingExists(cancellationToken, eventId, userId).ConfigureAwait(false);

        public async Task CancelAsync(CancellationToken cancellationToken, int eventId, int userId)
        {
            var bookingExists = await _transactionRepository.BookingExists(cancellationToken, eventId, userId).ConfigureAwait(false);
            if (!bookingExists)
                throw new BookingNotFoundException();

            var booking = await _transactionRepository.GetByEventIdAsync(cancellationToken, eventId, userId).ConfigureAwait(false);
            
            booking.TransactionType = TransactionType.Cancelled;
            booking.ModifiedAt = DateTime.UtcNow;

            await _eventService.UpdateTicketAvailability(cancellationToken, eventId, +1).ConfigureAwait(false);
        }

        //--------------------------------ვორქერი---------------------------------

        public async Task CancelOverdueBookingsAsync(CancellationToken stoppingToken)
        {
            var period = await _periodService.GetBookingDaysAsync(stoppingToken).ConfigureAwait(false);
            var overDueBookings = await _transactionRepository.GetOverdueBookings(stoppingToken, period).ConfigureAwait(false);
            foreach (var booking in overDueBookings)
            {
                booking.TransactionType = TransactionType.Cancelled;
                await CancelAsync(stoppingToken, booking.EventId, booking.UserId).ConfigureAwait(false);
            }
        }
    }
}
