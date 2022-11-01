using System;

namespace Practice_6._6
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arr = MakeArray();
            char currChar = 'a';
            //char currChar = 'z';

            Console.WriteLine("'" + currChar + "' shegvxvda " + Occurance(arr, currChar) + "-jer");
        }

        private static char[] MakeArray()
        {
            Console.Write("Enter size of array: ");
            int input = Convert.ToInt32(Console.ReadLine());
            char[] arr = new char[input];

            for (int i = 0; i < input; i++)
            {
                Console.Write("Enter character for index " + i + ": ");
                arr[i] = Convert.ToChar(Console.ReadLine());
            }
            return arr;
        }

        private static int Occurance(char[] arr, char c)
        {
            int occur = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (c == arr[i])
                {
                    occur++;
                }
            }
            return occur;
        }
    }
}

