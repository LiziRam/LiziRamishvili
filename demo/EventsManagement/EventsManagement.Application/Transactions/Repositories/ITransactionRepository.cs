using EventsManagement.Domain.Transactions;

namespace EventsManagement.Application.Transactions.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateTransactionAsync(CancellationToken cancellationToken, Transaction transToCreate);
        Task<List<Transaction>> GetAllAsync(CancellationToken cancellationToken, int userId);
        Task<Transaction> GetAsync(CancellationToken cancellationToken, int id);
        Task<Transaction> GetByEventIdAsync(CancellationToken cancellationToken, int eventId, int userId);
        Task UpdateAsync(CancellationToken cancellationToken, Transaction transToUpdate);
        Task<bool> BookingExists(CancellationToken cancellationToken, int eventId, int userId);

        Task<List<Transaction>> GetOverdueBookings(CancellationToken stoppingToken, int period);
    }
}
