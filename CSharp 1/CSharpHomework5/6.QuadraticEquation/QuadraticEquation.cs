using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("Solving of Quadratic Equation a*X*X + b*X + c = 0");

        Console.Write("Please enter parameter a: ");
        string input = Console.ReadLine();
        double a = 0;
        if (!double.TryParse(input, out a) || (a == 0.0)) //if a=0 is not a quadratic equation
        {
            Console.WriteLine("Wrong number!");
            return;
        }

        Console.Write("Please enter parameter b: ");
        input = Console.ReadLine();
        double b = 0;
        if (!double.TryParse(input, out b))
        {
            Console.WriteLine("Wrong number!");
            return;
        }

        Console.Write("Please enter parameter c: ");
        input = Console.ReadLine();
        double c = 0;
        if (!double.TryParse(input, out c))
        {
            Console.WriteLine("Wrong number!");
            return;
        }

        double Discriminant = b * b - 4 * a * c;
        if (Discriminant < 0)
        {
            Console.WriteLine("There is no real roots!");
            return;
        }

        if (Discriminant == 0)
        {
            Console.WriteLine("There is one real root: " + (-1 * b / 2 * a));
            return;
        }

        // Discriminant > 0 ->two real roots
        Discriminant = Math.Sqrt(Discriminant);
        Console.WriteLine("The root 1 is " + ((-1 * b - Discriminant) / 2 * a));
        Console.WriteLine("The root 2 is " + ((-1 * b + Discriminant) / 2 * a));
    }
}

