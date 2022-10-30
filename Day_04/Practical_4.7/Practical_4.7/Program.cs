using System;

namespace Practical_4._7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            int input = Convert.ToInt32(Console.ReadLine());
            string res = "0";
            int a = 0;
            int b = 1;
            int dummy;
            for (int i = 0; i < input; i++)
            {
                res += ", " + b;
                dummy = a;
                a = b;
                b = a + dummy;
            }
            Console.WriteLine(res);
        }
    }
}

