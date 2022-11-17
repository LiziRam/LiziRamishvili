using System;
namespace Practice_14._1
{
    public class Square : Shape
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

        public override double Area()
        {
            return _side1 * _side2;
        }

        public override double Perimeter()
        {
            return (_side1 + _side2) * 2;
        }
    }
}

