using System;

class CharArrayCompare
{
    static void Main()
    {
        Console.WriteLine("Task 03 - Character Array Comparison\n\n");
        Console.Write("Please enter first string (char array): ");
        string string1 = Console.ReadLine();
        Console.Write("Please enter second string (char array): ");
        string string2 = Console.ReadLine();
        Console.WriteLine("\n result of comparison (T-true, F-false)\n");
        Console.WriteLine("String 1: [{0}]", string1);
        Console.WriteLine("String 2: [{0}]", string2);
        int maxLength = (string1.Length > string2.Length) ? string1.Length : string2.Length;
        int minLength = (string1.Length < string2.Length) ? string1.Length : string2.Length;
        Console.WriteLine("           {0}", new string('-', maxLength));
        Console.Write(    "  Result:  ");
        for (int i = 0; i < minLength; i++)
        {
            Console.Write((string1[i] == string2[i])?'T':'F');
        }
        Console.WriteLine(new string('F', maxLength-minLength));

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }
}