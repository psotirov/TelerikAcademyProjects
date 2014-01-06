using System;
using System.Linq;
using System.Text;

namespace Matrix
{
    public class Matrix
    {
        private const int MAX_DIRECTION_NUMBER = 8;
        private int[,] matrix;
        private int[] directionRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private int[] directionCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

        public Matrix(int size)
        {
            if (size < 1 || size > 100)
            {
                throw new ArgumentOutOfRangeException("Matrix size have to be between 1 and 100!");
            }
            this.matrix = new int[size, size];

            this.FindAvailableCell();
            this.FillAvailableCells();
        }

        public int Row { get; private set; }
        public int Col { get; private set; }


        private void GetDirection(ref int dirRow, ref int dirCol)
        {
            int currDirection = 0;

            for (int dirIndex = 0; dirIndex < MAX_DIRECTION_NUMBER; dirIndex++)
            {
                if (this.directionRow[dirIndex] == dirRow && this.directionCol[dirIndex] == dirCol)
                {
                    currDirection = dirIndex;
                    break;
                }
            }

            if (currDirection == MAX_DIRECTION_NUMBER - 1)
            {
                dirRow = this.directionRow[0];
                dirCol = this.directionCol[0];
                return;
            }

            dirRow = this.directionRow[currDirection + 1];
            dirCol = this.directionCol[currDirection + 1];
        }

        private bool IsCellAvailable(int row, int col)
        {
            for (int dirIndex = 0; dirIndex < MAX_DIRECTION_NUMBER; dirIndex++)
            {
                int nextRow = row + this.directionRow[dirIndex];

                if (!this.IsInRange(nextRow))
                {
                    this.directionRow[dirIndex] = 0;
                }

                int nextCol = col + this.directionCol[dirIndex];

                if (!this.IsInRange(nextCol))
                {
                    directionCol[dirIndex] = 0;
                }
            }

            return this.IsNextCellEmpty(row, col, this.directionRow, this.directionCol);
        }

        private void FindAvailableCell()
        {
            this.Row = 0;
            this.Col = 0;

            for (int currRow = 0; currRow < this.matrix.GetLength(0); currRow++)
            {
                for (int currCol = 0; currCol < this.matrix.GetLength(1); currCol++)
                {
                    if (this.matrix[currRow, currCol] == 0)
                    {
                        this.Row = currRow;
                        this.Col = currCol;
                        return;
                    }
                }
            }
        }

        private void FillAvailableCells()
        {
            int currentDirectionX = 1;
            int currentDirectionY = 1;
            int number = 1;

            while (true)
            {
                if (this.Row < this.matrix.GetLength(0) && this.Col < this.matrix.GetLength(1))
                {
                    matrix[this.Row, this.Col] = number;

                    this.Row += currentDirectionX;
                    this.Col += currentDirectionY;
                    number++;
                }
                else
                {
                    break;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder matrixAsStirng = new StringBuilder();

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    matrixAsStirng.AppendFormat("{0,3}", this.matrix[row, col]);
                }

                matrixAsStirng.Append("\r\n");
            }

            return matrixAsStirng.ToString();
        }

        private bool IsNextCellEmpty(int row, int col, int[] directionRow, int[] directionCol)
        {
            for (int dirIndex = 0; dirIndex < MAX_DIRECTION_NUMBER; dirIndex++)
            {
                int nextRow = row + directionRow[dirIndex];
                int nextCol = col + directionCol[dirIndex];

                if (this.matrix[nextRow, nextCol] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsInRange(int value)
        {
            if (value >= this.matrix.GetLength(0) || value < 0)
            {
                return false;
            }

            return true;
        }
    }
}
