namespace PizzaRestaurant.Application.ExceptionHandling.CustomExceptions;

public class EmptyListException : Exception
{
    public EmptyListException() : base("There are no objects of this kind")
    {

    }

    public EmptyListException(string message) : base(message)
    {

    }

    public EmptyListException(string message, Exception inner) : base(message, inner)
    {

    }
}