using System;

namespace Practice_7._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Hello";
            PrintReverse(input);
        }

        private static void PrintReverse(string s)
        {
            string reverse = "";
            for(int i = 0; i < s.Length; i++)
            {
                reverse = s[i] + reverse;
            }
            Console.WriteLine(reverse);
        }
    }
}

