using System;
using PizzaRestaurant.Domain.Pizzas;

namespace PizzaRestaurant.Application.Orders.Requests
{
	public class OrderRequestModel
	{
        public int UserId { get; set; }  
        public int AddressId { get; set; } 
        public int PizzaId { get; set; }
    }
}

