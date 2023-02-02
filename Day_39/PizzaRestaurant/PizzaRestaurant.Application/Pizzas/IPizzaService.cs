using System;
using PizzaRestaurant.Application.Pizzas.Requests;
using PizzaRestaurant.Application.Pizzas.Responses;

namespace PizzaRestaurant.Application.Pizzas
{
	public interface IPizzaService
	{
        Task CreateAsync(CancellationToken cancellationToken, PizzaRequestModel pizza);
        Task<List<PizzaResponseModel>> GetAllAsync(CancellationToken cancellationToken);
		Task<PizzaResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task UpdateAsync(CancellationToken cancellationToken, PizzaRequestModel pizza, int id);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
	}
}

