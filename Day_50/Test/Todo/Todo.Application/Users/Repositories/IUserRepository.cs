using System;
using Todo.Domain.Users;

namespace Todo.Application.Users.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(CancellationToken cancellationToken, User user);
        Task<User> GetAsync(CancellationToken cancellationToken, string username, string hashedPassword);
        Task<bool> Exists(CancellationToken cancellationToken, string username);
        Task<int> GetIdByUsername(CancellationToken cancellation, string username);
    }
}

