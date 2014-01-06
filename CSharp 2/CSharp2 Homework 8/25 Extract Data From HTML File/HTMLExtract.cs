using System;
using System.IO;
using System.Text.RegularExpressions;

class HTMLExtract
{
    static void Main()
    {
        Console.WriteLine("Task 25 - Extract title and body text (wihtout tags) from a given HTML file\n\n");

        Console.Write("\nPlease enter HTML filename and path: ");
        string filename = Console.ReadLine().Trim(); // enters the filename and removes whitespace chars from its start and end
        string text = string.Empty;

        try
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                text = sr.ReadToEnd();
            }
        }
        catch (IOException ioe)
        {
            Console.WriteLine("Invalid filename and/or path\n" + ioe);
            return;
        }

        Match foundTitle = Regex.Match(text, "<title>(.*?)</title>",
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
        // finds the value between <title> and </title> tags, if any. Puts it in the Group[1] (Group[0] contains tags also)
        if (foundTitle.Success) Console.WriteLine("HTML Title: " + foundTitle.Groups[1].Value);

        Match foundBody = Regex.Match(text, "<body>(.*)</body>", 
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
        // finds the text between <body> and </body> tags, if any. Puts it in the Group[1] (Group[0] contains tags also)

        if (foundBody.Success) // there is any text (including tags) between <body> and </body>
        {
            string result = Regex.Replace(foundBody.Groups[1].Value, "<.*?>", string.Empty); // removes all tags          
            result = Regex.Replace(result, "^\\s\\s+", string.Empty, RegexOptions.Multiline); // removes any two or more consequitive spaces at the begining of each line
            Console.WriteLine("HTML Text:\n" + result);
        }

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}