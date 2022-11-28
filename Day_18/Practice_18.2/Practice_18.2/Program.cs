using System;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;

namespace Practice_18._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter User's Name: ");
            User currUser = new User(Console.ReadLine());
            Console.WriteLine("Enter User's bank account number: ");
            IBAN currIban = new IBAN(Console.ReadLine());
            currUser.UserIBAN = currIban;
            Console.WriteLine($"User's name is {currUser} and User's IBAN is {currIban}");
            

            Console.WriteLine("You can use your \n1. Debit IBAN (write capital D)\n2. Credit IBAN (Write capital C)");
            Console.Write("Choose an account: ");
            char c = Convert.ToChar(Console.ReadLine());
            if (c == 'D')
            {
                Console.Write("Enter User's debit account number: ");
                string debitAccount = Console.ReadLine();
                Console.Write("First you need to deposit some amount of money. Enter the amount:");
                int starterDeposit = Convert.ToInt32(Console.ReadLine());

                DebitIban debit = new DebitIban(debitAccount, starterDeposit);
                currUser.UserIBAN.DebitIban = debit;

                Console.WriteLine("You can deposit (Write capital D) or Withdraw (write capital W) money. Which do you prefer?");
                char c2 = Convert.ToChar(Console.ReadLine());
                if (c2 == 'D' || c2 == 'd') 
                {
                    Console.Write("Enter amount of money to deposit: ");
                    int moneyDep = Convert.ToInt32(Console.ReadLine());
                    currUser.UserIBAN.DebitIban.Deposit(moneyDep);
                }else if(c2 == 'W' || c2 == 'w')
                {
                    Console.Write("Enter amount of money to withdraw: ");
                    int moneyWithdr = Convert.ToInt32(Console.ReadLine());
                    currUser.UserIBAN.DebitIban.WithdrawDebit(moneyWithdr);
                }
                Console.WriteLine($"Now the amount of money on your Debit account is {currUser.UserIBAN.DebitIban.Money}");
            }
            else if (c == 'C' || c == 'c') 
            {
                Console.Write("Enter User's credit account number: ");
                string creditAccount = Console.ReadLine();
                Console.WriteLine("Choose your credit card limit, it can be up to 50,000: ");
                int creditLimit = Convert.ToInt32(Console.ReadLine());

                CreditIban credit = new CreditIban(creditAccount, creditLimit);
                currUser.UserIBAN.CreditIban = credit;

                Console.Write("Do you want to withdraw money from credit account? Write Y for yes, N for no: ");
                char c3 = Convert.ToChar(Console.ReadLine());
                if (c3 == 'Y' || c3 == 'y')
                {
                    Console.Write("Enter amount of money to withdraw: ");
                    int moneyWithdr = Convert.ToInt32(Console.ReadLine());
                    currUser.UserIBAN.CreditIban.WithdrawCredit(moneyWithdr);
                }
                Console.WriteLine($"Now the amount of debt on your Credit account is {currUser.UserIBAN.CreditIban.Debt}");
            }
        }
    }
}

