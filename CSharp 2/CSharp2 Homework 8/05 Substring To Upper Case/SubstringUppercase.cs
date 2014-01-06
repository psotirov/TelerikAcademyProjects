using System;
using System.Text.RegularExpressions;

class SubstringUppercase
{
    static void Main()
    {
        Console.WriteLine("Task 05 - Convert all substrings surrounded by tags <upper>\n     and </upper> in a given text to UPPERCASE\n\n");

        string text = "We are living in a <upper>yellow submarine</upper>. \nWe don't have<upper></upper> anything else. \nInside <upper>the submarine</upper> is very tight. \nSo we are drinking all the day. \nWe will move out of it in 5 days.\n";
        Console.WriteLine("The text is:\n" + text);

        string startTag = "<upper>";
        string endTag = "</upper>";
        Match start = Regex.Match(text, startTag); // looks for starting tag
        Match end = Regex.Match(text, endTag); // looks for ending tag
        while (start.Success && end.Success) // if a substring to conver has been found
        {
            int len = end.Index - start.Index - startTag.Length; // the length of substring to replace (without tags)
            // replaces the substring found (excluding tags) with the same substring, converted to UPPERCASE
            if (len > 0) // replaces only nonempty susbtrings
                text = text.Replace(text.Substring(start.Index + startTag.Length, len),
                    text.Substring(start.Index + startTag.Length, len).ToUpper());

            start = start.NextMatch(); // and goes further
            end = end.NextMatch(); // for the next pair of tags
        }
        // and finally removes the tags
        text = text.Replace(startTag, "");
        text = text.Replace(endTag, "");

        Console.WriteLine("The result substring is:\n" + text);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}
