using System;

class FallDown
{
    static void Main()
    {
        int[] grid = new int[8];
        bool hasChanged = true;
        for (int i = 0; i < 8; i++) // Loop to enter byte masks
        {
            grid[i] = int.Parse(Console.ReadLine()); // reads a number from the console
        }

        while (hasChanged) // Main loop - executes until the grid is not modified since last operation
        {
            hasChanged = false; // there must be any change to become true
            for (int i = 0; i < 8; i++) // Horizontal loop - the grid is processed from column 0 (least bits) to column 7(most bits)
            {
                int mask = (1 << i); // sets the mask bit for i-th cell
                for (int j = 7; j > 0; j--) // Vertical loop - lines are processed from bottom to top
                {
                    if ((grid[j] & mask) == 0) // there is empty space at cell (i, j)
                    {
                        int temp = grid[j];
                        grid[j] = grid[j] | (grid[j - 1] & mask); //moves the bit from the upper cell (i, j-1)
                        grid[j - 1] = grid[j - 1] & (~mask); // then empties the upper cell (sets the corresponding bit to 0)
                        // this operation also empties the most upper cell (i,0) at the end of the loop
                        if (grid[j] != temp) hasChanged = true;
                    }
                }
            }
        }



        foreach (byte line in grid) // Loop to print result byte masks
        {
            Console.WriteLine(line);
        }
    }
}
