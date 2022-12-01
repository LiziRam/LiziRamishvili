using System;
namespace Practice_18._2
{
	public class CreditIban : IBAN
	{
        private int _creditLimit;
		private int _debt;

		public CreditIban(string creditAccount, int limit) : base(creditAccount)
		{
			_creditLimit = limit;
			_debt = 0;
        }

		public int Debt
		{
			get
			{
				return _debt;
			}
		}

		public void WithdrawCredit(int amount)
		{
			if(amount < 0)
			{
				throw new WrongMoneyFormatException();
			}
			if(_debt + amount > _creditLimit)
			{
				throw new CreditLimitException();
			}
			_debt += amount;
		}
	}
}

