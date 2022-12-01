using System;
namespace Practice_18._2
{
	public class DebitIban : IBAN
    {
        private int _moneyOnAccount;

        public DebitIban(string creditAccount, int startMoney) : base(creditAccount)
        {
            _moneyOnAccount = startMoney;
        }

        public DebitIban(string creditAccount) : base(creditAccount)
        {
            _moneyOnAccount = 0;
        }

        public int Money
        {
            get
            {
                return _moneyOnAccount;
            }
        }

        public void Deposit(int amount)
        {
            if (amount < 0)
            {
                throw new WrongMoneyFormatException();
            }
            _moneyOnAccount += amount;
        }

        public void WithdrawDebit(int amount)
        {
            if (amount < 0)
            {
                throw new WrongMoneyFormatException();
            }
            if (amount > _moneyOnAccount)
            {
                throw new DebitOutOfMoneyException();
            }
            _moneyOnAccount -= amount;
        }
    }

}

