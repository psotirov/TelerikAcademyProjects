using System;
using System.Collections.Generic;
using System.Text;

public class Matrix
{
    int[,] Value {get; set;}

    public Matrix(int dimN) // square matrix constructor
    {
        this.Value = new int[dimN, dimN];
    }

    public Matrix(int dimN, int dimM) // rectangular matrix constructor
    {
        this.Value = new int[dimN, dimM];
    }

    public Matrix(int dimN, int dimM, int val) // rectangular matrix constructor with assign value for all elements
    {
        this.Value = new int[dimN, dimM];
        for (int r = 0; r < dimN; r++)
            for (int c = 0; c < dimM; c++)
            {
                this.Value[r, c] = val;
            }
    }

    public int this[int row, int col] // content access overloaded operator
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
        StringBuilder result = new StringBuilder("{ ");

        for (int r = 0; r < this.Value.GetLength(0); r++)
        {
            result.Append("{ ");
            for (int c = 0; c < this.Value.GetLength(1); c++)
            {
                result.Append(this.Value[r,c] + ((c < this.Value.GetLength(1) - 1)?", ":" "));
            }
            result.Append((r < this.Value.GetLength(0) - 1) ? "},\r\n  " : "} }\r\n");
        }
        return result.ToString();
    }

    public static Matrix operator + (Matrix first, Matrix second)
    {
        if (first.Value.GetLength(0) != second.Value.GetLength(0) ||
            first.Value.GetLength(1) != second.Value.GetLength(1)) // if the input matrices are not equal 
        {
            throw new ArgumentOutOfRangeException();  // throws exception
        }
        Matrix result = new Matrix(first.Value.GetLength(0), first.Value.GetLength(1));

        for (int r = 0; r < first.Value.GetLength(0); r++)
            for (int c = 0; c < first.Value.GetLength(1); c++)
            {
                result.Value[r, c] = first.Value[r, c] + second.Value[r, c];
            }
        return result;
    }

    public static Matrix operator -(Matrix first, Matrix second)
    {
        if (first.Value.GetLength(0) != second.Value.GetLength(0) ||
            first.Value.GetLength(1) != second.Value.GetLength(1)) // if the input matrices are not equal 
        {
            throw new ArgumentOutOfRangeException();  // throws exception
        }
        Matrix result = new Matrix(first.Value.GetLength(0), first.Value.GetLength(1));

        for (int r = 0; r < first.Value.GetLength(0); r++)
            for (int c = 0; c < first.Value.GetLength(1); c++)
            {
                result.Value[r, c] = first.Value[r, c] - second.Value[r, c];
            }
        return result;
    }

    public static Matrix operator *(Matrix first, Matrix second)
    {
        if (first.Value.GetLength(1) != second.Value.GetLength(0)) // if the input matrices are not equal, i.e. first columns == second rows 
        {
            throw new ArgumentOutOfRangeException(); // throws exception
        }
        Matrix result = new Matrix(first.Value.GetLength(0), second.Value.GetLength(1)); // creates new matrix (first rows) X (second columns) 

        for (int r = 0; r < result.Value.GetLength(0); r++) // iterates through all elements of result matrix
            for (int c = 0; c < result.Value.GetLength(1); c++)
            {
                int sum = 0;
                for (int idx = 0; idx < first.Value.GetLength(1); idx++) // iterates through each entire first column/second row 
                {
                    sum += first.Value[r, idx] * second.Value[idx, c]; // sum of multiplies of elements of each first column*second row
                }
                result.Value[r, c] = sum;
            }
        return result;
    }
}

class SortStringsByLength
{
    static void Main()
    {
        Console.WriteLine("Task 06 - Matrix class implementation\n\n");

        Matrix first = new Matrix(5, 6); // empty matrix 5 x 6
        Console.WriteLine("First Matrix (empty):\n\n" + first);

        for (int r = 0; r < 5; r++)
            for (int c = 0; c < 6; c++)
            {
                first[r, c] = r * 6 + c; // fill with consecutive numbers        
            }

        Console.WriteLine("Filled wit consecutive numbers:\n\n" + first);

        Matrix second = new Matrix(5, 6, 2); // matrix 5 x 6, filled with value 2
        Console.WriteLine("Second Matrix:\n\n" + second);
        Console.WriteLine("Result of First + Second:\n\n" + (first + second)); // sum

        Console.WriteLine("Result of First - Second:\n\n" + (first - second)); // subtract
        Matrix third = new Matrix(6, 8, 3);
        Console.WriteLine("Third Matrix:\n\n" + third); // matrix 6 x 8, filled with vaue 3
        Console.WriteLine("Result of First * Third:\n\n" + (first * third)); // multiply matrices 5x6 * 6x8 = 5x8
        Console.WriteLine("Result of First * First:\n\n" + (first * first)); // multiply matrices 5x6 * 6x8 = 5x8


        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}