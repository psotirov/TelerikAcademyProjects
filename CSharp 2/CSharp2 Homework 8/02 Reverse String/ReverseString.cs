using System;
using System.Text;

class ReverseString
{
    static void Main()
    {
        Console.WriteLine("Task 02 - Reverse the given string\n\n");

        Console.Write("Please enter a string: ");
        string str = Console.ReadLine().Trim(); // enters the string and removes whitespace chars from its start and end
        StringBuilder newStr = new StringBuilder("");
        for (int i = str.Length-1; i >= 0; i--)
        {
            newStr.Append(str[i]);
        }
        Console.WriteLine("The reverse string is: " + newStr);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}
