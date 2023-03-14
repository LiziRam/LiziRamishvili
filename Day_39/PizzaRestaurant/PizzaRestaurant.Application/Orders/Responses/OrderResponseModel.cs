using System;
using PizzaRestaurant.Domain.Pizzas;

namespace PizzaRestaurant.Application.Orders.Responses
{
	public class OrderResponseModel
	{
        public int Id { get; set; }
        public int UserId { get; set; }  
        public int AddressId { get; set; }
        public int PizzaId { get; set; }
    }
}

