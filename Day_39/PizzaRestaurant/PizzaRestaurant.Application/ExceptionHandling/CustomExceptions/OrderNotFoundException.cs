using System;
namespace PizzaRestaurant.Application.ExceptionHandling.CustomExceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException() : base("This User has never orderd this pizza.")
        {

        }

        public OrderNotFoundException(string message) : base(message)
        {

        }

        public OrderNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

