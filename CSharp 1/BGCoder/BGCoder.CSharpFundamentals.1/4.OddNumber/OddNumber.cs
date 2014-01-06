using System;

class OddNumber
{
    static void Main()
    {
        int numbersCount = int.Parse(Console.ReadLine()); // reads the quantity of numbers to lookup for OddNumber

        long oddNumber = 0;
        long number = 0;
        for (int i = 0; i < numbersCount; i++) // Loop to enter numbers
        {
            number = long.Parse(Console.ReadLine()); // reads a number from the console
            oddNumber = oddNumber ^ number; // pumping numbers into the variable using XOR.
            //The effect is that "x" XOR "x" = 0, and finally 0 XOR "y" = "y" nevertheless the position of y into the array  
        }

        Console.WriteLine(oddNumber);
    }
}
