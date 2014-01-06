using System;

class SumNNum
{
    static void Main()
    {
        Console.Write("How many numbers you want to sum: ");
        string input = Console.ReadLine();
        uint count = 0;
        if (!uint.TryParse(input, out count))
        {
            Console.WriteLine("Wrong number!");
            return;
        }
        
        double sum = 0;
        for (int i = 0; i < count; i++)
        {
            Console.Write("Please enter {0} number: ", i + 1);
            input = Console.ReadLine();
            double number = 0;
            if (!double.TryParse(input, out number))
            {
                Console.WriteLine("Wrong number!");
                return;
            }
            sum += number;
        }
        Console.WriteLine("The sum of all numbers is " + sum);
    }
}

