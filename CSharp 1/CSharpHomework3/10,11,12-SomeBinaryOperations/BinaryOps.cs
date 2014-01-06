using System;

class SomeBinaryOperations
{
    static void Main()
    {
        Console.Write("Enter integer number: ");
        string input = Console.ReadLine();
        int number = 0;
        if (int.TryParse(input, out number))
        {
            // Task 10 - Check value of bit p
            Console.Write("Enter bit position p between 0 and 31: ");
            input = Console.ReadLine();
            int pos = 0;
            if (int.TryParse(input, out pos) && (pos >= 0) && (pos < 31))
            {
                bool isBitSet = ((number >> pos) & 1) == 1;
                Console.WriteLine("The {0} bit of the number is set? -> {1}\n", pos, isBitSet);
                
                //Task 11 - Extract value of bit p
                Console.WriteLine("The value of the bit {0} of the number is {1}\n", pos, ((number >> pos) & 1));

                //Task 12 - Changing the value of bit p
                Console.Write("Enter the new value of the bit (0 or 1): ");
                input = Console.ReadLine();
                int mask = 0;
                if (int.TryParse(input, out mask) && (mask >= 0) && (mask < 2))
                {
                    if (mask == 0) number &= ~(1 << pos); // sets bit p to zero
                    else number |= 1 << pos; // or to one, depending on the mask 
                    Console.WriteLine("The result number is " + number);
                }
                else Console.WriteLine("Wrong value!\n");
            }
            else Console.WriteLine("Wrong parameter p!\n");

        }
    }
}
