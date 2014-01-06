using System;

class BitOfInteger
{
    static void Main()
    {
        string input = Console.ReadLine();
        int number = 0;
        int pos = 3;
        if (int.TryParse(input, out number))
        {
            bool isBitSet = ((number >> pos) & 1) == 1;
            Console.WriteLine("The {0} bit of the number is set? -> {1}", pos, isBitSet);
        }
    }
}
