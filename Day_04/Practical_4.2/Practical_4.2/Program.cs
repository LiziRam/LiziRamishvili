using System;

namespace Practical_4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number: ");
            int input = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            for(int i = 1; i <= input; i++)
            {
                sum += i;
            }
            Console.WriteLine("Sum from 1 to " + input + " is " + sum);
        }
    }
}

