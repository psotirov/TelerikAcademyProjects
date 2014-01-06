using System;
using System.IO;

class SubmatrixSum
{
    static void Main()
    {
        const int SIZE = 2;
        int[,] matrix = null;
        int dimN = 0;
        Console.WriteLine("Task 05 - Find sub-matrix {0}x{0} with maximal sum\n\n", SIZE);


        Console.Write("Please enter the name and path to the text file: ");
        string filename1 = Console.ReadLine();

        try
        {
            using (StreamReader reader = new StreamReader(filename1))
            {
                // enters matrix Dimension N
                dimN = int.Parse(reader.ReadLine());
 
                matrix = new int[dimN, dimN];

                // enters matrix values
                for (int r = 0; r < dimN; r++)
                {
                    string[] colVals = reader.ReadLine().Split(' '); 
                    for (int c = 0; c < dimN; c++)
                    {
                        matrix[r, c] = int.Parse(colVals[c]);
                    }
                }
            }
        }
        catch (SystemException se)
        {
            Console.WriteLine("Exception: " + se);
            return;
        }

        int subRow = 0;
        int subCol = 0; // indices of the SIZExSIZE square sub-matrix with maximal sum
        int maxSum = int.MinValue; // ensures that every sum would be greater or equal to initial MaxSum
        for (int r = 0; r <= dimN - SIZE; r++)
            for (int c = 0; c <= dimN - SIZE; c++)
            {
                int sum = 0;
                for (int ir = r; ir < r + SIZE; ir++)
                    for (int ic = c; ic < c + SIZE; ic++)
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

        Console.Write("Please enter the name and path to the output text file: ");
        string filename2 = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename2))
            {
                writer.WriteLine(maxSum);
            }
        }
        catch (SystemException se)
        {
            Console.WriteLine("Exception: " + se);
            return;
        }

        Console.WriteLine("\nThe result is:");
        for (int r = subRow; r < subRow + SIZE; r++)
        {
            Console.Write("Matrix[{0}, {1}..{2}] = {{ ", r, subCol, (subCol + 2));
            for (int c = subCol; c < subCol + SIZE; c++)
            {
                Console.Write(matrix[r, c] + ((c < subCol + SIZE - 1) ? ", " : " "));
            }
            Console.WriteLine("}");
        }

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}