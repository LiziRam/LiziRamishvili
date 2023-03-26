using System;
namespace EventsManagement.Application.ExceptionHandling.CustomExceptions
{

    public class UsernameTakenException : Exception
    {
        public UsernameTakenException() : base("This username is already taken by a different user.")
        {

        }

        public UsernameTakenException(string message) : base(message)
        {

        }

        public UsernameTakenException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

