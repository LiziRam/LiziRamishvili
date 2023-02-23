using System;
namespace Todo.Application.ExceptionHandling.CustomExceptions
{
	public class TodoNotFoundException : Exception
	{
        public TodoNotFoundException() : base("Task with this id does not exist.")
        {

        }

        public TodoNotFoundException(string message) : base(message)
        {

        }

        public TodoNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

