using System;

class LastDigit
{
    static void Main()
    {
        Console.WriteLine("Task 03 - Prints last digit of given integer in words\n\n");

        int numb = 0;
        Console.Write("Please enter a number: ");
        if (int.TryParse(Console.ReadLine(), out numb)) // correct integer was entered
        {
            Console.WriteLine("The last digit is {0}", GetDigit(numb));
        }
        else
        {
            Console.WriteLine("Not a valid integer");
        }
 
        Console.WriteLine("\nPlease hit Enter to finish");
        Console.ReadLine();
    }

    static string GetDigit(int num)
    {
        string[] words = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        return words[num % 10]; // takes last digit and selects corresponding word from the array 
    }
}