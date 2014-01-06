using System;

class SumWithPrecision
{
    static void Main()
    {
        double LastSum = 0.0;
        double Sum = 1.0;
        int i = 2;
        
        Console.WriteLine("The Sum of 1 + 1/2 - 1/3 + 1/4 - 1/5 .... with precision 0.001");

        while (Math.Abs(Sum-LastSum) > 0.001)
        {
            LastSum = Sum;
            Sum += (-2 * (i % 2) + 1) * (1.0 / i++);
        }
        Console.WriteLine("\nThe Sum is {0:F3}", Sum);
    }
}

