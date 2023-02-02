using System;
namespace PizzaRestaurant.Application.ExceptionHandling.CustomExceptions
{
    public class WrongAddressException : Exception
    {
        public WrongAddressException() : base("This is not the user's address.")
        {

        }

        public WrongAddressException(string message) : base(message)
        {

        }

        public WrongAddressException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

