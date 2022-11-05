using System;

namespace Practice_7._4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Hello world";
            int words = CountWords(input.Trim());
            PrintWordCount(words);
        }

        private static int CountWords(string s)
        {
            int countSpaces = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Equals(' '))
                {
                    countSpaces++;
                }
            }

            return countSpaces + 1;
        }

        private static void PrintWordCount(int n)
        {
            Console.WriteLine(n);
        }
    }
}

