using System;

class FormatNumber
{
    static void Main()
    {
        Console.WriteLine("Task 11 - Show given number in different formats\n\n");

        Console.Write("Please enter a number: ");
        double num = 0.0;
        if (!double.TryParse(Console.ReadLine(), out num))
        {
                Console.WriteLine("Wrong number");
                return;
        }

        Console.WriteLine("\n    Decimal (integer): {0,15:D}", (int)num);
        Console.WriteLine("Hexadecimal (integer): {0,15:X}", (int)num);
        Console.WriteLine("           Percentage: {0,15:P0}", num);
        Console.WriteLine("           Scientific: {0,15:E4}", num);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}
