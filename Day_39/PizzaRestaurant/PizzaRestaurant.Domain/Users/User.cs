using System;
using PizzaRestaurant.Domain.Addresses;

namespace PizzaRestaurant.Domain.Users
{
	public class User
	{
		public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
	}
}

