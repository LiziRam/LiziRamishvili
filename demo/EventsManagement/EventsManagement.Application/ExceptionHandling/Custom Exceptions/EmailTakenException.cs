using System;
namespace EventsManagement.Application.ExceptionHandling.CustomExceptions
{

    public class EmailTakenException : Exception
    {
        public EmailTakenException() : base("This email is already taken by a different user.")
        {

        }

        public EmailTakenException(string message) : base(message)
        {

        }

        public EmailTakenException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

