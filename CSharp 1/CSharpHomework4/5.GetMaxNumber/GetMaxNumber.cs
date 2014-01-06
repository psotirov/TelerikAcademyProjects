using System;

class GetMaxNumber
{
    static void Main()
    {
        Console.Write("Please enter first number: ");
        string input = Console.ReadLine();
        double number1 = 0;
        if (!double.TryParse(input, out number1))
        {
            Console.WriteLine("Wrong number!");
            return;
        }
        Console.Write("Please enter second number: ");
        input = Console.ReadLine();
        double number2 = 0;
        if (!double.TryParse(input, out number2))
        {
            Console.WriteLine("Wrong number!");
            return;
        }

        Console.WriteLine("The greater number is " + Math.Max(number1, number2));
    }
}

