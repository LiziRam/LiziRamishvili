using System;
namespace Practice_16
{
	public class VectorMathOperation : IMathOperation<Vector>
	{
        public Vector Add(Vector v1, Vector v2)
        {
            return v1 + v2;
        }

        public Vector Subtract(Vector v1, Vector v2)
        {
            return v1 - v2;
        }

        public Vector Multiply(Vector v1, Vector v2)
        {
            return v1 * v2;
        }
    }
}

