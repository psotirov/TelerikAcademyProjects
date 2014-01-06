using System;

class Sudoku
{
    static int[,] board = new int[9,9];
    /*static int[,] board = new int[9, 9]
        {{ 5, 3, 0, 0, 7, 0, 0, 0, 0 }, 
         { 6, 0, 0, 1, 9, 5, 0, 0, 0 }, 
         { 0, 9, 8, 0, 0, 0, 0, 6, 0 }, 
         { 8, 0, 0, 0, 6, 0, 0, 0, 3 }, 
         { 4, 0, 0, 8, 0, 3, 0, 0, 1 }, 
         { 7, 0, 0, 0, 2, 0, 0, 0, 6 }, 
         { 0, 6, 0, 0, 0, 0, 2, 8, 0 }, 
         { 0, 0, 0, 4, 1, 9, 0, 0, 5 }, 
         { 0, 0, 0, 0, 8, 0, 0, 7, 9 }};*/

    static void Main()
    {
        int firstRow = 9;
        int firstCol = 9;
        for (int row = 0; row < 9; row++)
        {
            string line = Console.ReadLine();
            for (int col = 0; col < 9; col++)
            {
                int num = line[col] - (int)'0'; // takes the digit
                if (num > 0 && num < 10) board[row, col] = num; // if is digit place it into the board
                else // we have empty cell
                {
                    if (firstRow >= row && firstCol > col) // looking for the first empty cell (upper-left)
                    {
                        firstRow = row;
                        firstCol = col;
                    }
                }
            }
        }

        PlaySudoku(firstRow, firstCol);

        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                Console.Write(board[row, col]);
            }
            Console.WriteLine();
        }
        //Console.ReadLine();
    }

    static bool PlaySudoku(int feRow, int feCol)
    {
        bool[] usedDigits = new bool[9]; // for each digit that is used in the current line we set its digit to true
        for (int c = 0; c < 9; c++)
        {
            if (board[feRow, c] > 0) // extract already used row numbers
            {
                usedDigits[board[feRow, c]-1] = true;
            }
            if (board[c, feCol] > 0) // extract already used column numbers
            {
                usedDigits[board[c, feCol] - 1] = true;
            }
            if (board[(feRow/3)*3 + c/3,(feCol/3)*3 + c%3] > 0) // extract already used subgrid numbers
            {
                usedDigits[board[(feRow / 3) * 3 + c / 3, (feCol / 3) * 3 + c % 3] - 1] = true;
            } 
        }

        for (int digit = 1; digit < 10; digit++)
        {
            if (!usedDigits[digit-1]) // this digit is free to use
            {
                // try to solve with this digit
                board[feRow, feCol] = digit; // put the digit into current cell
                int newRow = feRow;
                int newCol = feCol;
                while (newRow < 9 && board[newRow, newCol] > 0) // looking for next empty cell
                {
                    if (++newCol > 8)
                    {
                        newCol = 0;
                        newRow++;
                    }
                }

                if (newRow == 9) return true; // GREAT! We have fully filled Sudoku solution
                if (PlaySudoku(newRow, newCol)) return true; // here is the final exit path from recursion
            }
        }
        board[feRow, feCol] = 0; // restore empty current cell
        return false; // if we are here we don't have a solution -> go upstairs
    }
}
