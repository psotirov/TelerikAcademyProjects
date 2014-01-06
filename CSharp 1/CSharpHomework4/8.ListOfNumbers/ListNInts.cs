using System;

class ListNInts
{
    static void Main()
    {
        Console.Write("Please enter the positive integer number: ");
        string input = Console.ReadLine();
        uint count = 0;
        if (!uint.TryParse(input, out count))
        {
            Console.WriteLine("Wrong number!");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            if (i > 0)
            {
                Console.Write(", ");
                if (i % 10 == 0) Console.WriteLine("");
            }
            Console.Write(i+1);
            
        }
        Console.WriteLine("");
    }
}

