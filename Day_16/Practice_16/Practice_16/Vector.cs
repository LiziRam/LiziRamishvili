using System;
namespace Practice_16
{
	public class Vector
	{
        public Vector(double abscissa, double ordinate, double applicate)
        {
            Abscissa = abscissa;
            Ordinate = ordinate;
            Applicate = applicate;
        }

        public double Abscissa { get; set; }
        public double Ordinate { get; set; }
        public double Applicate { get; set; }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.Abscissa + v2.Abscissa, v1.Ordinate + v2.Ordinate, v1.Applicate + v2.Applicate);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.Abscissa - v2.Abscissa, v1.Ordinate - v2.Ordinate, v1.Applicate - v2.Applicate);
        }

        //cross product of two vectors: (x1, y1, z1) * (x2, y2, z2) =
        //(y1 * z2 - z1 * y2), (z1 * x2 - x1 * z2), (x1 * y2 - y1 * x2)
        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(v1.Ordinate * v2.Applicate - v1.Applicate * v2.Ordinate,
                v1.Applicate * v2.Abscissa - v1.Abscissa * v2.Applicate, v1.Abscissa * v2.Ordinate - v1.Ordinate * v2.Abscissa);
        }


        public override string ToString()
        {
            return $"x: {Abscissa} y: {Ordinate} z: {Applicate}";
        }
    }
}

