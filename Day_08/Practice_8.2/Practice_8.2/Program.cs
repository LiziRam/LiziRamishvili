using System;

namespace Practice_8._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 13;
            int sum = SumRecursive(input, 0);
            Console.WriteLine(sum);
        }

        private static int SumRecursive(int n, int sum)
        {
            if(n == 0)
            {
                return 0;
            }
            sum = n;
            return sum + SumRecursive(n - 1, sum);
        }


    }
}

