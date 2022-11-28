using System;
namespace Practice_18._2
{
	public class DebitOutOfMoneyException : Exception
    {

        public DebitOutOfMoneyException() : base("There is not enough money on debit account to withdraw.")
        {

        }

        public DebitOutOfMoneyException(string message) : base(message)
        {

        }

        public DebitOutOfMoneyException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

