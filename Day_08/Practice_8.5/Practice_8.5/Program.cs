using System;

namespace Practice_8._5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = "ABKBA";
            Console.WriteLine($"Is palindrome? {IsPalindrome(input1, input1.Length - 1)}");
        }

        private static bool IsPalindrome(string str1, int index1, int index2 = 0, bool palindrome = true)
        {
            if (index1 == 0)
            {
                return palindrome;
            }
            if (str1[index1] != str1[index2])
            {
                palindrome = false;
            }
            return IsPalindrome(str1, index1 - 1, index2 + 1, palindrome);
        }
    }
}

