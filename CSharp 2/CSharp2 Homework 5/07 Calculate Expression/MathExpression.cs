using System;

class CalculateExpression
{
    static void Main()
    {
        Console.WriteLine(@"
        Task 07 - Calculate expression as per user input

        You can use
            Real numbers: positive and negative,
            Arithmetic operators: *, /, +, -,
            Mathematical functions: ln(x), sqrt(x), pow(x,y),
            Brackets: ( and ) to change the priority");

        Console.Write("\n\nExpression = ");
        string expression = Console.ReadLine();

        double result = CalcExpression(expression);
        if (!double.IsNaN(result)) Console.WriteLine("\n\nResult = " + result);
        else Console.WriteLine("Incorrect Expression!");

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
    static double CalcExpression(string vals)
    {
        double result = 0.0;
        // Here must be placed the code that actually calculates the expression
        // but probably it will happen next time when the terms are not so short!!!!
        return result;
    }
}

