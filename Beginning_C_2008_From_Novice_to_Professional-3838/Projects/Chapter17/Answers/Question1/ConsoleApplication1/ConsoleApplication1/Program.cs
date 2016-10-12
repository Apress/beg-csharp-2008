using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1 {
    // As much as I would love to use a .NET Generic it is not possible since
    // adding is not defined for most types
    //class Matrix<DataType> {
    class Matrix {
        double[,] _matrix;

        public Matrix(int maxX, int maxY) {
            _matrix = new double[maxX, maxY];
        }
        public double this[int x, int y] {
            get {
                if (x > _matrix.GetLength(0)) {
                    throw new ArgumentOutOfRangeException("X is too large");
                }
                if (y > _matrix.GetLength(1)) {
                    throw new ArgumentOutOfRangeException("Y is too large");
                }
                return _matrix[x, y];
            }
            set {
                if (x > _matrix.GetLength(0)) {
                    throw new ArgumentOutOfRangeException("X is too large");
                }
                if (y > _matrix.GetLength(1)) {
                    throw new ArgumentOutOfRangeException("Y is too large");
                }
                _matrix[x, y] = value;
            }
        }
        public static Matrix operator +(Matrix matrix1, Matrix matrix2) {
            if (matrix1._matrix.GetLength(0) != matrix2._matrix.GetLength(0) ||
                matrix1._matrix.GetLength(1) != matrix2._matrix.GetLength(1)) {
                throw new ArgumentException("The dimensions of matrix1 and matrix2 are not identical");
            }
            Matrix result = new Matrix( matrix1._matrix.GetLength( 0), matrix1._matrix.GetLength( 1));
            for (int x = 0; x < matrix1._matrix.GetLength(0); x++) {
                for (int y = 0; y < matrix1._matrix.GetLength(1); y++) {
                    checked {
                        result[x, y] = matrix1._matrix[x, y] + matrix2._matrix[x, y];
                    }
                }
            }
            return result;
        }
        public static Matrix operator -(Matrix matrix1, Matrix matrix2) {
            if (matrix1._matrix.GetLength(0) != matrix2._matrix.GetLength(0) ||
                matrix1._matrix.GetLength(1) != matrix2._matrix.GetLength(1)) {
                throw new ArgumentException("The dimensions of matrix1 and matrix2 are not identical");
            }
            Matrix result = new Matrix(matrix1._matrix.GetLength(0), matrix1._matrix.GetLength(1));
            for (int x = 0; x < matrix1._matrix.GetLength(0); x++) {
                for (int y = 0; y < matrix1._matrix.GetLength(1); y++) {
                    checked {
                        result[x, y] = matrix1._matrix[x, y] - matrix2._matrix[x, y];
                    }
                }
            }
            return result;
        }
    }
    class Program {
        static void Main(string[] args) {
            Matrix matrix1 = new Matrix(2, 2);
            matrix1[0, 0] = 10.0;
            matrix1[0, 1] = 20.0;
            matrix1[1, 0] = 30.0;
            matrix1[1, 1] = 40.0;

            Matrix matrix2 = new Matrix(2, 2);
            matrix2[0, 0] = 60.0;
            matrix2[0, 1] = 70.0;
            matrix2[1, 0] = 80.0;
            matrix2[1, 1] = 90.0;

            Matrix newResult = matrix1 + matrix2;
            if (newResult[0, 0] != 70.0) {
                Console.WriteLine("Error");
            }
        }
    }
}
