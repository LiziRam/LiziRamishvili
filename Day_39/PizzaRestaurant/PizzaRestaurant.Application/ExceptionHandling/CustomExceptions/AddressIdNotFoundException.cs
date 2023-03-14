using System;
namespace PizzaRestaurant.Application.ExceptionHandling.CustomExceptions
{
    public class AddressIdNotFoundException : Exception
    {
        public AddressIdNotFoundException() : base("There are no addresses with this ID in the Database")
        {

        }

        public AddressIdNotFoundException(string message) : base(message)
        {

        }

        public AddressIdNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

