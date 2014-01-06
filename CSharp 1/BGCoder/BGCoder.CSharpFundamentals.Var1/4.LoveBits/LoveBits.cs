using System;

class LoveBits
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int[] result = new int[N];
        for (int i = 0; i < N; i++)
        {
            int P = int.Parse(Console.ReadLine());
            int bitLength = 32; // The binary length of the number is 32 bits initially
            while ((P >> (bitLength - 1) & 1) == 0) bitLength--;
            // checks each bit from the most to the least one and stops on first 1 - this is the exact length of the binary digit

            // Makes magic operation - Pnew = = (P ^ Pinversed) & Preversed
            // Since (P ^ Pinversed) always is 11111..1111, and 1111.11 & number = number
            // 110011 XOR 001100 = 111111, and 111111 AND 110011 = 110011
            // Pnew = Preversed
            for (int j = 0; j < bitLength; j++)
                result[i] = (result[i] << 1) | ((P >> j) & 1);
                //taking each bit from number P (from right to left) and put it into Pnew (from left to right)
        }
        for (int i = 0; i < N; i++) // Finally prints the result
        {
            Console.WriteLine(result[i]);            
        }
    }
}
