using System;
namespace Practice_14._1
{
    public class Triangle : Shape
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

        public override double Area()
        {
            double S = Perimeter() / 2;
            return Math.Sqrt(S * (S - _side1) * (S - _side2) * (S - _side3));
        }

        public override double Perimeter()
        {
            return _side1 + _side2 + _side3;
        }
    }
}

