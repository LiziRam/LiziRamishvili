using System;

namespace Practice_5._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int inputSize = Convert.ToInt32(Console.ReadLine());
            int currInput;
            int[] ourArray = new int[inputSize];
            int product = 1;
            for (int i = 0; i < inputSize; i++)
            {
                Console.Write("Enter number for index " + i + ": ");
                currInput = Convert.ToInt32(Console.ReadLine());
                ourArray[i] = currInput;
                product *= currInput;
            }

            Console.WriteLine("Product of array elements is " + product);
        }
    }
}




