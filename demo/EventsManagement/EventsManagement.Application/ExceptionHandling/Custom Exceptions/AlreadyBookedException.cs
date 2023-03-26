using System;
namespace EventsManagement.Application.ExceptionHandling.CustomExceptions
{
    public class AlreadyBookedException : Exception
    {
        public AlreadyBookedException() : base("User can only perform one booking at a time.")
        {

        }

        public AlreadyBookedException(string message) : base(message)
        {

        }

        public AlreadyBookedException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

