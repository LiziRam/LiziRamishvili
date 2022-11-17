using System;
namespace Practice_14._1_Interface
{
    public class Triangle : ShapeInterface
    {
        private double _side1;
        private double _side2;
        private double _side3;

        public Triangle()
        {
            A = new Point();
            B = new Point();
            C = new Point();
        }

        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public void CalculateSides()
        {
            _side1 = GetSide(A, B);
            _side2 = GetSide(B, C);
            _side3 = GetSide(A, C);
        }

        public double Area()
        {
            double S = Perimeter() / 2;
            return Math.Sqrt(S * (S - _side1) * (S - _side2) * (S - _side3));
        }

        public double GetSide(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2));
        }

        public double Perimeter()
        {
            return _side1 + _side2 + _side3;
        }
    }
}

