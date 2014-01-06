using System;

class CountLetters
{
    static void Main()
    {
        Console.WriteLine("Task 21 - Count letters in a given text\n\n");

        int[] letters = new int[26]; // creates letter's counters holder
        Console.Write("\nPlease enter text: ");
        string text = Console.ReadLine().Trim().ToLower(); // enters the string and removes whitespace chars from its start and end

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] >= 'a' && text[i] <= 'z') letters[text[i] - 'a']++;
        }

        for (int i = 0; i < 26; i++)
        {
            if (letters[i] > 0) Console.WriteLine("Letter \"{0}\" - {1} time(s) met", (char)(i+'a'), letters[i]);
        }

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}