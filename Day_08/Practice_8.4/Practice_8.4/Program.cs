using System;

namespace Practice_8._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 2;
            int degree = 10;
            Console.WriteLine(PowerOfNum(number, degree, 1));
        }

        private static int PowerOfNum(int number, int degree, int res)
        {
            if(degree == 0)
            {
                return res;
            }
            return PowerOfNum(number, degree - 1, res * number);
        }
    }
}

