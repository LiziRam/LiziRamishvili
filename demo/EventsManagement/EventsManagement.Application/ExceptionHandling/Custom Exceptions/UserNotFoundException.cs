using System;
namespace EventsManagement.Application.ExceptionHandling.CustomExceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User with this Id not found in the database.")
        {

        }

        public UserNotFoundException(string message) : base(message)
        {

        }

        public UserNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

