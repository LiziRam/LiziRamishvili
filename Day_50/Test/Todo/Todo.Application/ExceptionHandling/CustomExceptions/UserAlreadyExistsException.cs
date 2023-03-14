using System;
namespace Todo.Application.ExceptionHandling.CustomExceptions
{
	public class UserAlreadyExistsException : Exception
	{
        public UserAlreadyExistsException() : base("This Username is already exists.")
        {

        }

        public UserAlreadyExistsException(string message) : base(message)
        {

        }

        public UserAlreadyExistsException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

