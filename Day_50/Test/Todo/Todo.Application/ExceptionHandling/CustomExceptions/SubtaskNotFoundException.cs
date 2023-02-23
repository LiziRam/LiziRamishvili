using System;
namespace Todo.Application.ExceptionHandling.CustomExceptions
{
	public class SubtaskNotFoundException : Exception
	{
        public SubtaskNotFoundException() : base("Subtask with this id does not exist.")
        {

        }

        public SubtaskNotFoundException(string message) : base(message)
        {

        }

        public SubtaskNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

