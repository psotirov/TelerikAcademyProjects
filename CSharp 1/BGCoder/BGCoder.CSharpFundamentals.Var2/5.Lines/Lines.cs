using System;

class Lines
{

    static void Main()
    {
        int[] numbers = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 }; // array of input numbers
        int[] lines = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 }; // array of number of lines with length x -> lines[x-1]


        for (int i = 0; i < 8; i++) // takes 8 lines with data
        {
            numbers[i] = int.Parse(Console.ReadLine()); // and puts them into the array
        }

        for (int row = 0; row < 8; row++)
        {
            int HLineLength = 0;
            int VLineLength = 0;
            for (int col = 0; col < 8; col++)
            {
                if (((numbers[row] >> col) & 1) == 1) // returns true if bit on col position of row element is set, i.e. cell(row, col)
                {
                    HLineLength++; // increases the length of Horizontal Lines counter while the bit's sequence is set.
                }
                else // if horizontal line breaks
                {
                    if (HLineLength > 0) lines[HLineLength-1]++; // if we have line with positive length counts it
                    HLineLength = 0;
                }

                if (((numbers[col] >> row) & 1) == 1) // returns true if bit on row position of col element is set, i.e. cell(col, row)
                {
                    VLineLength++; // increases the length of Vertical Lines counter while the bit's sequence is set.
                }
                else // if vertical line breaks
                {
                    if (VLineLength > 1) lines[VLineLength-1]++; // if we have line with positive length counts it
                    VLineLength = 0; // also avoids duplicate counting of lines with length of 1
                }
            }
            if (HLineLength > 0) lines[HLineLength-1]++; // if we have a final horizontal line with positive length counts it
            if (VLineLength > 1) lines[VLineLength-1]++; // if we have a final horizontal line with positive length counts it
        }

        for (int i = 7; i >=0; i--)
            if (lines[i]>0)
                {
                    Console.WriteLine(i+1);
                    Console.WriteLine(lines[i]);
                    break;
                }
    }
}
