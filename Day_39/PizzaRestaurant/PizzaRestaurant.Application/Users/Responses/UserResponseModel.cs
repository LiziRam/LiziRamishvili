using System;
using PizzaRestaurant.Application.Addresses.Responses;

namespace PizzaRestaurant.Application.Users.Responses
{
	public class UserResponseModel
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<AddressResponseModel> Addresses { get; set; }
    }
}

