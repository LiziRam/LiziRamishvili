using System;
using PizzaRestaurant.Domain.Users;

namespace PizzaRestaurant.Domain.Addresses
{
	public class Address
	{
        public int Id { get; set; }
        public int UserId { get; set; } 
        public string City { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
    }
}

