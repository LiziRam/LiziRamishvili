using System;

namespace Practical_4._6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            int input = Convert.ToInt32(Console.ReadLine());
            string result = "disivosrs of " + input + " are: 1";
            for(int i = 2; i <= input; i++)
            {
                if(input % i == 0)
                {
                    result += ", " + i;
                }
            }
            Console.WriteLine(result);
        }
    }
}