using System;

class DivBy5
{
    static void Main()
    {
        Console.Write("Please enter first positive integer number: ");
        string input = Console.ReadLine();
        ulong number1 = 0;
        if (!ulong.TryParse(input, out number1))
        {
            Console.WriteLine("Wrong number!");
            return;
        }
        Console.Write("Please enter second positive integer number: ");
        input = Console.ReadLine();
        ulong number2 = 0;
        if (!ulong.TryParse(input, out number2))
        {
            Console.WriteLine("Wrong number!");
            return;
        }

        if (number1 > number2)
        {
            ulong temp = number1;
            number1 = number2;
            number2 = temp;
        }
        Console.WriteLine("The quantity of numbers that could be exactly divided by 5 in the range [{0}, {1}] is {2}",
            number1, number2, number2 / 5 - number1 / 5 + ((number1 > 0 && number1%5 == 0)?1u:0u));
    }
}

