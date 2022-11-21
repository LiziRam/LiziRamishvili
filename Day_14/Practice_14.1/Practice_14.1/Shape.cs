using System;
namespace Practice_14._1
{
    public abstract class Shape
    {
        public abstract double Perimeter();
        public abstract double Area();

        public double GetSide(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2));
        }
    }
}

