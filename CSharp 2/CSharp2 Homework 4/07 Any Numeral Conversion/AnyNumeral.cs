using System;
using System.Text;

class NumeralConversions
{
    const string digits = "0123456789ABCDEF";

    static void Main()
    {
        Console.WriteLine("Tasks 07 - Convert number from one to another numeral system\n\n");

        int s = 0;
        Console.Write("\nPlease enter source numeral system S [2,16]: ");
        if (!int.TryParse(Console.ReadLine(), out s) || s < 2 || s > 16)
        {
            Console.WriteLine("Invalid source numeral system");
            return;
        }
        Console.WriteLine("\nThe {0} numeral system has digits {1}", s, digits.Substring(0, s));


        int d = 0;
        Console.Write("\n\nPlease enter destination numeral system D [2,16]: ");
        if (!int.TryParse(Console.ReadLine(), out d) || d < 2 || d > 16 || d==s)
        {
            Console.WriteLine("Invalid destination numeral system");
            return;
        }
        Console.WriteLine("\nThe {0} numeral system has digits {1}", d, digits.Substring(0, d));

        Console.Write("\n\nPlease enter number (each digit [0,{0}]): ", digits[s-1]);
        string number = Console.ReadLine().ToUpper();
        number = NumeralConvert(number, s, d);

        Console.WriteLine("\n\nThe result number: {0}", number);

        Console.WriteLine("\nPress Enter to exit");
        Console.ReadLine();
    }

    static string NumeralConvert(string num, int src, int dst)
    {
        StringBuilder result = new StringBuilder();
        // first step - convert source to decimal
        ulong dec = 0;
        for (int i = 0; i < num.Length; i++)
        {
            int srcDigit = digits.IndexOf(num[i]);
            if (srcDigit >= 0 && srcDigit < src)
            {
                dec = dec * (ulong)src + (ulong)srcDigit;
            }
        }

        // second step - convert decimal to destination
        while (dec > 0)
        {
            result.Insert(0, digits[(int)dec % dst]);
            dec /= (ulong)dst;
        }

        return result.ToString();
    }
}