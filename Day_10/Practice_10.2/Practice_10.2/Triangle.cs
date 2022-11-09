using System;
namespace Practice_10._2
{
    class Triangle
    {
        int _side1;
        int _side2;
        int _side3;
        
        public int Side1
        {
            get
            {
                return _side1;
            }
            set
            {
                if(value > 0)
                {
                    _side1 = value;
                }
            }
        }

        public int Side2
        {
            get
            {
                return _side2;
            }
            set
            {
                if (value > 0)
                {
                    _side2 = value;
                }
            }
        }
        

        public int Side3
        {
            get
            {
                return _side3;
            }
            set
            {
                if (value > 0 && Side1 + Side2 > value && Side2 + value > Side1 && Side1 + value > Side2)
                {
                    _side3 = value;
                }
            }
        }

        public int Perimeter(int a, int b, int c)
        {
            return a + b + c;
        }

        public double Area(int a, int b, int c)
        {
            double semiP = Perimeter(a, b, c) / 2;
            return Math.Sqrt(semiP * (semiP - a) * (semiP - b) * (semiP - c));
        }

    }
}

