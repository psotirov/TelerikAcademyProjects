using System;

class ForbiddenWords
{
    static void Main()
    {
        Console.WriteLine("Task 09 - Substitute all forbidden words in a given text with asterixes\n\n");

        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string words = "Microsoft, PHP, CLR";

        Console.WriteLine("The text is:\n" + text);
        Console.WriteLine("\nThe forbidden words are:\n" + words);

        string[] forb = words.Split(new char[] {',',' '}, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in forb)
        {
            text = text.Replace(word, new string('*', word.Length)); // replaces every of forbidden words in the text with aterixes with equal length   
        } 

        Console.WriteLine("\nThe result substring is:\n" + text);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}
