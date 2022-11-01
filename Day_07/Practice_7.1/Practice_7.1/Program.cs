using System;
using System.Drawing;

namespace Practice_7._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Hello, world!";
            bool vowOrCons = true; //vowel - true; consonant - false;
            string letterType;
            if (vowOrCons)
            {
                letterType = "Vowel";
            }
            else
            {
                letterType = "Consonant";
            }
            string vowels = "aeiouAEIOU";
            string consonants = "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";
            Console.WriteLine("{0} count: {1}", letterType, CountVowelsOrConsonants(input, vowOrCons, vowels, consonants));
            PrintVowelOrConsonant(input, vowOrCons, letterType, vowels, consonants);

        }

        private static int CountVowelsOrConsonants(string s, bool vowOrCons, string vowels, string consonants)
        {
            int count = 0;
            if (vowOrCons)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (vowels.Contains(s[i]))
                    {
                        count++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (consonants.Contains(s[i]))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static void PrintVowelOrConsonant(string s, bool vowOrCons, string letterType, string vowels, string consonants)
        {
            string toPrint = "";

            if (vowOrCons)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (vowels.Contains(s[i]))
                    {
                        toPrint += " " + s[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (consonants.Contains(s[i]))
                    {
                        toPrint += " " + s[i];
                    }
                }
            }
            Console.WriteLine("{0}:{1}", letterType,toPrint);
        }
    }
}

