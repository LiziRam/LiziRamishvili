using System;

namespace Practice_6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 123, 15, 13, 23, 98 };
            int index = 2;

            Console.WriteLine("The sum of the digits of a number at index " + index + " is " + SumOfNums(arr, index));
        }

        private static int SumOfNums(int[] arr, int index)
        {
            int num = arr[index];
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num = num / 10;
            }
            return sum;
        }
    }
}

