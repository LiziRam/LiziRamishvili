using System;
namespace PizzaRestaurant.Application.ExceptionHandling.CustomExceptions
{
    public class PizzaIdNotFoundException : Exception
    {
        public PizzaIdNotFoundException() : base("There are no pizzas with this ID in the Database")
        {

        }

        public PizzaIdNotFoundException(string message) : base(message)
        {

        }

        public PizzaIdNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

