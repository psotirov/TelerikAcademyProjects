using System;

class LargestArea
{
    static int[,] matrix; // the matrix with number values
    static bool[,] isExplored; // a helper matrix for walking-through algorithm. Once the element has benn visited, it is marked.

    static void Main()
    {
        Console.WriteLine("Task 07 - Find the largest area of equal numbers in a matrix\n\n");

        Console.Write("Please enter matrix Dimension\nN rows x M columns (two numbers, divided by space): ");
        string[] dim = Console.ReadLine().Split(' ');
        int dimN = 0;
        int dimM = 0;

        if (dim.Length != 2 || !int.TryParse(dim[0], out dimN) || !int.TryParse(dim[1], out dimM) || dimN < 2 || dimM < 2)
        {
            Console.WriteLine("Bad input agruments!");
            return;
        }

        matrix = new int[dimN, dimM]; // the matrix with number values
        isExplored = new bool[dimN, dimM]; // a helper matrix for walking-through algorithm. Once the element has benn visited, it is marked.

        Console.WriteLine("\nPlease enter matrix values ({0} numbers per line, divided by space): ", dimM);

        for (int r = 0; r < dimN; r++)
        {
            bool hasError = false;
            Console.Write("Matrix[{0}, 0..{1}] = ", r, dimM - 1);
            string[] colVals = Console.ReadLine().Split(' ');
            if (colVals.Length == dimM)
            {
                for (int c = 0; c < dimM; c++)
                {
                    if (!int.TryParse(colVals[c], out matrix[r, c]))
                    {
                        hasError = true; // repeats the current iteration if there is incorrect cell value
                        break;
                    }
                }
            }
            else hasError = true; // repeats the current iteration if there are no exactly M vaues entered
            if (hasError)
            {
                Console.WriteLine("Bad values, please enter again");
                r--;
            }
        }

        int maxEquals = 0;
        int numberEquals = 0;
        for (int r = 0; r < dimN; r++)
            for (int c = 0; c < dimM; c++)
            {
                int count = GetArea(r, c); // for each element of matrix checks the size of bounding area
                if (count > maxEquals)
                {
                    maxEquals = count;
                    numberEquals = matrix[r, c];
                }
            }

        Console.WriteLine("\n\nThe size of maximal equal numbers area is " + maxEquals);
        Console.WriteLine("The area is filled with number " + numberEquals);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }

    static int GetArea(int r, int c)
    {
        // the algorithm is simple:
        // 1. Marks current element as already visited
        // 2. sets counter = 1
        // 3. walks through each of neighbouring elements (left, down, right, top)
        //      3.1. checks if this element is inside the matrix
        //      3.2. checks if this element has the same value as current one
        //      3.3. checks if this element has not been visited
        // 4. if all conditions in point 3 is fulfilled, makes this element current and goes recursively to point 1.
        // 5. adds received result from each recursive call to the current counter
        // 6. returns counter value and exits

        int count = 1;
        isExplored[r, c] = true; // 1 element so far, marks it visited

        if (c > 0 && !isExplored[r, c - 1] && matrix[r, c - 1] == matrix[r, c]) // left neighbour element - if all conditions in point 3 has been fulfilled
            count += GetArea(r, c - 1); // goes to it
        if ((c < matrix.GetLength(1) - 1) && !isExplored[r, c + 1] && matrix[r, c + 1] == matrix[r, c]) // right neighbour element
            count += GetArea(r, c + 1);
        if (r > 0 && !isExplored[r - 1, c] && matrix[r - 1, c] == matrix[r, c]) // top neighbour element
            count += GetArea(r-1, c); // goes to it
        if ((r < matrix.GetLength(0) - 1) && !isExplored[r+1, c] && matrix[r+1, c] == matrix[r, c]) // bottom neighbour element
            count += GetArea(r+1, c);

        return count; // returns the total result to the moment
    }
}