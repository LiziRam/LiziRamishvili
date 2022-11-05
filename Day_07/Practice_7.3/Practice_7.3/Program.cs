using System;

namespace Practice_7._3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Hello";
            PrintWithSpaces(input);
        }

        private static void PrintWithSpaces(string s)
        {
            string res = "";
            for(int i = 0; i < s.Length; i++)
            {
                res = res + s[i] + " ";
            }

            Console.WriteLine(res.TrimEnd());
        }
    }
}

