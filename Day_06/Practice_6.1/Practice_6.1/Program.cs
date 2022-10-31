using System;

namespace Practice_6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 4, 15, 13, 23, 98 };

            int index = 4;

            Console.WriteLine("Number at index " + index + " is " + secondIndex(arr, index));

            static int secondIndex(int[] arr, int index)
            {
                return arr[index];
            }
        }
    }
}

