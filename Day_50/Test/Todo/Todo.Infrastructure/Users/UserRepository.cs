using System;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Users.Repositories;
using Todo.Domain.Users;
using Todo.Persistence.Context;



namespace Todo.Infrastructure.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TodoContext context) : base(context)
        {

        }

        public async Task<User> CreateAsync(CancellationToken cancellationToken, User user)
        {
            user.CreatedAt = DateTime.Now;
            user.ModifiedAt = DateTime.Now;
            await AddAsync(cancellationToken, user);
            return user;
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, string username)
        {
            return await base.AnyAsync(cancellationToken, x => x.Username == username);
        }

        public async Task<User> GetAsync(CancellationToken cancellationToken, string username, string hashedPassword)
        {
            return _context.Set<User>().SingleOrDefault(x => x.Username == username);
        }

        public async Task<int> GetIdByUsername(CancellationToken cancellation, string username)
        {
            var user = _context.Set<User>().SingleOrDefault(x => x.Username == username);
            return user.Id;
        }
    }
}

