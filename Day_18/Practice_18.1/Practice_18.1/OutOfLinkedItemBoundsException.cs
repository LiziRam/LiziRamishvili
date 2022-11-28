using System;
namespace Practice_18._1
{
	public class OutOfLinkedItemBoundsException : Exception
	{
		public OutOfLinkedItemBoundsException() : base("This index is out of bounds of a Linked Item.")
		{

		}

        public OutOfLinkedItemBoundsException(string message) : base(message)
        {

        }

        public OutOfLinkedItemBoundsException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}

