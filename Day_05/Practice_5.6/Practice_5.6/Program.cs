using System;

namespace Practice_5._6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array row size: ");
            int inputRowSize = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter array column size: ");
            int inputColSize = Convert.ToInt32(Console.ReadLine());

            int[,] array2d = new int[inputRowSize, inputColSize];
            for(int i = 0; i < inputRowSize; i++)
            {
                for(int j = 0; j < inputColSize; j++)
                {
                    Console.Write("Enter number for index " + i + "," + j + ": ");
                    int currNum = Convert.ToInt32(Console.ReadLine());
                    array2d[i, j] = currNum;
                }
            }

            Console.WriteLine("Here is matrix view of multidimensional array");
            for (int i = 0; i < inputRowSize; i++)
            {
                for (int j = 0; j < inputColSize; j++)
                {
                    Console.Write(array2d[i, j] + ", ");
                }
                Console.WriteLine();
            }
        }
    }
}

