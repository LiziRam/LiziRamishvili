using System;
namespace Todo.Application.ExceptionHandling.CustomExceptions
{
	public class StatusDeletedException : Exception
	{
        public StatusDeletedException() : base("This task has been deleted.")
        {

        }

        public StatusDeletedException(string message) : base(message)
        {

        }

        public StatusDeletedException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

