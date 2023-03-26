using System;
namespace EventsManagement.Application.ExceptionHandling.CustomExceptions
{
    public class EventNotFoundException : Exception
    {
        public EventNotFoundException() : base("Event with this Id not found in the database.")
        {

        }

        public EventNotFoundException(string message) : base(message)
        {

        }

        public EventNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

