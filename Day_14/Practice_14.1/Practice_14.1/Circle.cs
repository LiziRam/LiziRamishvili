using System;
namespace Practice_14._1
{
    public class Circle : Shape
    {
        private double _radius;

        public Circle()
        {
            Center  = new Point();
            CirclePoint  = new Point();
        }

        public void CalculateRadius()
        {
            _radius = GetSide(Center, CirclePoint);
        }

        public Point Center { get; set; }
        public Point CirclePoint { get; set; }

        public override double Area()
        {
            return Math.PI * _radius * _radius;
        }

        public override double Perimeter()
        {
            return Math.PI * 2 * _radius;
        }
    }
}

