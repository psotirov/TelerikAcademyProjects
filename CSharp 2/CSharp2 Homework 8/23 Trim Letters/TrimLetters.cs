using System;

class TrimLetters
{
    static void Main()
    {
        Console.WriteLine("Task 23 - Trim all consequtive equal letters in a string\n\n");

        Console.Write("\nPlease enter string: ");
        string text = Console.ReadLine().Trim(); // enters the string and removes whitespace chars from its start and end

        char currLetter = ' '; // initially current letter equals to space (since due to Trim() it could not be the first letter in text
        string result = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsLetter(text[i]) && text[i] != currLetter)
            // takes into accunt only letters and if the previous saved letter is different (thus trims equl letters)
            {
                result += text[i];
                currLetter = text[i];
            }
        }

        Console.WriteLine("\nResult: " + result);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}