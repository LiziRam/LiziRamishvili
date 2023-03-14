using System;
using PizzaRestaurant.Application.Users.Requests;
using PizzaRestaurant.Application.Users.Responses;

namespace PizzaRestaurant.Application.Users
{
	public interface IUserService
	{
        Task CreateAsync(CancellationToken cancellationToken, UserRequestModel user);
        Task<List<UserResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<UserResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task UpdateAsync(CancellationToken cancellationToken, UserRequestModel user, int id);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
    }
}

