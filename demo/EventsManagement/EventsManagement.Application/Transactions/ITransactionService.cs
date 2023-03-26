using EventsManagement.Application.Transactions.Responses;

namespace EventsManagement.Application.Transactions
{
    public interface ITransactionService
    {
        Task<TransactionResponseModel> GetAsync(CancellationToken cancellationToken, int id, int userId);
        Task<List<TransactionResponseModel>> GetAllAsync(CancellationToken cancellationToken, int userId);
        Task<TransactionResponseModel> CreateBookingAsync(CancellationToken cancellationToken, int eventId, int userId);

        Task<TransactionResponseModel>
            CreatePurchaseAsync(CancellationToken cancellationToken, int eventid, int userId);

        Task CancelAsync(CancellationToken cancellationToken, int eventId, int userId);
        Task CancelOverdueBookingsAsync(CancellationToken stoppingToken);
        Task<bool> BookingExists(CancellationToken cancellationToken, int eventId, int userId);
    }
}
