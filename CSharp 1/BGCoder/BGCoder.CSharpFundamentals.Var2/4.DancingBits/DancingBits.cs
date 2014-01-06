using System;

class DancingBits
{
    static void Main()
    {
        int K = int.Parse(Console.ReadLine()); // reads the depth of the "dancng bits" sequence
        int N = int.Parse(Console.ReadLine()); // reads the quantity of inspected numbers
        int dancingBits = 0; // intitally we don't have dancing bits
        int currentBit = 0; // the bit's queue always starts with 1, but it would be found into the firt iteration 
        int counter = 0; // equal bits counter

        for (int i = 0; i < N; i++)
        {
            int number = int.Parse(Console.ReadLine());
            int binaryLength = 32;
            while (((number >> (binaryLength-1)) & 1) == 0) binaryLength--; // calculates binary length of the number
            for (int j = binaryLength; j > 0; j--) // walks through number's bits from most to least one
            {
                int numberBit = (number >> (j - 1)) & 1;
                if (numberBit == currentBit) // checks if we have sequence of equal bits into the queue  
                {
                    counter++; // if YES counts them
                }
                else
                {
                    currentBit = numberBit; // if NO, selects current bit as start of new sequence
                    if (counter == K) // checks if sequence of K equal bits have been reached previously
                    {
                        dancingBits++; // counts this Dancing Bits sequence
                    }
                    counter = 1; // and resets the counter
                }
            }            
        }
        if (counter == K) dancingBits++; // takes into account the last sequence
        Console.WriteLine(dancingBits);
    }
}
