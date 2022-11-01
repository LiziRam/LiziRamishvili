using System;

namespace Practice_6._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = MakeArray();
            int[] minMax = GetMinMax(arr);

            Console.WriteLine("The minimum number in the array is " + minMax[0]);
            Console.WriteLine("The maximum number in the array is " + minMax[1]);
        }

        private static int[] MakeArray()
        {
            Console.Write("Enter size of array: ");
            int input = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[input];

            for (int i = 0; i < input; i++)
            {
                Console.Write("Enter integer for index " + i + ": ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            return arr;
        }

        private static int[] GetMinMax(int[] arr)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (min > arr[i])
                {
                    min = arr[i];
                }
                if (max < arr[i])
                {
                    max = arr[i];
                }
            }
            int[] res = { min, max };
            return res;
        }
    }
}

