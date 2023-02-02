using System;
using PizzaRestaurant.Domain.Addresses;

namespace PizzaRestaurant.Infrastructure.Addresses
{
	public interface IAddressRepository
	{
        Task<List<Address>> GetAllAsync(CancellationToken cancellationToken);
        Task<Address> GetByIdAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, Address address);
        Task UpdateAsync(CancellationToken cancellationToken, Address address, int id);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task<bool> Exists(CancellationToken cancellationToken, int id);
    }
}

