using System;
namespace Practice_15._2
{
    public class Triangle
    {

        public Triangle(double side1, double side2, double side3)
        {
            if(side1 + side2 > side3 && side2 + side3 > side1 && side3 + side1 > side2
                && side1 > 0 && side2 > 0 && side3 > 0)
            {
                A = side1;
                B = side2;
                C = side3;
            }
            else 
            {
                Console.WriteLine("Invalid sides for triangle");
            }
        }

        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public double Area()
        {
            double semiPer = (A + B + C) / 2;
            return Math.Sqrt(semiPer * (semiPer - A) * (semiPer - B) * (semiPer - C));
        }

        public double Perimeter()
        {
            return A + B + C;
        }

        public static bool operator ==(Triangle tr1, Triangle tr2)
        {
            return tr1.Area() == tr2.Area();
        }

        public static bool operator !=(Triangle tr1, Triangle tr2)
        {
            return !(tr1 == tr2);
        }

        public static bool operator <(Triangle tr1, Triangle tr2)
        {
            return tr1.Area() < tr2.Area();
        }

        public static bool operator >(Triangle tr1, Triangle tr2)
        {
            return tr2 < tr1 && tr1 != tr2;
        }

        public static Triangle operator +(Triangle tr1, Triangle tr2)
        {
            double sumArea = tr1.Area() + tr2.Area();
            //(a * a) / 2 = sumArea
            double a = Math.Sqrt(sumArea * 2);
            //a^2 + a^2 = hip^2
            double hip = Math.Sqrt(a * a * 2);
            return new Triangle(a, a, hip);
        }

        public static explicit operator Triangle(double a)
        {
            return new Triangle(a, a, a);
        }
    }
}

