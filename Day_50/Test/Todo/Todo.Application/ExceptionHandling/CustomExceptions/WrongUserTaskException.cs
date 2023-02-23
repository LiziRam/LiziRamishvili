using System;
namespace Todo.Application.ExceptionHandling.CustomExceptions
{
	public class WrongUserTaskException : Exception
	{
        public WrongUserTaskException() : base("This task does not belong to current user.")
        {

        }

        public WrongUserTaskException(string message) : base(message)
        {

        }

        public WrongUserTaskException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

