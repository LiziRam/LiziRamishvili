using System;

namespace Practical_4._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            int input = Convert.ToInt32(Console.ReadLine());
            for(int i = 1; i <= input; i++)
            {
                Console.WriteLine(i + " cubed is " + i * i * i);
            }
        }
    }
}

