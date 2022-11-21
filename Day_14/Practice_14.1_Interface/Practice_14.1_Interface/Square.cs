using System;
namespace Practice_14._1_Interface
{
    public class Square : ShapeInterface
    {
        private double _side1;
        private double _side2;

        public Square()
        {
            A = new Point();
            B = new Point();
            C = new Point();
            D = new Point();
        }

        public void CalculateSides()
        {
            _side1 = GetSide(A, B);
            _side2 = GetSide(B, C);
        }

        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Point D { get; set; }

        public double Area()
        {
            return _side1 * _side2;
        }

        public double GetSide(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2));
        }

        public double Perimeter()
        {
            return (_side1 + _side2) * 2;
        }

        

        

    }
}

