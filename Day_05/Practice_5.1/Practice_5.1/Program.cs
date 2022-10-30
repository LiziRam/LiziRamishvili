using System;

namespace Practical_4._8
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

            Console.WriteLine("Here is your array!");
            for (int i = 0; i < inputSize; i++)
            {
                Console.WriteLine(ourArray[i]);
            }
        }
    }
}
