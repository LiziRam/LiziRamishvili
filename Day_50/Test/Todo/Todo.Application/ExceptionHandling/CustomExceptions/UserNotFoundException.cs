using System;
namespace Todo.Application.ExceptionHandling.CustomExceptions
{
	public class UserNotFoundException : Exception
	{
        public UserNotFoundException() : base("This user does not exist.")
        {

        }

        public UserNotFoundException(string message) : base(message)
        {

        }

        public UserNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

