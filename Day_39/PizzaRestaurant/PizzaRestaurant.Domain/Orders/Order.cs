using System;
using PizzaRestaurant.Domain.Pizzas;

namespace PizzaRestaurant.Domain.Orders
{
	public class Order
	{
		public int Id { get; set; }
        public int UserId { get; set; }  
        public int AddressId { get; set; } 
        public int PizzaId { get; set; }
    }
}

