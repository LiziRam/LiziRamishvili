using System;

namespace Practice_5._7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array row size: ");
            int rowSize = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter array column size: ");
            int colSize = Convert.ToInt32(Console.ReadLine());

            int[,] firstMatrix = new int[rowSize, colSize];
            Console.WriteLine("Fill first matrix");
            for(int i = 0; i < rowSize; i++)
            {
                for(int j = 0; j < colSize; j++)
                {
                    Console.Write("Enter number for index " + i + "," + j + ": ");
                    int currNum = Convert.ToInt32(Console.ReadLine());
                    firstMatrix[i, j] = currNum;
                }
            }
            Console.WriteLine();

            int[,] secondMatrix = new int[rowSize, colSize];
            Console.WriteLine("Fill second matrix");
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < colSize; j++)
                {
                    Console.Write("Enter number for index " + i + "," + j + ": ");
                    int currNum = Convert.ToInt32(Console.ReadLine());
                    secondMatrix[i, j] = currNum;
                }
            }

            Console.WriteLine("Here is sum of two matrices");
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < colSize; j++)
                {
                    if(j == colSize - 1)
                    {
                        Console.Write(firstMatrix[i, j] + secondMatrix[i, j]);
                    }
                    else
                    {
                        Console.Write(firstMatrix[i, j] + secondMatrix[i, j] + ", ");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}

