using System;
namespace Practice_14._1_Interface
{
    public class Circle : ShapeInterface
    {

        private double _radius;

        public Circle()
        {
            Center = new Point();
            CirclePoint = new Point();
        }

        public void CalculateRadius()
        {
            _radius = GetSide(Center, CirclePoint);
        }

        public Point Center { get; set; }
        public Point CirclePoint { get; set; }

        public double Area()
        {
            return Math.PI * _radius * _radius;
        }

        public double GetSide(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2));
        }

        public double Perimeter()
        {
            return Math.PI * 2 * _radius;
        }
    }
}

