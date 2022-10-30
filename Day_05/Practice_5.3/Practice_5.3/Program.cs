using System;

namespace Practice_5._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int inputSize = Convert.ToInt32(Console.ReadLine());
            int currInput;
            int[] ourArray = new int[inputSize];
            int sum = 0;
            for (int i = 0; i < inputSize; i++)
            {
                Console.Write("Enter number for index " + i + ": ");
                currInput = Convert.ToInt32(Console.ReadLine());
                ourArray[i] = currInput;
                sum += currInput;
            }

            Console.WriteLine("Sum of array elements is " + sum);
        }
    }
}




