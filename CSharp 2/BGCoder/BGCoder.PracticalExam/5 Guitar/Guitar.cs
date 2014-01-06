using System;

class Guitar
{
    static void Main()
    {
        // temporary console input redirection
        //Console.SetIn(new System.IO.StreamReader("test.018.in.txt"));

        string[] elemC = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int dimC = elemC.Length; // the length of all intervals provided

        int[] interval = new int[dimC]; // intervals container
        for (int i = 0; i < dimC; i++)
        {
            interval[i] = int.Parse(elemC[i]);
        }

        int initVolB = int.Parse(Console.ReadLine());
        int maxVolM = int.Parse(Console.ReadLine());

        int endVol = -1; // initially there is no solution for the final guitar volume

        // the main idea of the solution is to calculate all possible sums of elements that are inside the permitted range [0,M (maxVolM)]
        // constructs one two dimensional bool array that holds information of all partial sums at each iteration from 0 to dimC inclusive
        // each i-th column contains information about all possible partial sums up to i-th iteration that is inside the range
        // i.e. in column 0 we have only one element that has value "true" - binTree[initVolB, 0] = true. 
        // i.e. in column 1 we have only two elements that has value "true" - binTree[initVolB+interval0, 1] and binTree[initVolB-interval0, 1]
        // i.e. in column i we have max 2^i elements that has value "true", but only the subset of them that are in the range.
        // Initially array holds only false values exept binTree[initVolB, 0] = true.
        // on each step i e [1, dimC] (for each intervals member) algorythm does the following:
        // scans all possible values between 0 and maxVolM in column (i-1) that are true. 
        // for each value calculates value+interval[i] and value-interval[i]. Each of them that falls in the range sets the corresponding 
        // array element. After the final step scans the last column and the max element is the result.
        // if there is no such element returns -1

        bool[,] binTree = new bool[maxVolM + 1, dimC + 1]; // (maxVolM+1) includes [0,maxVolM], (dimC + 1) includes initVolB also
        binTree[initVolB, 0] = true; // initially interval is the strting one

        for (int currInterval = 1; currInterval <= dimC; currInterval++) // iterates through all intervals
        {
            for (int currVal = 0; currVal <= maxVolM; currVal++) // iterates through all possible values
            { // the max number of iterations are dimC * maxVolM and in worst case this equals to 50 * 1000 = 50 000 (nothing so complex) 
                if (binTree[currVal, currInterval-1]) // takes all previous move's values
                {
                    int newValPos = currVal + interval[currInterval - 1]; // positive current interval offset 
                    int newValNeg = currVal - interval[currInterval - 1]; // negative current interval offset 
                    if (newValPos >= 0 && newValPos <= maxVolM) binTree[newValPos, currInterval] = true; // the new interval is valid 
                    if (newValNeg >= 0 && newValNeg <= maxVolM) binTree[newValNeg, currInterval] = true; // the new interval is valid 
                }                
            }
        }

        for (int i = maxVolM; i >= 0; i--) // scans the final column (result column) from highest to lowest values
        {
            if (binTree[i, dimC]) // WE HAVE RESULT
            {
                endVol = i;
                break;
            }
        }

        Console.WriteLine(endVol);
    }
}
