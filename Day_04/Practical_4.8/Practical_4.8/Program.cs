using System;

namespace Practical_4._8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            int input = Convert.ToInt32(Console.ReadLine());
            int toBinary = input;
            string binary = "";
            int residual;
            while (toBinary >= 2)
            {
                residual = toBinary % 2;
                binary = residual + binary;
                toBinary = toBinary / 2;
            }
            binary = toBinary + binary;
            Console.WriteLine("decimal " + input + " in binary is " + binary);
        }
    }
}

