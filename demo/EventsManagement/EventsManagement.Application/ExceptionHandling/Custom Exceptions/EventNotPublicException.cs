using System;
namespace EventsManagement.Application.ExceptionHandling.CustomExceptions
{

    public class EventNotPublicException : Exception
    {
        public EventNotPublicException() : base("Event has not been admitted by admin yet.")
        {

        }

        public EventNotPublicException(string message) : base(message)
        {

        }

        public EventNotPublicException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

