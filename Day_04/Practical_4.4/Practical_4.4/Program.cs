using System;

namespace Practical_4._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            int input = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            for(int i = 1; i <= input; i++)
            {
                if(i % 2 != 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine("Sum of odd numbers from 1 to " + input + " is " + sum);
        }
    }
}

