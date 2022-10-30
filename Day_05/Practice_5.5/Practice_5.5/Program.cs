using System;

namespace Practice_5._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int inputSize = Convert.ToInt32(Console.ReadLine());
            int currInput;
            int[] ourArray = new int[inputSize];
            for (int i = 0; i < inputSize; i++)
            {
                Console.Write("Enter number for index " + i + ": ");
                currInput = Convert.ToInt32(Console.ReadLine());
                ourArray[i] = currInput;
            }

        Console.WriteLine("Unique elements of array are");
            for (int i = 0; i < inputSize; i++)
            {
                bool isUnique = true;
                for (int j = 0; j < inputSize; j++)
                {
                    if (ourArray[i] == ourArray[j] && j != i)
                    {
                        isUnique = false;
                    }
                }
                if (isUnique)
                {
                    Console.WriteLine(ourArray[i]);
                }
            }

        }
    }
}

