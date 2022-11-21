using System;
namespace Practice_14._1_Interface
{
    public interface ShapeInterface
    {
        double Perimeter();
        double Area();

        double GetSide(Point a, Point b);
    }
}

