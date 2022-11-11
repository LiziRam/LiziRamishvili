using System;

namespace Practice_8._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 999;
            int tenPow = MaxPowerOfTen(input, 0);
            Console.WriteLine(tenPow);
        }

        private static int MaxPowerOfTen(int n, int maxPow)
        {
            if(n == 0)
            {
                return maxPow;
            }
            maxPow++;
            return MaxPowerOfTen(n / 10, maxPow);
        }
    }
}

