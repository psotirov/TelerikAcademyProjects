using System;
using System.Collections.Generic;

/// <summary>
/// BG Coder - 100/100
/// </summary>
class MessagesInABottle
{
    static SortedSet<string> output = new SortedSet<string>();
    static Dictionary<string, char> cipher = new Dictionary<string, char>();
    static int countSolutions = 0;
    static string encodedMessage;
    static string cipherString;

    static void Main(string[] args)
    {
        encodedMessage = Console.ReadLine();
        cipherString = Console.ReadLine();

        char codeChar = cipherString[0];
        string code = "";
        for (int i = 1; i < cipherString.Length; i++)
        {
            if (char.IsLetter(cipherString[i]))
            {
                cipher.Add(code, codeChar);
                codeChar = cipherString[i];
                code = "";
                continue;
            }

            code += cipherString[i];
        }

        cipher.Add(code, codeChar);

        Encode("", 0);
        Console.WriteLine(countSolutions);
        foreach (var item in output)
        {
            Console.WriteLine(item);            
        }
    }

    static void Encode(string decodedMessage, int startIndex)
    {
        if (startIndex == encodedMessage.Length)
        {
            output.Add(decodedMessage);
            countSolutions++;
            return;
        }

        for (int i = startIndex; i < encodedMessage.Length; i++)
        {
            string value = encodedMessage.Substring(startIndex, i - startIndex + 1);
            if (cipher.ContainsKey(value))
            {
                Encode(decodedMessage + cipher[value], i + 1);
            }
        }
    }
}
