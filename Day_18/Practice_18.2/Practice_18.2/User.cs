using System;
namespace Practice_18._2
{
	public class User
	{
		private IBAN _userIban;

		public User(string name)
		{
			UserName = name;
		}

		public string UserName { get; }
		public IBAN UserIBAN
		{
			get
			{
				return _userIban;
			}
			set
			{
				if(_userIban == null)
				{
					_userIban = value;
				}
			}
		}

		public override string ToString()
		{
			return UserName;
		}

	}
}

