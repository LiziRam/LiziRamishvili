using System;

namespace Practice_6._9
{
    class Program
    {
        static void Main(string[] args)
        {
            int product = productElems(new int[] { 1, 3, 4, 15, 13, 23, 98 });
            Console.WriteLine("The product of array element is: " + product);

            static int productElems(params int[] elems)
            {
                int prod = 1;
                foreach(int elem in elems)
                {
                    prod *= elem;
                }
                return prod;
            }
        }
    }
}

