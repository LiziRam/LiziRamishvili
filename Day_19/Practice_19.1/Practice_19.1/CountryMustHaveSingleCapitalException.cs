using System;
namespace Practice_19._1
{
	public class CountryMustHaveSingleCapitalException : Exception
	{
        public CountryMustHaveSingleCapitalException() : base("Invalid input: Country must have a single capital.")
        {

        }

        public CountryMustHaveSingleCapitalException(string message) : base(message)
        {

        }

        public CountryMustHaveSingleCapitalException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}

