using System;
namespace Practice_19._1
{
	public class InvalidInputException : Exception
	{
        public InvalidInputException() : base("Invalid input")
        {

        }

        public InvalidInputException(string message) : base($"Invalid input: {message}" )
        {

        }

        public InvalidInputException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}

