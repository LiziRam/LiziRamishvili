using System;

namespace Practice_16
{
    class Program
    {
        static void Main(string[] args)
        {
            //Matrix
            Matrix matrix1 = new Matrix(1, 2, 3, 4);
            Console.WriteLine("The first matrix looks like this:");
            Console.WriteLine(matrix1.ToString());

            Console.WriteLine();
            Matrix matrix2 = new Matrix(1, 2, 2, 3);
            Console.WriteLine("The second matrix looks like this:");
            Console.WriteLine(matrix2.ToString());

            MatrixMathOperation mathMatrix = new MatrixMathOperation();
            Matrix matrix3 = mathMatrix.Add(matrix1, matrix2);
            Console.WriteLine();
            Console.WriteLine("Add two matrices:");
            Console.WriteLine(matrix3);

            matrix3 = mathMatrix.Subtract(matrix1, matrix2);
            Console.WriteLine();
            Console.WriteLine("Subtract two matrices:");
            Console.WriteLine(matrix3);

            matrix3 = mathMatrix.Multiply(matrix1, matrix2);
            Console.WriteLine();
            Console.WriteLine("Multiply two matrices:");
            Console.WriteLine(matrix3);

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();

            //Vector
            Vector vector1 = new Vector(1, 2, 3);
            Console.WriteLine("The first Vector looks like this:");
            Console.WriteLine(vector1);

            Console.WriteLine();
            Vector vector2 = new Vector(4, 5, 6);
            Console.WriteLine("The second Vector looks like this:");
            Console.WriteLine(vector2);

            VectorMathOperation mathVect = new VectorMathOperation();
            Vector vector3 = mathVect.Add(vector1, vector2);
            Console.WriteLine();
            Console.WriteLine("Add two vectors:");
            Console.WriteLine(vector3);

            vector3 = mathVect.Subtract(vector1, vector2);
            Console.WriteLine();
            Console.WriteLine("Subtract two vectors:");
            Console.WriteLine(vector3);

            vector3 = mathVect.Multiply(vector1, vector2);
            Console.WriteLine();
            Console.WriteLine("Multiply two vectors:");
            Console.WriteLine(vector3);

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();

            //int
            int n1 = 5;
            Console.WriteLine($"The first number is {n1}");

            Console.WriteLine();
            int n2 = 7;
            Console.WriteLine($"The second number is {n2}");

            IntMathOperation intMath = new IntMathOperation();
            int n3 = intMath.Add(n1, n2);
            Console.WriteLine();
            Console.WriteLine($"Sum of two numbers is {n3}");

            n3 = intMath.Subtract(n1, n2);
            Console.WriteLine();
            Console.WriteLine($"Difference of two numbers is {n3}");

            n3 = intMath.Multiply(n1, n2);
            Console.WriteLine();
            Console.WriteLine($"Product of two numbers is {n3}");
        }
    }
}

