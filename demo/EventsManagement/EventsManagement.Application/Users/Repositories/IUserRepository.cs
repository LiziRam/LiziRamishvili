using EventsManagement.Domain.Users;
using Microsoft.AspNetCore.JsonPatch;

namespace EventsManagement.Application.Users.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(CancellationToken cancellationToken, User user);
        Task<int> GetIdByUsername(CancellationToken cancellation, string username);
        Task<User> GetAsync(CancellationToken cancellationToken, string username, string hashedPassword);
        Task<bool> Exists(CancellationToken cancellationToken, string username);
        Task<bool> Exists(CancellationToken cancellationToken, int id);
        Task<bool> EmailExists(CancellationToken cancellationToken, string email);
        Task UpdateAsync(CancellationToken cancellationToken, User user);

        Task<User> GetByIdAsync(CancellationToken cancellationToken, int id);
        Task<List<User>> GetAllActiveAsync(CancellationToken cancellationToken);
        
    }
}
