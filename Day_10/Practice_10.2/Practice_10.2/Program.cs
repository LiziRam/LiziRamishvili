using System;

namespace Practice_10._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle();
            Console.Write("Enter side 1: ");
            triangle.Side1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter side 2: ");
            triangle.Side2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter side 3: ");
            triangle.Side3 = Convert.ToInt32(Console.ReadLine());

            if(triangle.Side3 != 0)
            {
                Console.WriteLine($"Perimeter of the triangle is: {triangle.Perimeter(triangle.Side1, triangle.Side2, triangle.Side3)}");
                Console.WriteLine($"Area of the triangle is: {triangle.Area(triangle.Side1, triangle.Side2, triangle.Side3)}");
            }
            else
            {
                Console.WriteLine("It is not valid triangle");
            }
        }
    }
}

