using System;
using System.Text;

class Cipher
{
    static void Main()
    {
        Console.WriteLine("Task 07 - Encode/Decode string with XOR cipher\n\n");

        Console.Write("Please enter a cipher: ");
        string cipher = Console.ReadLine();
        if (cipher.Length == 0) // obviously the cipher could not be empty string
        {
            Console.WriteLine("Invalid cipher");
            return;
        }
        Console.Write("Please enter the message: ");
        StringBuilder str = new StringBuilder(Console.ReadLine());
        int pos = 0;
        for (int i = 0; i < str.Length; i++)
        {
            str[i] = (char)((int)str[i] ^ (int)cipher[pos++]);
            if (pos >= cipher.Length) pos = 0; // after end of cipher string starts it from the begining
        }
        Console.WriteLine("The result string is: " + str);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}
