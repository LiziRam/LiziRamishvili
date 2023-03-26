using System;
namespace EventsManagement.Application.ExceptionHandling.CustomExceptions
{
    public class BookingNotFoundException : Exception
    {
        public BookingNotFoundException() : base("No booking was found to cancel.")
        {

        }

        public BookingNotFoundException(string message) : base(message)
        {

        }

        public BookingNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

