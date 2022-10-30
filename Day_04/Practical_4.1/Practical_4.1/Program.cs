using System;

namespace Practical_4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for(int i = 0; i <= 10; i++)
            {
                sum += i;
            }
            Console.WriteLine("Sum from 0 to 10 is " + sum);
        }
    }
}

