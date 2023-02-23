using System;
namespace Todo.Application.ExceptionHandling.CustomExceptions
{
	public class InvalidLoginRequestException : Exception
	{
        public InvalidLoginRequestException() : base("Username or password is incorrect.")
        {

        }

        public InvalidLoginRequestException(string message) : base(message)
        {

        }

        public InvalidLoginRequestException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

