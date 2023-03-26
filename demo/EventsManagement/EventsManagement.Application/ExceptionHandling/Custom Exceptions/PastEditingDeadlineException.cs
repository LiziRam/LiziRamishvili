using System;
namespace EventsManagement.Application.ExceptionHandling.CustomExceptions
{

    public class PastEditingDeadlineException : Exception
    {
        public PastEditingDeadlineException() : base("User can not edit this event anymore.")
        {

        }

        public PastEditingDeadlineException(string message) : base(message)
        {

        }

        public PastEditingDeadlineException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

