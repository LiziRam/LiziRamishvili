namespace PizzaRestaurant.Application.ExceptionHandling.CustomExceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("Owner of this address is not in the database")
    {

    }

    public UserNotFoundException(string message) : base(message)
    {

    }

    public UserNotFoundException(string message, Exception inner) : base(message, inner)
    {

    }
}