using System;
using System.Text;

namespace Matrix
{
    /// <summary>
    /// Creates and prints square matrix, filled with numbers using Rotating Walk algorithm
    /// </summary>
    /// <remarks>
    /// I have decided to implement single class with straight code
    /// The task is too small, very tight coupled and makes single job
    /// that is why implementing of deep OOP will increase unnnecessarily the overall complexity
    /// /// </remarks>
    public class RotatingWalk
    {
        private static readonly int[] rowDirection = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static readonly int[] columnDirection = { 1, 0, -1, -1, -1, 0, 1, 1 };
        private static int[,] matrix;
        private static int currentValue;

        public static void Main()
        {
        #if DEBUG
            Console.WriteLine("Enter matrix dimension N: ");
        #endif

            string input = Console.ReadLine();
            int dimensionN = 0;
            if (!int.TryParse(input, out dimensionN) || 
                dimensionN < 1 || dimensionN > 100)
            {
                throw new ArgumentOutOfRangeException("Matrix dimension is outside the permittable range");
            }

            matrix = new int[dimensionN, dimensionN];
            currentValue = 1;
            int row = 0;
            int column = 0;

            // fills first uniform sequence - matrix border and above main diagonal 
            FillSequence(row, column);
            // locates first possible cell for the next sequence
            FindEmptyCell(out row, out column);
            // fills the matrix up to the end
            FillSequence(row, column);

            // prints the formatted result
            Console.WriteLine(RotatingWalk.ToString());

            Console.WriteLine("Press Enter to finish");
            Console.ReadLine();
        }

        /// <summary>
        /// Fills the matrix with single walk sequence
        /// until reaching a deadlock
        /// </summary>
        /// <param name="row">first cell's row index</param>
        /// <param name="column">first cell's column index</param>  
        private static void FillSequence(int row, int column)
        {
            int rowOffset = rowDirection[0];
            int columnOffset = columnDirection[0];

            while (IsWalkPossible(row, column))
            {
                matrix[row, column] = currentValue;

                while ((!IsValid(row + rowOffset, column + columnOffset) ||
                        matrix[row + rowOffset, column + columnOffset] != 0))
                {
                    ChangeDirection(ref rowOffset, ref columnOffset);
                }

                row += rowOffset;
                column += columnOffset;
                currentValue++;
            }

            if (IsValid(row, column))
            {
                matrix[row, column] = currentValue++;                
            }
        }

        /// <summary>
        /// Changes current walk direction with next direction
        /// in sequence according to the task requirements
        /// </summary>
        /// <param name="rowOffset">row offset of the direction</param>
        /// <param name="colOffset">column offset of the direction</param>
        static void ChangeDirection(ref int rowOffset, ref int colOffset)
        {

            for (int index = 0; index < rowDirection.Length - 1; index++)
            {
                if (rowDirection[index] == rowOffset && columnDirection[index] == colOffset)
                {
                    rowOffset = rowDirection[index + 1];
                    colOffset = columnDirection[index + 1];
                    return;
                }
            }

            rowOffset = rowDirection[0];
            colOffset = columnDirection[0];
        }


        /// <summary>
        /// Finds first possible empty cell (cell value of 0)
        /// in sequence from left to right and from top to bottom
        /// </summary>
        /// <param name="row">Empty cell's row index, if any or -1</param>
        /// <param name="col">Empty cell's column index, if any or -1</param>
        static void FindEmptyCell(out int row, out int col)
        {
            row = -1;
            col = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if there is available empty neughbour cell to continue fill sequence 
        /// </summary>
        /// <param name="row">current cell's row index</param>
        /// <param name="column">current cell's column index</param>
        /// <returns>true if there is such empty cell</returns>
        static bool IsWalkPossible(int row, int column)
        {
            for (int i = 0; i < rowDirection.Length; i++)
            {
                if (IsValid(row + rowDirection[i], column + columnDirection[i]) &&
                    matrix[row + rowDirection[i], column + columnDirection[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if a cell is within the matrix range
        /// </summary>
        /// <param name="row">checked cell's row index</param>
        /// <param name="column">checked cell's column index</param>
        /// <returns></returns>
        private static bool IsValid(int row, int column)
        {
            return (row >= 0 && row < matrix.GetLength(0) &&
                   column >= 0 && column < matrix.GetLength(1));
        }

        /// <summary>
        /// Creates string representation of the matrix
        /// </summary>
        /// <returns>Formatted string</returns>
        public static string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    output.AppendFormat("{0,5}", matrix[r, c]);
                }

                output.AppendLine();
            }

            return output.ToString();
        }
    }
}