using System;
namespace Practice_18._2
{
	public class IBAN
	{
		private string _iban;
		private CreditIban _creditIban;
		private DebitIban _debitIban;

		public IBAN(string bankAccount)
		{
			if (bankAccount.Length > 34 ||
				!(Char.IsLetter(bankAccount[0]) && Char.IsLetter(bankAccount[1])))
			{
				throw new IbanInvalidFormatException();
			}
			_iban = bankAccount;
		}

        public CreditIban CreditIban
		{
			get
			{
				return _creditIban;
			}
			set
			{
                if (_creditIban == null)
                {
                    _creditIban = value;
                }
            }
		}

        public DebitIban DebitIban
        {
            get
            {
                return _debitIban;
            }
            set
            {
                if (_debitIban == null)
                {
                    _debitIban = value;
                }
            }
        }

        public override string ToString()
        {
            return _iban;
        }
    }
}

