using System;
namespace PizzaRestaurant.Application.ExceptionHandling.CustomExceptions
{
    public class PizzaNotFoundException : Exception
    {
        public PizzaNotFoundException() : base("There are no pizzas of this kind")
        {

        }

        public PizzaNotFoundException(string message) : base(message)
        {

        }

        public PizzaNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

