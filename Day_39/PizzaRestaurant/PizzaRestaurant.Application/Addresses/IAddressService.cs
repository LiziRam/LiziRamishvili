using System;
using PizzaRestaurant.Application.Addresses.Requests;
using PizzaRestaurant.Application.Addresses.Responses;

namespace PizzaRestaurant.Application.Addresses
{
	public interface IAddressService
	{
        Task CreateAsync(CancellationToken cancellationToken, AddressRequestModel address);
        Task<List<AddressResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<AddressResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task UpdateAsync(CancellationToken cancellationToken, AddressRequestModel address, int id);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
    }
}



