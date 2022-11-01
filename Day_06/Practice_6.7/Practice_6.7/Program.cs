using System;

namespace Practice_6._7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = GetSize();
            int rowSize = sizes[0];
            int colSize = sizes[1];
            PrintSpaceBetween();

            int[,] matrix1 = GetMatrix(rowSize, colSize);
            PrintSpaceBetween();
            int[,] matrix2 = GetMatrix(rowSize, colSize);
            PrintSpaceBetween();

            int[,] sumMatrix = GetSumMatrix(matrix1, matrix2);
            PrintSumMatrix(sumMatrix);
        }

        private static int[] GetSize()
        {
            Console.Write("Enter count of rows: ");
            int rowSize = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter count of columns: ");
            int colSize = Convert.ToInt32(Console.ReadLine());

            int[] arr = { rowSize, colSize };
            return arr;
        }

        private static void PrintSpaceBetween()
        {
            Console.WriteLine();
            for (int i = 0; i < 30; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static int[,] GetMatrix(int rowSize, int colSize)
        {
            int[,] matrix = new int[rowSize, colSize];
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < colSize; j++)
                {
                    Console.Write("Enter integer for index " + i + "," + j + ": ");
                    int currNum = Convert.ToInt32(Console.ReadLine());
                    matrix[i, j] = currNum;
                }
            }
            return matrix;
        }

        private static int[,] GetSumMatrix(int[,] a, int[,] b)
        {
            int[,] matrix = new int[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    matrix[i, j] = a[i, j] + b[i, j];
                }
            }
            return matrix;
        }

        private static void PrintSumMatrix(int[,] m)
        {
            Console.WriteLine("Here is sum of matrices");
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (j == m.GetLength(1) - 1)
                    {
                        Console.Write(m[i, j]);
                    }
                    else
                    {
                        Console.Write(m[i, j] + ", ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}

