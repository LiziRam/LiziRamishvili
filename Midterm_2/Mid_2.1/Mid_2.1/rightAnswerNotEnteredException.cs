using System;
namespace Mid_2._1
{
	public class rightAnswerNotEnteredException : Exception
	{
		public rightAnswerNotEnteredException() : base("No right answer has been antered among 4 answers")
		{

		}

        public rightAnswerNotEnteredException(string message) : base(message)
        {

        }

        public rightAnswerNotEnteredException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

