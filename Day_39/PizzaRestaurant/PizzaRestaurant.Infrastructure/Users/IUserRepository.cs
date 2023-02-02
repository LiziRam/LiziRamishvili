using System;
using PizzaRestaurant.Domain.Orders;
using PizzaRestaurant.Domain.Users;

namespace PizzaRestaurant.Infrastructure.Users
{
	public interface IUserRepository
	{
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
        Task<User> GetByIdAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, User user);
        Task UpdateAsync(CancellationToken cancellationToken, User user, int id);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task<bool> Exists(CancellationToken cancellationToken, int id);
        
    }
}

