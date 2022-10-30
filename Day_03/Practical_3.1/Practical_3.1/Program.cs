using System;

namespace Practical_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter integer number : ");
            int number = Convert.ToInt32(Console.ReadLine());
            string oddOrEven;
            if (number % 2 == 0)
            {
                oddOrEven = "even";
            }
            else
            {
                oddOrEven = "odd";
            }
            Console.WriteLine("Entered number " + number + " is " + oddOrEven);
        }
    }
}

