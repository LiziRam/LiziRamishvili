using System;
namespace Practice_23
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