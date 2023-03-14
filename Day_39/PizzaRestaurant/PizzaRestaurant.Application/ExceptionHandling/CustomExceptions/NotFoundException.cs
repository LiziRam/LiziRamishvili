namespace PizzaRestaurant.Application.ExceptionHandling.CustomExceptions;

public class NotFoundException : Exception
{
    public NotFoundException() : base("No such object can be found")
    {

    }

    public NotFoundException(string message) : base(message)
    {

    }

    public NotFoundException(string message, Exception inner) : base(message, inner)
    {

    }
}