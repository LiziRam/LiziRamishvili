using System;

namespace Practice_6._8
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = GetInput();
            string res = GetCoefficients(input);
            Console.WriteLine(res);
        }

        private static int GetInput()
        {
            Console.Write("Enter a positive number: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        private static string GetCoefficients(int num)
        {
            int keeper = num;
            string s = "";
            int remainder;
            int currCoefficient = 0;
            while (num > 0)
            {
                remainder = num % 10;
                if (num == keeper)
                {
                    s = remainder + " * 10^" + currCoefficient;
                }
                else
                {
                    s = remainder + " * 10^" + currCoefficient + " + " + s;
                }
                num = num / 10;
                currCoefficient++;
            }
            s = keeper + " = " + s;
            return s;
        }
    }
}

