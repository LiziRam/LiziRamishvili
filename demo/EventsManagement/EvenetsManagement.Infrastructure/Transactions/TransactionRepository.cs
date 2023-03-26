using EventsManagement.Application.Transactions.Repositories;
using EventsManagement.Domain.Transactions;
using EventsManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EvenetsManagement.Infrastructure.Transactions
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(EventsManagementContext context) : base(context)
        {
        }

        public async Task<Transaction> GetAsync(CancellationToken cancellationToken, int id) =>
            await _dbSet.SingleOrDefaultAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);

        public async Task<List<Transaction>> GetAllAsync(CancellationToken cancellationToken, int userId) =>
            await _dbSet.Where(x => x.UserId == userId).ToListAsync(cancellationToken).ConfigureAwait(false);


        public async Task<Transaction>
            GetByEventIdAsync(CancellationToken cancellationToken, int eventId, int userId) =>
            await _dbSet.SingleOrDefaultAsync(
                x => x.UserId == userId && x.EventId == eventId && x.TransactionType == TransactionType.Booked,
                cancellationToken).ConfigureAwait(false);

        public async Task<Transaction> CreateTransactionAsync(CancellationToken cancellationToken,
            Transaction transToCreate)
        {
            await AddAsync(cancellationToken, transToCreate).ConfigureAwait(false);
            return transToCreate;
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, Transaction transToUpdate)
        {
            transToUpdate.ModifiedAt = DateTime.UtcNow;
            await base.UpdateAsync(cancellationToken, transToUpdate).ConfigureAwait(false);
        }

        public async Task<bool> BookingExists(CancellationToken cancellationToken, int eventId, int userId) =>
            await AnyAsync(cancellationToken,
                x => x.UserId == userId && x.EventId == eventId && x.TransactionType == TransactionType.Booked).ConfigureAwait(false);

        //---------------ვორქერისთვის-------------------

        public async Task<List<Transaction>> GetOverdueBookings(CancellationToken stoppingToken, int period) =>
            await _dbSet.Where(x => (DateTime.UtcNow - x.CreatedAt).Days > period).ToListAsync(stoppingToken).ConfigureAwait(false);
    }
}
