using System;

namespace Practice_7._5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Hello 1 !";
            int numWords = CountWords(input.Trim());
            int numNums = CountNumbers(input);
            
            PrintResult(input, numWords, numNums);
        }

        private static int CountWords(string s)
        {
            int spaces = 0;

            for(int i = 0; i < s.Length; i++)
            {
                if (s[i].Equals(' '))
                {
                    spaces++;
                }
            }

            return spaces + 1;
        }

        private static int CountNumbers(string s)
        {
            string numbers = "123456789";
            int res = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (numbers.Contains(s[i]))
                {
                    res++;
                }
            }

            return res;
        }

        private static void PrintResult(string s, int words, int nums)
        {
           int others = s.Length - words - nums;
           Console.WriteLine("\"{0}\" -> Letters: {1}, Numbers: {2}, Others: {3}", s, words, nums, others);
        }
    }
}

