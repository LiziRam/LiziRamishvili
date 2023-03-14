namespace PizzaRestaurant.Infrastructure.CustomExceptions;

public class AlreadyCreatedException : Exception
{
    public AlreadyCreatedException() : base("This object is already created")
    {

    }

    public AlreadyCreatedException(string message) : base(message)
    {

    }

    public AlreadyCreatedException(string message, Exception inner) : base(message, inner)
    {

    }
}