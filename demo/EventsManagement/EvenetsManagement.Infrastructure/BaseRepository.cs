using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EvenetsManagement.Infrastructure
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly DbContext _context;

        protected readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetAsync(CancellationToken cancellationToken, params object[] key) =>
            await _dbSet.FindAsync(key, cancellationToken).ConfigureAwait(false);

        //public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken) =>
        //    await _dbSet.ToListAsync(cancellationToken).ConfigureAwait(false);

        public async Task AddAsync(CancellationToken cancellationToken, T entity)
        {
            await _dbSet.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, T entity)
        {
            if (entity == null)
                return;

            _dbSet.Update(entity);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        //public async Task RemoveAsync(CancellationToken cancellationToken, params object[] key)
        //{
        //    var entity = await GetAsync(cancellationToken, key);
        //    _dbSet.Remove(entity);
        //    await _context.SaveChangesAsync(cancellationToken);
        //}

        //public async Task RemoveAsync(CancellationToken cancellationToken, T entity)
        //{
        //    _dbSet.Remove(entity);
        //    await _context.SaveChangesAsync(cancellationToken);
        //}

        public Task<bool> AnyAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> predicate) =>
            _dbSet.AnyAsync(predicate, cancellationToken);

        public void Detach(T entity) => _context.Entry(entity).State = EntityState.Detached;
    }
}
