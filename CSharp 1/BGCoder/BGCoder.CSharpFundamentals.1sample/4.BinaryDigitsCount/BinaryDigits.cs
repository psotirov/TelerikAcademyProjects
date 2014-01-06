using System;

class BinaryDigitsCount
{
    static void Main()
    {
        uint B = uint.Parse(Console.ReadLine()); // what to look for - 0 or 1
        int N = int.Parse(Console.ReadLine()); // quantity of numbers

        uint[] numbers = new uint[N];
        for (int i = 0; i < N; i++) // Loop to enter  numbers 
        {
            numbers[i] = uint.Parse(Console.ReadLine()); // reads from the console
        }

        foreach (uint num in numbers) // Iterates through each element in the array 
        {
            uint number = num; // transfers the iterator element to local variable
            int count = 0; // bit's counter
            int binaryLength = 32; // binary length of unsigned integer is 32 bits

            //Checking the binary length of the number (extracts leading 0's)
            while ((number >> (binaryLength - 1) & 1) == 0) binaryLength--; // 31 shifts for the most meaning bit

            for (int j = 0; j < binaryLength; j++) // Loop through each bit of the current number
            {
                if ((number & 1) == B) count++;
                number = number >> 1;
            }
            Console.WriteLine(count);
        }
    }
}

