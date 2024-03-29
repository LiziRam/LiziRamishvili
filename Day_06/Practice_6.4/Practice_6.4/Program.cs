﻿using System;

namespace Practice_6._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = MakeArray();
            double arithmAvg = CalculateAvg(arr);

            Console.WriteLine("Arithmetic average of array is " + arithmAvg);

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

        private static double CalculateAvg(int[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum / arr.Length;
        }
    }
}


