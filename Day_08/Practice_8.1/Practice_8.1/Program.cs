using System;

namespace Practice_8._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 13;
            PrintRecursive(13, 1);
        }

        private static void PrintRecursive(int n, int curr)
        {
            if(curr > n)
            {
                return;
            }

            Console.Write(curr + " ");
            PrintRecursive(n, curr + 1);
        }
    }
}

