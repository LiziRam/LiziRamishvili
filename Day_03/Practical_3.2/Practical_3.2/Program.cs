using System;

namespace Practical_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number :");
            int first = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number :");
            int second = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter first number :");
            int third = Convert.ToInt32(Console.ReadLine());


            bool triangle = (first + second) > third && (second + third) > first && (first + third) > second;
            string shouldIt;
            if (triangle)
            {
                shouldIt = "should";
            }
            else
            {
                shouldIt = "should not";
            }

            Console.WriteLine("This " + shouldIt + " be a triangle !");
        }
    }
}

