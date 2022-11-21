using System;
namespace Practice_15._1
{
    public class Matrix
    {
        private double[,] _matrix;

        public Matrix(double n1, double n2, double n3, double n4)
        {
            _matrix = new double[2, 2] { { n1, n2 }, { n3, n4 } };
        }

        public double this[int i, int j]
        {
            get
            {
                return _matrix[i, j];
            }
            set
            {
                _matrix[i, j] = value;
            }
        }

        public static implicit operator double(Matrix matrix)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            return new Matrix(m1[0, 0] + m2[0, 0], m1[0, 1] + m2[0, 1], m1[1, 0] + m2[1, 0], m1[1, 1] + m2[1, 1]);
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            return new Matrix(m1[0, 0] - m2[0, 0], m1[0, 1] - m2[0, 1], m1[1, 0] - m2[1, 0], m1[1, 1] - m2[1, 1]);
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            return new Matrix(m1[0, 0] * m2[0, 0] + m1[0, 1] * m2[1,0], m1[0, 0] * m2[0, 1] + m1[0, 1] * m2[1, 1],
                m1[1,0] * m2[0,0] + m1[1,1] * m2[1,0], m1[1,0] * m2[0,1] + m1[1,1] * m2[1,1]);
        }

        public static Matrix operator -(Matrix matrix)
        {
            double d = matrix; 
            return new Matrix(matrix[1, 1] * 1 / d, matrix[0, 1] * -1 / d, matrix[1, 0] * -1 / d, matrix[0, 0] * 1/d);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Matrix);
        }

        public bool Equals(Matrix other)
        {
            return _matrix[0, 0] == other[0, 0] && _matrix[0, 1] == other[0, 1] && _matrix[1, 0] == other[1, 0] && _matrix[1, 1] == other[1, 1];
        }

        public override string ToString()
        {
            return ($"{_matrix[0, 0]}  {_matrix[0, 1]} \n{_matrix[1, 0]}  {_matrix[1, 1]}");
        }
    }
}

