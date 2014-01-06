using System;

class HelloMethod
{
    static void Main()
    {
        Console.WriteLine("Task 01 - Write method that outputs \"Hello, <name>\"\n\n");

        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        PrintName(name);

        Console.WriteLine("\nPlease hit Enter to finish");
        Console.ReadLine();
    }

    static void PrintName(string name)
    {
        Console.WriteLine("Hello, {0}", name);
    }
}
