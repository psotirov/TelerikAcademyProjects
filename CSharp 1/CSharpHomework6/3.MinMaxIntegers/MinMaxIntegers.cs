using System;

class MinMaxIntegers
{
    static void Main()
    {
        int N = 0;
        Console.Write("Please enter quantity of numbers N: ");
        if (!int.TryParse(Console.ReadLine(), out N) || N <= 0) return;
        int min = int.MaxValue;
        int max = int.MinValue;
        int number = 0;
        for (int i = 0; i < N; i++)
        {
            do
            {
                Console.Write("Please enter {0} number: ", i+1);   
            } while (!int.TryParse(Console.ReadLine(), out number));
            if (number < min) min = number;
            if (number > max) max = number;
        }
        Console.WriteLine("min = {0}, max = {1}", min, max);
    }
}
