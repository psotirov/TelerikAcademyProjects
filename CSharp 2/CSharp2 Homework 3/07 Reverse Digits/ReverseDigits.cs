using System;

class ReverseDigits
{
    static void Main()
    {
        Console.WriteLine("Task 07 - Reverses digits of a given number\n\n");

        int numb = 0;
        Console.Write("Please enter a number: ");
        if (int.TryParse(Console.ReadLine(), out numb)) // correct integer was entered
        {
            Console.WriteLine("The reversed number is {0}", Reverse(numb));
        }
        else
        {
            Console.WriteLine("Not a valid integer");
        }

        Console.WriteLine("\nPlease hit Enter to finish");
        Console.ReadLine();
    }

    static int Reverse(int num)
    {
        int result = 0;
        while (num != 0)
        {
            result *= 10; // shifts one digit to the left 
            result += num % 10; // adds the last digit of num 
            num /= 10; // shifts one digit to the right
        }

        return result;
    }
}