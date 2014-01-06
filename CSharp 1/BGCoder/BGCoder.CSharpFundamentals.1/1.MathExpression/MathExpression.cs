using System;

class MathExpression
{
    static void Main()
    {
        double N = double.Parse(Console.ReadLine());
        double M = double.Parse(Console.ReadLine());
        double P = double.Parse(Console.ReadLine());
        double result = (N * N + 1 / (M * P) + 1337) / (N - 128.523123123d * P) + Math.Sin((int)M % 180);
        Console.WriteLine("{0:F6}",result);
    }
}

