using System;
namespace EventsManagement.Application.ExceptionHandling.CustomExceptions
{

    public class TransactionNotFoundException : Exception
    {
        public TransactionNotFoundException() : base("Transaction with this Id is not in the database.")
        {

        }

        public TransactionNotFoundException(string message) : base(message)
        {

        }

        public TransactionNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

