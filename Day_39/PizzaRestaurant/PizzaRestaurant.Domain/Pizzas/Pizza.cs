﻿using System;
namespace PizzaRestaurant.Domain.Pizzas
{
	public class Pizza
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public double CaloryCount { get; set; }
    }
}

