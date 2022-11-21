using System;
using static Practice_12._1.Math;

namespace Practice_12._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number A: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter power: ");
            int pow = Convert.ToInt32(Console.ReadLine());

            var currStatPow = Statuses.Success;
            int power = Math.Pow(num1, pow, out currStatPow);

            Console.WriteLine($"Current status: {currStatPow}");
            if (power != -1)
            {
                Console.WriteLine($"{num1} ^ {pow} = {power}");
            }

            Console.WriteLine();


            Console.Write("Enter number B: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number C: ");
            int num3 = Convert.ToInt32(Console.ReadLine());

            var currStatMin = Statuses.Success;
            int min = Math.Min(num2, num3, out currStatMin);
            
            Console.WriteLine($"Current status: {currStatMin}");
            if (min != -1)
            {
                Console.WriteLine($"Min between {num2} and {num3} is {min}");
            }

            Console.WriteLine();

            var currStatMax = Statuses.Success;
            int max = Math.Max(num2, num3, out currStatMax);

            Console.WriteLine($"Current status: {currStatMax}");
            if (max != -1)
            {
                Console.WriteLine($"Max between {num2} and {num3} is {max}");
            }
        }
    }
}

