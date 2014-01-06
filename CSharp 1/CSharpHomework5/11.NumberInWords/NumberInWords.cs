using System;

class NumberInWords
{
    static void Main()
    {
        string[,] words = new string[3, 10] 
        {
            {"","one", "two", "three", "four", "five", "six", "seven", "eight", "nine"},
            {"","", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety"},
            {"","one", "two", "three", "four", "five", "six", "seven", "eight", "nine"},
        };
        string[] specials = new string[]
            { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

        Console.Write("Please enter number [0, 999]: ");
        string input = Console.ReadLine();
        int n = 0;
        if (!int.TryParse(input, out n) || (n < 0) || (n > 999)) return;

        if (n == 0)
        {
            Console.WriteLine(".zero.");
            return;
        }

        int digit = n / 100; // takes hundreds
        n = n % 100; // in the "n" is the remainder (tens and ones)
        string inWords = words[0, digit];
        if (digit > 0)
        {
            inWords = inWords + " hundred";
            if (n > 0)
            {
                inWords = inWords + " "; // space between hundreds and the rest
                if (n < 20 || n % 10 == 0) inWords = inWords + "and "; // if only special tens and ones follows
            }
        }
        digit = n / 10; // takes tens
        n = n % 10; // in the "n" is the remainder (ones)
        if (digit != 1) // for standard numbers construction, for example 2X = twenty xxxxxxxx
        {
            inWords = inWords + words[1, digit];
            if ((digit > 0) && (n > 0)) inWords = inWords + " "; // space between tens and ones
            inWords = inWords + words[2, n];
        }
        else inWords = inWords + specials[n]; // only special tens, for example 15 = fifteen

        Console.WriteLine("." + inWords + "."); // dots are used to show that no extra spaces are included
    }
}

