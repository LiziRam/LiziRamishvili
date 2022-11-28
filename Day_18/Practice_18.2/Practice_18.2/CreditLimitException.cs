using System;
namespace Practice_18._2
{
	public class CreditLimitException : Exception 
	{

        public CreditLimitException() : base("Amount of money is over the credit card limit.")
        {

        }

        public CreditLimitException(string message) : base(message)
        {

        }

        public CreditLimitException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

