using System;
using System.Text;
using System.Text.RegularExpressions;

class ReplaceATag
{
    static void Main()
    {
        Console.WriteLine("Task 15 - Replaces <a> tag with <URL> tag in a given HTML string\n\n");

        StringBuilder html = new StringBuilder("<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"http://www.devbg.org\">our forum</a> to discuss the courses</p>");
        Console.WriteLine("The initial html fragment is: \n" + html);

        MatchCollection foundTags = Regex.Matches(html.ToString(), "<a href=\"(.*?)\">(.*?)</a>", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        // finds a complete <a></a> tag and divides it into two groups
        // Group[1] - URL link
        // Group[2] - the content between <a></a> tags
        for (int i = foundTags.Count-1; i >=0; i--) // starts from back in order to preserve all previous positions
        {
            html.Remove(foundTags[i].Index, foundTags[i].Length);
            html.Insert(foundTags[i].Index, "[URL=" + foundTags[i].Groups[1].Value + "]" + foundTags[i].Groups[2].Value + "[/URL]");
        }

        Console.WriteLine("\nThe final html fragment is: \n" + html);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}