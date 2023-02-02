using System;
namespace PizzaRestaurant.Application.ExceptionHandling.CustomExceptions
{
    public class UserIdNotFoundException : Exception
    {
        public UserIdNotFoundException() : base("There are no users with this ID in the Database")
        {

        }

        public UserIdNotFoundException(string message) : base(message)
        {

        }

        public UserIdNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

