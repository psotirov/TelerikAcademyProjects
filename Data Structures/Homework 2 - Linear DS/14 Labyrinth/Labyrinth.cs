using System;
using System.Collections.Generic;

class Labyrinth
{
    /// <summary>
    /// Helper structure, holding each cell coordinates and path length from start cell 
    /// </summary>
    // DISCLAIMER: I know that it should be placed in a separate file but it is SO SMALL to do that!!!
    struct Cell
    {
        public int Row;
        public int Column;
        public int WalkLength;

        public Cell(int row, int col, int len)
        {
            this.Row = row;
            this.Column = col;
            this.WalkLength = len;
        }
    }

    static string[,] board = new string[,] {
        { "0", "0", "0", "x", "0", "x" },
        { "0", "x", "0", "x", "0", "x" },
        { "0", "*", "x", "0", "x", "0" },
        { "0", "x", "0", "0", "0", "0" },
        { "0", "0", "0", "x", "x", "0" },
        { "0", "0", "0", "x", "0", "x" },
    };

    static void Main()
    {
        Console.WriteLine("Task 14 - Labyrinth\n\nInitial board state:");
        PrintBoard();

        WalkBoard();
        FillUnreachables();
        Console.WriteLine("\nFinal board state:");
        PrintBoard();

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }

    /// <summary>
    /// Walking the board using BFS algorythm, i.e. process neighbour cells first
    /// </summary>
    static void WalkBoard()
    {
        int[,] offsets = new int[,]
        {
            { -1,  0,  1,  0 },
            {  0,  1,  0, -1 }
        };

        Queue<Cell> walk = new Queue<Cell>();
        Cell current = GetStart();
        while (true)
        {
            // put each empty neighbour cell into the queue
            for (int i = 0; i < offsets.GetLength(1); i++)
            {
                Cell next = new Cell(current.Row + offsets[0, i], current.Column + offsets[1, i], current.WalkLength + 1);
                if (next.Row >= 0 && next.Row < board.GetLength(0) &&
                    next.Column >= 0 && next.Column < board.GetLength(1) &&
                    board[next.Row, next.Column] == "0")
                {
                    walk.Enqueue(next);
                }
            }

            // if the queue is empty then all possible cells is visited yet
            if (walk.Count == 0)
            {
                return;
            }

            // takes the next empty cell in order and fills its path distance
            current = walk.Dequeue();
            board[current.Row, current.Column] = current.WalkLength.ToString();
        }
    }

    /// <summary>
    /// Takes the start cell (marked as "*")
    /// </summary>
    static Cell GetStart()
    {
        for (int r = 0; r < board.GetLength(0); r++)
        {
            for (int c = 0; c < board.GetLength(1); c++)
            {
                if (board[r, c] == "*")
                {
                    return new Cell(r, c, 0);
                }
            }
        }

        // there is no asterix, start at cell 0,0
        return new Cell(0, 0, 0);
    }

    /// <summary>
    /// Prints the board to the console
    /// </summary>
    static void PrintBoard()
    {
        for (int r = 0; r < board.GetLength(0); r++)
        {
            for (int c = 0; c < board.GetLength(1); c++)
			{
                Console.Write("{0,2} ", board[r,c]);
			}
            Console.WriteLine();                
        }
    }

    /// <summary>
    /// Marks all empty cells in the board as unreachable
    /// This should be executed after the board has been walked 
    /// </summary>
    static void FillUnreachables()
    {
        for (int r = 0; r < board.GetLength(0); r++)
        {
            for (int c = 0; c < board.GetLength(1); c++)
            {
                if (board[r, c] == "0")
                {
                    board[r, c] = "u";
                }
            }
        }
    }
}
