using EventsManagement.Application.Users.Repositories;
using EventsManagement.Domain.Events;
using EventsManagement.Domain.Users;
using EventsManagement.Persistence.Context;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace EvenetsManagement.Infrastructure.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EventsManagementContext context) : base(context)
        {
        }

        public async Task<User> GetAsync(CancellationToken cancellationToken, string username, string hashedPassword) =>
            await _dbSet.SingleOrDefaultAsync(
                x => x.UserName == username && x.PasswordHash == hashedPassword && !x.IsDeleted, cancellationToken).ConfigureAwait(false);

        public async Task<int> GetIdByUsername(CancellationToken cancellationToken, string username)
        {
            var user = await _dbSet.SingleOrDefaultAsync(x => x.UserName == username && !x.IsDeleted,
                cancellationToken).ConfigureAwait(false);
            return user.Id;
        }

        public async Task<User> CreateAsync(CancellationToken cancellationToken, User user)
        {
            await AddAsync(cancellationToken, user).ConfigureAwait(false);
            return user;
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, User user)
        {
            user.ModifiedAt = DateTime.UtcNow;
            await base.UpdateAsync(cancellationToken, user).ConfigureAwait(false);
        }

        public async Task<User> GetByIdAsync(CancellationToken cancellationToken, int id) =>
            await _dbSet.SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken).ConfigureAwait(false);

        public async Task<List<User>> GetAllActiveAsync(CancellationToken cancellationToken) =>
            await _dbSet.Where(x => x.IsDeleted == false).ToListAsync(cancellationToken).ConfigureAwait(false);

        public async Task<bool> Exists(CancellationToken cancellationToken, int id) =>
            await AnyAsync(cancellationToken, x => x.Id == id && !x.IsDeleted).ConfigureAwait(false);

        public async Task<bool> Exists(CancellationToken cancellationToken, string username) =>
            await AnyAsync(cancellationToken, x => x.UserName == username && !x.IsDeleted).ConfigureAwait(false);

        public async Task<bool> EmailExists(CancellationToken cancellationToken, string email) =>
            await AnyAsync(cancellationToken, x => x.Email == email && !x.IsDeleted).ConfigureAwait(false);

    }
}
