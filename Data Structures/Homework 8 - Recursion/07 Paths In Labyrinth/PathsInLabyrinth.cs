using System;
using System.Collections.Generic;

class PathsInLabyrinth
{
    //static char[,] labyrinth = new char[100, 100];
    static char[,] labyrinth = 
    {
        {' ', ' ', ' ', '*', ' ', ' ', ' '},
        {'*', '*', ' ', '*', ' ', '*', ' '},
        {' ', ' ', ' ', '*', ' ', ' ', ' '},
        {' ', '*', '*', '*', '*', '*', '*'},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
    };

	static readonly List<Tuple<int, int>> path = new List<Tuple<int, int>>();
    static bool pathFound = false;
    static bool singlePath = true;
    static int endRow;
    static int endCol;
    static int largestArea = 0;
    static int currentArea = 0;

    static void Main()
    {
        Console.WriteLine("Find all paths between two cells\n\nThe labyrinth is:");


        if (labyrinth.GetLength(0) < 20 && labyrinth.GetLength(1) < 20) // trim large labyrinths
        {
            PrintLabyrinth();
        }

        Console.Write("Enter cells ('start row' 'start col' 'end row' 'end col'): ");
        string[] cells = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (cells.Length != 4)
        {
            Console.WriteLine("Incorrect number of parameters");
            return;
        }

        int startRow = int.Parse(cells[0]);
        int startCol = int.Parse(cells[1]);
        endRow = int.Parse(cells[2]);
        endCol = int.Parse(cells[3]);

        if (!InRange(startRow, startCol) || !InRange(endRow, endCol))
        {
            Console.WriteLine("Incorrect cells");
            return;            
        }
        Console.WriteLine("\nTask 8. Find single path");
        FindPathToCell(startRow, startCol);

        if (labyrinth.GetLength(0) < 20 && labyrinth.GetLength(1) < 20) // trim large labyrinths
        {
            Console.WriteLine("\nTask 7. Find all paths");
            singlePath = false;
            pathFound = false;
            FindPathToCell(startRow, startCol);

            Console.WriteLine("\nTask 9. Find largest area");
            singlePath = false;
            pathFound = false;
            while (HasEmptyCells(out startRow, out startCol))
            {
                FindLargestArea(startRow, startCol);
                if (largestArea < currentArea)
                {
                    largestArea = currentArea;
                    currentArea = 0;
                }                
            }

            Console.WriteLine("Largest area contains {0} cells.", largestArea);
        }
    }

    static void FindPathToCell(int currentRow, int currentCol)
    {
        if (!InRange(currentRow, currentCol))
        {
            // We are out of the labyrinth -> can't find a path
            return;
        }

        // Check if we have found the exit
        if (currentRow == endRow && currentCol == endCol)
        {
            PrintPath(currentRow, currentCol);
            pathFound = true;
        }

        if (labyrinth[currentRow, currentCol] == '*' ||
            labyrinth[currentRow, currentCol] == 'v' || 
            (singlePath && pathFound))
        {
            // The current cell is not free -> can't find a path
            // or sigle path has been found - return back to the top
            return;
        }

        // Temporary mark the current cell as visited to avoid cycles
        labyrinth[currentRow, currentCol] = 'v';
        path.Add(new Tuple<int, int>(currentRow, currentCol));

        // Invoke recursion the explore all possible directions
        if (!singlePath || !pathFound) FindPathToCell(currentRow + 1, currentCol); // down
        if (!singlePath || !pathFound) FindPathToCell(currentRow, currentCol + 1); // right
        if (!singlePath || !pathFound) FindPathToCell(currentRow, currentCol - 1); // left
        if (!singlePath || !pathFound) FindPathToCell(currentRow - 1, currentCol); // up

        // Mark back the current cell as free
        // Comment the below line to visit each cell at most once
        labyrinth[currentRow, currentCol] = ' ';
        path.RemoveAt(path.Count - 1);
    }

    static void FindLargestArea(int currentRow, int currentCol)
    {
        if (!InRange(currentRow, currentCol))
        {
            // We are out of the labyrinth -> can't find a path
            return;
        }

        if (labyrinth[currentRow, currentCol] == '*' ||
            labyrinth[currentRow, currentCol] == 'v')
        {
            // The current cell is not free -> can't find a path
            return;
        }

        // Mark the current cell as visited to avoid cycles
        labyrinth[currentRow, currentCol] = 'v';
        currentArea++;

        // Invoke recursion the explore all possible directions
        FindLargestArea(currentRow + 1, currentCol); // down
        FindLargestArea(currentRow, currentCol + 1); // right
        FindLargestArea(currentRow, currentCol - 1); // left
        FindLargestArea(currentRow - 1, currentCol); // up
    }

    private static bool HasEmptyCells(out int currentRow, out int currentCol)
    {
        currentRow = 0;
        currentCol = 0;
        for (int r = 0; r < labyrinth.GetLength(0); r++)
        {
            for (int c = 0; c < labyrinth.GetLength(1); c++)
            {
                if (labyrinth[r, c] != '*' && labyrinth[r, c] != 'v')
                {
                    currentRow = r;
                    currentCol = c;
                    return true;
                }
            }
        }

        return false;
    }

    static bool InRange(int row, int col)
    {
        bool rowInRange = row >= 0 && row < labyrinth.GetLength(0);
        bool colInRange = col >= 0 && col < labyrinth.GetLength(1);
        return rowInRange && colInRange;
    }

    private static void PrintPath(int finalRow, int finalCol)
    {
        Console.Write("\nPath found: ");
        foreach (var cell in path)
        {
            Console.Write("{0},{1}-", cell.Item1, cell.Item2);
        }
        Console.WriteLine("{0},{1}", finalRow, finalCol);
    }

    private static void PrintLabyrinth()
    {
        string line1 = "   ";
        string line2 = "   ";
        for (int c = 0; c < labyrinth.GetLength(1); c++)
        {
            line1 += (c / 10 == 0) ? " " : "1";
            line2 += (c % 10).ToString();
        }

        Console.WriteLine(line1);
        Console.WriteLine(line2);

        for (int r = 0; r < labyrinth.GetLength(0); r++)
        {
            Console.Write("{0,2} ", r);
            for (int c = 0; c < labyrinth.GetLength(1); c++)
            {
                Console.Write(labyrinth[r, c]);
            }
            Console.WriteLine();
        }
    }
}
