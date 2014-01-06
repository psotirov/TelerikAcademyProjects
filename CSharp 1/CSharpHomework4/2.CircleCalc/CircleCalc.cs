using System;

class CircleCalc
{
    static void Main()
    {
        Console.Write("Please enter circle radius (real number): ");
        string input = Console.ReadLine();
        double radius = 0.0;
        if (!double.TryParse(input, out radius))
        {
            Console.WriteLine("Wrong number!");
            return;
        }
        double perimeter = 2 * Math.PI * radius;
        double area = Math.PI * radius * radius;
        Console.WriteLine("The perimeter of the circle is " + perimeter);
        Console.WriteLine("The area of the circle is " + area);
    }
}

