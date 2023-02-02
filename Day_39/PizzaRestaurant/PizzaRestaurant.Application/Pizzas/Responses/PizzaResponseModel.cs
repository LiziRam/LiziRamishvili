using System;
namespace PizzaRestaurant.Application.Pizzas.Responses
{
    public class PizzaResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public double CaloryCount { get; set; }
        public double Rank { get; set; } 
    }
}
