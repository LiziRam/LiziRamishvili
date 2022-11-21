using System;

namespace Practice_15._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the length of the first side of a triangle: ");
            double side1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the length of the second side of a triangle: ");
            double side2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the length of the third side of a triangle: ");
            double side3 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Creating new triangle... Sides: {side1}, {side2}, {side3}.");
            Triangle tr = new Triangle(side1, side2, side3);

            Console.WriteLine($"Area of the first triangle is {tr.Area()}");
            Console.WriteLine($"Perimeter of the first triangle is {tr.Perimeter()}");

            Console.WriteLine();
            Console.Write("Enter double to cast and create an equilateral triangle: ");
            double side = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Creating new triangle... Sides: {side}, {side}, {side}.");
            Triangle equiliteralTriangle = (Triangle)side;

            Console.WriteLine($"Area of the first triangle is {equiliteralTriangle.Area()}");
            Console.WriteLine($"Perimeter of the first triangle is {equiliteralTriangle.Perimeter()}");

            Console.WriteLine($"First and second triangles are equal -> {tr == equiliteralTriangle}");
            Console.WriteLine($"First triangle is larger than the second -> {tr > equiliteralTriangle}");

            Console.WriteLine();
            Console.WriteLine($"Creating new triangle...");
            Triangle newTr = tr + equiliteralTriangle;
            Console.WriteLine($"Area of the new triangle is {newTr.Area()}");
            Console.WriteLine($"Perimeter of the new triangle is {newTr.Perimeter()}");
            Console.WriteLine($"New triangle is larger than the first -> {newTr > tr}");
        }
    }
}

