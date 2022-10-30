using System;
using Internal;

namespace Practice_2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputYear = 2022;
            bool isLeapYear = inputYear % 4 == 0;
            Console.WriteLine(isLeapYear);
        }
    }
}

