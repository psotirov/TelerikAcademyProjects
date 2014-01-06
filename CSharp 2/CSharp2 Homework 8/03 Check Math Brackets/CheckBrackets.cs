using System;

class CheckBrackets
{
    static void Main()
    {
        Console.WriteLine("Task 03 - Check equation for correct use of brackets\n\n");

        Console.Write("Please enter an equation: ");
        string str = Console.ReadLine().Trim(); // enters the string and removes whitespace chars from its start and end
        int brCount = 0; // initially there is no brackets 

        for (int i = 0; (i < str.Length && brCount >= 0); i++)
        // iterates through equation but normally the opening bracket must precede any closing one 
        {
            if (str[i] == '(') brCount++; // every opening bracket increases the counter
            if (str[i] == ')') brCount--; // every closing bracket dereases the counter
        }

        if (brCount == 0) Console.WriteLine("The equation is correct.");
        else Console.WriteLine("The equation is INCORRECT!");

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}
