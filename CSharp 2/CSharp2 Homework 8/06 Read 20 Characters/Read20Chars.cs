using System;
using System.Text;

class Read20Characters
{
    static void Main()
    {
        Console.WriteLine("Task 06 - Read a string of up to 20 characters\n\n");

        Console.Write("Please enter a string: ");
        string str = Console.ReadLine();
        StringBuilder newStr = new StringBuilder(new string('*',20));
        for (int i = 0; (i < 20 && i <str.Length); i++)
        {
            newStr[i] = str[i];
        }
        Console.WriteLine("The result string is: " + newStr);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}
