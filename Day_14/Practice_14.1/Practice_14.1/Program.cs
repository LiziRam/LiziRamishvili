using System;
using Practice_14._1;

internal class Program
{
    static void Main(string[] args)
    {
        Triangle t = new Triangle();
        Console.Write("Enter x coordinate of a triangle's first point: ");
        t.A.X = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter y coordinate of a triangle's first point: ");
        t.A.Y = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter x coordinate of a triangle's second point: ");
        t.B.X = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter y coordinate of a triangle's second point: ");
        t.B.Y = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter x coordinate of a triangle's third point: ");
        t.C.X = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter y coordinate of a triangle's third point: ");
        t.C.Y = Convert.ToInt32(Console.ReadLine());
        t.CalculateSides();

        Square sqr = new Square();
        Console.Write("Enter x coordinate of a square's first point: ");
        sqr.A.X = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter y coordinate of a squre's first point: ");
        sqr.A.Y = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter x coordinate of a square's second point: ");
        sqr.B.X = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter y coordinate of a square's second point: ");
        sqr.B.Y = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter x coordinate of a square's third point: ");
        sqr.C.X = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter y coordinate of a square's third point: ");
        sqr.C.Y = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter x coordinate of a square's fourth point: ");
        sqr.D.X = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter y coordinate of a square's fourth point: ");
        sqr.D.Y = Convert.ToInt32(Console.ReadLine());
        sqr.CalculateSides();

        Circle c = new Circle();
        Console.Write("Enter x coordinate of a circle's center: ");
        c.Center.X = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter y coordinate of a circle's center: ");
        c.Center.Y = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter x coordinate of a circles's point: ");
        c.CirclePoint.X = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter y coordinate of a circle's point: ");
        c.CirclePoint.Y = Convert.ToInt32(Console.ReadLine());
        c.CalculateRadius();

        Shape[] shapesArr = new Shape[3];
        shapesArr[0] = t;
        shapesArr[1] = sqr;
        shapesArr[2] = c;

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Perimeter of shape N{i + 1} is: {shapesArr[i].Perimeter()}");
            Console.WriteLine($"Area of shape N{i + 1} is: {shapesArr[i].Area()}");
        }
    }
}

