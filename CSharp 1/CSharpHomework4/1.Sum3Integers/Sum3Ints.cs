using System;

class Sum3Ints
{
    static void Main()
    {
        int sum = 0;
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Please enter {0} integer number: ", i+1);
            string input = Console.ReadLine();
            int number = 0;
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Wrong number!");
                return;
            }
            sum += number;
        }
        Console.WriteLine("The sum of these integers is " + sum);
    }
}

