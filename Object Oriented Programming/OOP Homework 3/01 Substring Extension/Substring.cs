using System;
using System.Text;

namespace _01_Substring_Extension
{
    // DISCLAIMER: even the good practice is to put each class in a separate file
    // here we are using a single file due to the task simplicity
    static class StringBuilderExtension
    {
        // the original Substring method has two overloaded instances:
        //  - public string Substring (int startIndex)
        //  - public string Substring (int startIndex, int length)
        // we are extending both of them for StringBuilder   
        public static StringBuilder Substring(this StringBuilder sbText, int startIndex, int length = -1)
        {
            if (length == -1) length = sbText.Length - startIndex; // using first form without length

            return new StringBuilder (sbText.ToString(startIndex, length));
        }
    }

    class SubstringTest
    {
        static void Main()
        {
            Console.WriteLine("Task 01 - StringBuilder Extension");
            StringBuilder txt = new StringBuilder("AlaBalaNitsa ili oshte po-smisleno - Shalalala (the last is copyright protected) ");
            Console.WriteLine("\r\nThe text: " + txt);
            Console.WriteLine("\r\nSubstring(38) = \"{0}\"", txt.Substring(37));
            Console.WriteLine("Substring(3,4) = \"{0}\"", txt.Substring(3,4));

            Console.WriteLine("\r\nPress Enter to finish");
            Console.ReadLine();
        }
    }
}
