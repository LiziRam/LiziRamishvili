using System;
namespace EventsManagement.Application.ExceptionHandling.CustomExceptions
{
    public class TicketsSoldOutException : Exception
    {
        public TicketsSoldOutException() : base("All tickets are sold out.")
        {

        }

        public TicketsSoldOutException(string message) : base(message)
        {

        }

        public TicketsSoldOutException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

