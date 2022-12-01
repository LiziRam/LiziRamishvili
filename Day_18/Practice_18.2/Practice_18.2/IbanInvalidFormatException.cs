using System;
namespace Practice_18._2
{
	public class IbanInvalidFormatException : Exception 
	{
        public IbanInvalidFormatException() : base("Bank account format is invalid.")
        {

        }

        public IbanInvalidFormatException(string message) : base(message)
        {

        }

        public IbanInvalidFormatException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

