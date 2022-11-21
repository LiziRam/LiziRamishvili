using System;

namespace Practice_15._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"Enter a number for [0,0] place in firts matrix: ");
            double input1 = Convert.ToDouble(Console.ReadLine());
            Console.Write($"Enter a number for [0,1] place in firts matrix: ");
            double input2 = Convert.ToDouble(Console.ReadLine());
            Console.Write($"Enter a number for [1,0] place in firts matrix: ");
            double input3 = Convert.ToDouble(Console.ReadLine());
            Console.Write($"Enter a number for [1,1] place in firts matrix: ");
            double input4 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();
            Matrix matrix1 = new Matrix(input1, input2, input3, input4);
            Console.WriteLine("The first matrix looks like this:");
            Console.WriteLine(matrix1.ToString());

            Console.Write($"Enter a number for [0,0] place in second matrix: ");
            double input5 = Convert.ToDouble(Console.ReadLine());
            Console.Write($"Enter a number for [0,1] place in second matrix: ");
            double input6 = Convert.ToDouble(Console.ReadLine());
            Console.Write($"Enter a number for [1,0] place in second matrix: ");
            double input7 = Convert.ToDouble(Console.ReadLine());
            Console.Write($"Enter a number for [1,1] place in second matrix: ");
            double input8 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();
            Matrix matrix2 = new Matrix(input5, input6, input7, input8);
            Console.WriteLine("The second matrix looks like this:");
            Console.WriteLine(matrix2.ToString());

            double d1 = matrix1; 
            Console.WriteLine();
            Console.WriteLine($"Determinant of the first matrix is {d1}");
            double d2 = matrix2; 
            Console.WriteLine();
            Console.WriteLine($"Determinant of the second matrix is {d2}");

            Matrix matrix3 = matrix1 + matrix2;
            Console.WriteLine();
            Console.WriteLine("Sum of those matrices:");
            Console.WriteLine(matrix3.ToString());

            matrix3 = matrix1 - matrix2;
            Console.WriteLine();
            Console.WriteLine("Difference of those matrices:");
            Console.WriteLine(matrix3.ToString());

            matrix3 = matrix1 * matrix2;
            Console.WriteLine();
            Console.WriteLine("Product of those matrices:");
            Console.WriteLine(matrix3.ToString());

            matrix3 = -matrix1;
            Console.WriteLine();
            Console.WriteLine("Inverse of this matrix:");
            Console.WriteLine(matrix3.ToString());

            bool doesEqual = matrix1.Equals(matrix2);
            Console.WriteLine($"First and second matrices are equal -> {doesEqual}");
        }


    }
}

