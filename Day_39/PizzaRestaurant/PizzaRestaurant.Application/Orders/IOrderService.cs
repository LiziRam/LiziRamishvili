using System;
using PizzaRestaurant.Application.Orders.Requests;
using PizzaRestaurant.Application.Orders.Responses;

namespace PizzaRestaurant.Application.Orders
{
	public interface IOrderService
	{
        Task CreateAsync(CancellationToken cancellationToken, OrderRequestModel order);
        Task<List<OrderResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<OrderResponseModel> GetAsync(CancellationToken cancellationToken, int id);
    }
}

