using System;

namespace Practice_6._6
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arr = makeArray();
            char currChar = 'a';
            //char currChar = 'z';

            Console.WriteLine("'" + currChar + "' shegvxvda " + occurance(arr, currChar) + "-jer");
            
            static char[] makeArray()
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

            static int occurance(char[] arr, char c)
            {
                int occur = 0;
                for(int i = 0; i < arr.Length; i++)
                {
                    if(c == arr[i])
                    {
                        occur++;
                    }
                }
                return occur;
            }
        }
    }
}

