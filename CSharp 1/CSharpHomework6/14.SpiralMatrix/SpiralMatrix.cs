using System;

class SpiralMatrix
{
    enum Direction { right, down, left, up }

    static void Main()
    {
        int N = 0;

        Console.Write("Please enter the dimension of a matrix N: ");
        if (!int.TryParse(Console.ReadLine(), out N) || N < 2 || N > 19) return;

        if (N > 12) Console.BufferWidth = Console.WindowWidth = N*6+5; // resize the console windows if needed

        int[,] matrix = new int[N, N]; //creates array that represents the NxN matrix
        int row = 0; // initial cell coordinates
        int col = 0;
        Direction dir = Direction.right; // intital direction is to the right

        for (int i = 1; i <= N*N; i++) // Iterates through the all values that must be put into cells
        {
            matrix[row, col] = i; // put the value into cureent cell
            switch (dir) // moves to the next cell and checks for boundary (end of matrix or non empty cell)
            {
                case Direction.right:
                    col++;
                    if (col == (N-1) || matrix[row, col+1] > 0) dir = Direction.down;
                    break;
                case Direction.down:
                    row++;
                    if (row == (N-1) || matrix[row+1, col] > 0) dir = Direction.left;
                    break;
                case Direction.left:
                    col--;
                    if (col == 0 || matrix[row, col-1] > 0) dir = Direction.up;
                    break;
                case Direction.up:
                    row--;
                    if (row == 0 || matrix[row-1, col] > 0) dir = Direction.right;
                    break;
                default:
                    break;
            }
        }

        string separator = "+";
        for (int i = 0; i < N; i++)
            separator = separator + "-----+"; // creates horizontal border

        Console.WriteLine(separator);
        for (int r = 0; r < N; r++) // outputs the matrix
        {
            Console.Write("|"); // starting vertical border
            for (int c = 0; c < N; c++)
            {
                Console.Write(" {0,3} |", matrix[r, c]); // prints formatted cell with intermedite separator / closing vertical border
            }
            Console.WriteLine("\n" + separator); // last horizontal border 
        }
    }
}
