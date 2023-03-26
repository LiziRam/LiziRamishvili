using System;
namespace EventsManagement.Application.ExceptionHandling.CustomExceptions
{
    public class InvalidLoginRequestException : Exception
    {
        public InvalidLoginRequestException() : base("Invalid Login Attempt.")
        {

        }

        public InvalidLoginRequestException(string message) : base(message)
        {

        }

        public InvalidLoginRequestException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

