using System;

class Pillars
{
    static void Main()
    {
        int[] grid = new int[8] {0, 0, 0, 0, 0, 0, 0, 0};
        for (int i = 0; i < 8; i++) // Loop to enter byte masks
        {
            int number = int.Parse(Console.ReadLine()); // reads a number from the console
            for (int j = 0; j < 8; j++) // interates through the number's bits
            {
                if (((number >> j) & 1) == 1) // if the bit in j-th position is set  
                {
                    grid[j]++; // increases the array counter in position j
                }
            }
        } // finally in each element of the array "grid" we will have the count of bits into correspondng "pillar" 

        int pillarPos = -1;
        int leftSum = 0; // the sum of bits for pillars that are located left to the result

        for (int i = 7; i >= 0; i--) // Main loop - interates through the pillars (from most to least positon)
        {
            leftSum = 0; // the sum of bits for pillars that are located left to the current one
            int rightSum = 0; // the sum of bits for pillars that are located right to the current one
            for (int j = 7; j > i; j--) // Left pillars loop / sum, if i=7 there are no left columns, leftSum=0
            {
                leftSum += grid[j];
            }                

            for (int j = 0; j < i; j++) // Right pillars loop / sum, if i=0 there are no right columns, rightSum=0
            {
                rightSum += grid[j];
            }                


            if (leftSum == rightSum) // if we have a solution
            {
                pillarPos = i; // i-th index is the position of the "winner"pillar, the number of bits is kept ito "leftSum" variable
                break; // and stops the loop
            }
        }
        if (pillarPos == -1)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine(pillarPos);
            Console.WriteLine(leftSum);
        }
    }
}
