using System;

namespace Practical_3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number :");
            int number = Convert.ToInt32(Console.ReadLine());
            int pow = number * number;
            Console.WriteLine("The pow of the entered number is " + pow);
        }
    }
}

