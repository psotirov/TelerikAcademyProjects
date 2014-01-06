using System;
using System.Text;

class Short2Binary
{
    static void Main()
    {
        Console.WriteLine("Tasks 08 - Show binary representation of 16-bit signed integer (SHORT)\n\n");

        Console.Write("\n\nPlease enter number [{0},{1}]: ", short.MinValue, short.MaxValue);
        int number = 0;
        if (!int.TryParse(Console.ReadLine(), out number) || number < short.MinValue || number > short.MaxValue)
        {
            Console.WriteLine("Wrong SHORT number");
            return;
        }

        int sign = 0;
        if (number < 0)
        {
            sign = 1;
            number = 32768 + number; // converts to additional positive
        }
        Console.WriteLine("\n\nSign: " + sign.ToString());
        Console.WriteLine("\nNumber representation: " + number);
        Console.WriteLine("\n\n                   S NNNNNNNNNNNNNNN\n" +
                              "                   1 111110000000000\n" +
                              "                   5 432109876543210\n" +
                            "\nThe result number: {0} {1}", sign.ToString(), Dec2Bin(number).PadLeft(15, '0'));

        Console.WriteLine("\nPress Enter to exit");
        Console.ReadLine();
    }

    static string Dec2Bin(int num)
    {
        StringBuilder bin = new StringBuilder();

        while (num > 0)
        {
            bin.Insert(0, num % 2);
            num /= 2;
        }

        return bin.ToString();
    }
}