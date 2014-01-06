using System;

namespace _08_10_Matrix
{
    public class Matrix<T>
    {
        T [,] Value { get; set; }

        public Matrix(int dimN) // square matrix constructor
        {
            this.Value = new T [dimN, dimN];
        }

        public Matrix(int dimN, int dimM) // rectangular matrix constructor
        {
            this.Value = new T [dimN, dimM];
        }

        public Matrix(int dimN, int dimM, T val) // rectangular matrix constructor with assign value for all elements
        {
            this.Value = new T [dimN, dimM];
            for (int r = 0; r < dimN; r++)
                for (int c = 0; c < dimM; c++)
                {
                    this.Value[r, c] = val;
                }
        }

        public T this[int row, int col] // content access overloaded operator
        {
            get // invoked when asks for value of matrix certain matrix element
            {
                return this.Value[row, col];
            }

            set // invoked when puts value into the matrix content
            {
                this.Value[row, col] = value;
            }
        }

        public override string ToString() // string representation overloaded method - formats matrix as {{1, 2, ... , M}, ... ,{M*N-M, M*N-M-1, ... , M*N}} 
        {
            string result = "{ ";

            for (int r = 0; r < this.Value.GetLength(0); r++)
            {
                result += "{ ";
                for (int c = 0; c < this.Value.GetLength(1); c++)
                {
                    result += this.Value[r, c] + ((c < this.Value.GetLength(1) - 1) ? ", " : " ");
                }
                result += (r < this.Value.GetLength(0) - 1) ? "},\r\n  " : "} }\r\n";
            }
            return result.ToString();
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.Value.GetLength(0) != second.Value.GetLength(0) ||
                first.Value.GetLength(1) != second.Value.GetLength(1)) // if the input matrices are not equal 
            {
                throw new ArgumentOutOfRangeException();  // throws exception
            }
            Matrix<T> result = new Matrix<T>(first.Value.GetLength(0), first.Value.GetLength(1));

            for (int r = 0; r < first.Value.GetLength(0); r++)
                for (int c = 0; c < first.Value.GetLength(1); c++)
                {
                    result.Value[r, c] = (T)((dynamic)first.Value[r, c] + (dynamic)second.Value[r, c]);
                }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.Value.GetLength(0) != second.Value.GetLength(0) ||
                first.Value.GetLength(1) != second.Value.GetLength(1)) // if the input matrices are not equal 
            {
                throw new ArgumentOutOfRangeException();  // throws exception
            }
            Matrix<T> result = new Matrix<T> (first.Value.GetLength(0), first.Value.GetLength(1));

            for (int r = 0; r < first.Value.GetLength(0); r++)
                for (int c = 0; c < first.Value.GetLength(1); c++)
                {
                    result.Value[r, c] = (T)((dynamic)first.Value[r, c] - (dynamic)second.Value[r, c]);
                }
            return result;
        }

        public static Matrix<T> operator * (Matrix<T> first, Matrix<T> second)
        {
            if (first.Value.GetLength(1) != second.Value.GetLength(0)) // if the input matrices are not equal, i.e. first columns == second rows 
            {
                throw new ArgumentOutOfRangeException(); // throws exception
            }
            Matrix<T> result = new Matrix<T> (first.Value.GetLength(0), second.Value.GetLength(1)); // creates new matrix (first rows) X (second columns) 

            for (int r = 0; r < result.Value.GetLength(0); r++) // iterates through all elements of result matrix
                for (int c = 0; c < result.Value.GetLength(1); c++)
                {
                    dynamic sum = 0;
                    for (int idx = 0; idx < first.Value.GetLength(1); idx++) // iterates through each entire first column/second row 
                    {
                        sum += (dynamic)first.Value[r, idx] * (dynamic)second.Value[idx, c]; ; // sum of multiplies of elements of each first column*second row
                    }
                    result.Value[r, c] = (T)sum;
                }
            return result;
        }

        public static bool operator true(Matrix<T> param)
        {
            for (int r = 0; r < param.Value.GetLength(0); r++)
                for (int c = 0; c < param.Value.GetLength(1); c++)
                {
                    if ((dynamic)param.Value[r, c] != 0) return true;
                }
            return false;
        }

        public static bool operator false(Matrix<T> param)
        {
            for (int r = 0; r < param.Value.GetLength(0); r++)
                for (int c = 0; c < param.Value.GetLength(1); c++)
                {
                    if ((dynamic)param.Value[r, c] != 0) return false;
                }
            return true;
        }
    }
}
