using System;
namespace EventsManagement.Application.ExceptionHandling.CustomExceptions
{

    public class WrongUserException : Exception
    {
        public WrongUserException() : base("Request is sent by the wrong user.")
        {

        }

        public WrongUserException(string message) : base(message)
        {

        }

        public WrongUserException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

