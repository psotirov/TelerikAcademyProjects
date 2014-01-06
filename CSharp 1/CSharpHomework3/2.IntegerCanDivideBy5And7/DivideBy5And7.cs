using System;

class DivideBy5And7
{
    static void Main()
    {
        string input = Console.ReadLine();
        int number = 0;
        if (int.TryParse(input, out number) && (number != 0))
        {
            if ((number % 5 == 0) && (number % 7 == 0)) Console.WriteLine("The number is division of 5 and 7 sumultaneously");
            else Console.WriteLine("The number could not be divided by 5 or by 7 (or both)");
        }
    }
}
