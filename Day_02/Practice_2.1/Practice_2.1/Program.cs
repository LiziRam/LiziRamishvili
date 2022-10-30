using System;
using Internal;

namespace Practice_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //With third variable
            Console.WriteLine("Swap values using third variable");
            int A = 5;
            int B = 7;
            Console.WriteLine(A);
            Console.WriteLine(B);
            //Keep value of A in a dummy integer
            int dummy = A;
            //Swap values
            A = B;
            B = dummy;
            Console.WriteLine(A);
            Console.WriteLine(B);

            Console.WriteLine();

            //Without third variable
            Console.WriteLine("Swap values without using third variable");
            int C = 6;
            int D = 8;
            Console.WriteLine(C);
            Console.WriteLine(D);
            C = C * D;
            D = C / D;
            C = C / D;

            Console.WriteLine(C);
            Console.WriteLine(D);
        }
    }
}

