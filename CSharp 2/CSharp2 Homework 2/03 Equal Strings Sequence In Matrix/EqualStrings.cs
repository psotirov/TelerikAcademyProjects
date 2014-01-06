using System;

class EqualStrings
{
    static void Main()
    {
        Console.WriteLine("Task 03 - Find longest seqience of equal strings,\nlocated in a matrix horizontally, vertically or diagonally\n\n");

        Console.Write("Please enter matrix Dimension\nN rows x M columns (two numbers, divided by space): ");
        string[] dim = Console.ReadLine().Split(' ');
        int dimN = 0;
        int dimM = 0;

        if (dim.Length != 2 || !int.TryParse(dim[0], out dimN) || !int.TryParse(dim[1], out dimM) || dimN < 2 || dimM < 2)
        {
            Console.WriteLine("Bad input agruments!");
            return;
        }

        string[,] matrix = new string[dimN, dimM];

        Console.WriteLine("\nPlease enter matrix values: ");

        for (int r = 0; r < dimN; r++) // walks-through each of elements and gets its string vaue from the Console
            for (int c = 0; c < dimM; c++)
            {

                Console.Write("Matrix[{0}, {1}] = ", r, c);
                matrix[r, c] = Console.ReadLine();
 
            }

        string resultStr = matrix[0,0]; // selects very first single element as candidate
        int resultLen = 1;

        for (int r = 0; r < dimN; r++) // walks-through each of elements and sets its contained string as seed value
            for (int c = 0; c < dimM; c++)
            {
                // first checks horizontal line until the end of current sequence
                int count = 0; // no sequence
                bool hasHoriz = true; // Horizontal boundary has not been reached yet - different horizontal element or end of column 
                bool hasVert = true; // Vertical boundary has not been reached yet - different vertical element or end of row 
                bool hasRDiag = true; // Vertical boundary has not been reached yet - different diagonal element or end of column or end of row
                bool hasLDiag = true; // Vertical boundary has not been reached yet - different diagonal element or end of column or end of row

                while (hasHoriz || hasVert || hasRDiag || hasLDiag) // exits only when all boundaries has been reached
                {
                    count++; // go next (there is one direction that we have sequence yet)
                    if (hasHoriz && (c + count >= dimM || matrix[r, c + count] != matrix[r, c])) hasHoriz = false; // checks horizontal line
                    if (hasVert && (r + count >= dimN || matrix[r + count, c] != matrix[r, c])) hasVert = false; // checks vertical line
                    if (hasRDiag && (c + count >= dimM || r + count >= dimN ||
                                    matrix[r + count, c + count] != matrix[r, c])) hasRDiag = false; // checks right diagonal line
                    if (hasLDiag && (c - count < 0 || r + count >= dimN ||
                                    matrix[r + count, c - count] != matrix[r, c])) hasLDiag = false; // checks left diagonal line                    
                }

                if (count > resultLen) // if we have greater sequence
                {
                    resultLen = count; // takes it
                    resultStr = matrix[r, c];
                }


            }

        Console.Write("Result - "+resultLen+" times: ");
        while (resultLen > 0)
        {
            Console.Write(resultStr + ((resultLen-- > 1)?", ":"")); // prints the sequence string ""resultLen" times
        }

        Console.WriteLine("\n\nPress Enter to finish");
        Console.ReadLine();
    }
}