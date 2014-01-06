using System;
using System.Collections.Generic;

class ReverseList
{
    static private readonly Stack<int> stack = new Stack<int>();

    static void Main()
    {
        Console.WriteLine("Task 2 - Show List of Integers in revered order\n");

        string inputLine;
        int countN = 1;
        int number;
        do
        {
            Console.Write("Integer {0} > ", countN);
            inputLine = Console.ReadLine().Trim();
            if (int.TryParse(inputLine, out number))
            {
                stack.Push(number);
                countN++;
            }
            else if (inputLine.Length > 0) 
            {
                Console.WriteLine("Input should be an integer number\n");
            }
        } while (inputLine.Length > 0);

        Console.WriteLine("\nThe numbers count is " + --countN);
        while (stack.Count > 0)
        {
            Console.WriteLine("The {0} number is: {1}", countN--, stack.Pop());            
        }

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}

