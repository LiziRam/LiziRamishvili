using System;
namespace Practice_18._2
{
	public class WrongMoneyFormatException : Exception 
	{
        public WrongMoneyFormatException() : base("Enterd money amount format is invalid.")
        {

        }

        public WrongMoneyFormatException(string message) : base(message)
        {

        }

        public WrongMoneyFormatException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

