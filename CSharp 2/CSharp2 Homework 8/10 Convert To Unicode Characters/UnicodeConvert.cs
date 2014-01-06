using System;
using System.Text;

class UnicodeConvert
{
    static void Main()
    {
        Console.WriteLine("Task 10 - Convert string to sequence of Unicode characters\n\n");

        Console.Write("Please enter a string: ");
        string str = Console.ReadLine().Trim(); // enters the string and removes whitespace chars from its start and end
        StringBuilder newStr = new StringBuilder("");
        for (int i = 0; i < str.Length; i++)
        {
            newStr.Append(String.Format("\\u{0:X4} ", (int)str[i]));
        }
        Console.WriteLine("The converted string is: " + newStr);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}
