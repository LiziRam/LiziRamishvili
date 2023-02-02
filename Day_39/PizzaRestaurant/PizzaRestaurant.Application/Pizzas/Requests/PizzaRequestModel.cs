using System;
namespace PizzaRestaurant.Application.Pizzas.Requests
{
	public class PizzaRequestModel
	{
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public double CaloryCount { get; set; }
    }
}

