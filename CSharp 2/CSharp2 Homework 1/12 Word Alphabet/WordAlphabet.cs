using System;

class WordAlphabet
{
    static void Main()
    {
        Console.WriteLine("Task 12 - Decodes the characters of a given word into the alphabet indices\n");
        Console.WriteLine("The alphabet array is:");

        char[] alphabet = new char[26];

        for (int i = 0; i < 26; i++) // creates alphabet array and prints it to the console
        {
            alphabet[i] = (char)('A' + i);
            Console.Write("{0} = {1:D2}  ",alphabet[i], i);
            if (i > 0 && i % 7 == 0) Console.WriteLine(); // new line on every 7 letters (total 4 lines long)
        }

        Console.Write("\n\nPlease enter a word (alphabet characters array): ");
        string word = Console.ReadLine().ToUpper();
        word = word.ToUpper(); // ensures using only of capital letters

        for (int i = 0; i < word.Length; i++) // iterates through characters of the input word
        {
            Console.Write("{0:D2} ", Array.BinarySearch(alphabet, word[i])); // makes look-up into the alphabet array using Binary Search method
        }

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }
}