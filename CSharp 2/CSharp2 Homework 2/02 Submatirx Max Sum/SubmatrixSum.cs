using System;

class SubmatrixSum
{
    static void Main()
    {
        const int SIZE = 3;
        Console.WriteLine("Task 02 - Find sub-matrix {0}x{0} with maximal sum\n\n", SIZE);

        Console.Write("Please enter matrix Dimension\nN rows x M columns (two numbers, divided by space): ");
        string[] dim = Console.ReadLine().Split(' ');
        int dimN = 0;
        int dimM = 0;

        if (dim.Length != 2 || !int.TryParse(dim[0], out dimN) || !int.TryParse(dim[1], out dimM) || dimN < SIZE || dimM < SIZE)
        {
            Console.WriteLine("Bad input agruments!");
            return;
        }

        int[,] matrix = new int[dimN,dimM];

        Console.WriteLine("\nPlease enter matrix values ({0} numbers per line, divided by space): ", dimM);

        for (int r = 0; r < dimN; r++)
        {
            bool hasError = false;
            Console.Write("Matrix[{0}, 0..{1}] = ", r, dimM-1);
            string[] colVals = Console.ReadLine().Split(' ');
            if (colVals.Length == dimM)
            {
                for (int c = 0; c < dimM; c++)
                {
                    if (!int.TryParse(colVals[c], out matrix[r,c]))
                    {
                        hasError = true; // repeats the current iteration if there is incorrect cell value
                        break;
                    }
                }
            } else hasError = true; // repeats the current iteration if there are no exactly M vaues entered
            if (hasError)
            {
                Console.WriteLine("Bad values, please enter again");
                r--;
            }
        }

        int subRow = 0;
        int subCol = 0; // indices of the SIZExSIZE square sub-matrix with maximal sum
        int maxSum = int.MinValue; // ensures that every sum would be greater or equal to initial MaxSum
        for (int r = 0; r <= dimN-SIZE; r++)
            for (int c = 0; c <= dimM-SIZE; c++)
            {
                int sum = 0;
                for (int ir = r; ir < r+SIZE; ir++)
                    for (int ic = c; ic < c+SIZE; ic++)
                    {
                        sum += matrix[ir, ic];
                    }

                if (sum >= maxSum)
                {
                    maxSum = sum;
                    subRow = r;
                    subCol = c;
                }
            }

        Console.WriteLine("\nThe result is:");
        for (int r = subRow; r < subRow + SIZE; r++)
        {
            Console.Write("Matrix[{0}, {1}..{2}] = {{ ", r, subCol, (subCol+SIZE-1));
            for (int c = subCol; c < subCol + SIZE; c++)
            {
                Console.Write(matrix[r, c]+((c < subCol+SIZE-1)?", ":" "));
            }
            Console.WriteLine("}");
        }

        Console.WriteLine("Press Enter to finish");
        Console.ReadLine();
    }
}