using System;
namespace Practice_16
{
	public class MatrixMathOperation : IMathOperation<Matrix>
	{
        public Matrix Add(Matrix m1, Matrix m2)
        {
            return m1 + m2;
        }

        public Matrix Subtract(Matrix m1, Matrix m2)
        {
            return m1 - m2;
        }

        public Matrix Multiply(Matrix m1, Matrix m2)
        {
            return m1 * m2;
        }
    }
}

