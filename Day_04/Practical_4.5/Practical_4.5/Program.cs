using System;

namespace Practical_4._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            int input = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < input; i++)
            {
                string thisLine = "";
                for(int j = 0; j < i; j++)
                {
                    thisLine += j % 2;
                    thisLine += " ";
                }
                Console.WriteLine(thisLine);
            }
        }
    }
}

