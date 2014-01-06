using System;
using System.Text;

class NumeralConversions
{
    const string digits = "0123456789ABCDEF";

    static void Main()
    {
        Console.WriteLine("Tasks 01 -06 HEX, DEC, BIN bilateral conversions\n");


        string[] numeral = { "DEC", "BIN", "DEC", "HEX", "HEX", "BIN", "HEX" };
        while (true)
        {
            Console.WriteLine("\n\nPlease select conversion:\n" +
                  "   0 - Exit\n" +
                  "   1 - DEC to BIN      3 - DEC to HEX      5 - HEX to BIN\n" +
                  "   2 - BIN to DEC      4 - HEX to DEC      6 - BIN to HEX");
            int choice = 0;
            int.TryParse(Console.ReadLine(), out choice);
            if (choice < 1 || choice > 6) return;
            Console.Write("\nPlease enter {0} number: ", numeral[choice-1]);
            string number = Console.ReadLine().ToUpper();
            switch (choice)
            {
                case 1: number = Dec2Bin(number); break;
                case 2: number = Bin2Dec(number); break;
                case 3: number = Dec2Hex(number); break;
                case 4: number = Hex2Dec(number); break;
                case 5: number = Hex2Bin(number); break;
                case 6: number = Bin2Hex(number); break;
                default: break;
            }

            Console.WriteLine("\nThe result {0} number: {1}", numeral[choice], number);
        }
    }

    static string Dec2Bin(string num)
    {
        StringBuilder bin = new StringBuilder();
        ulong dec = 0;
        ulong.TryParse(num, out dec);
        while (dec > 0)
        {
            bin.Insert(0, dec % 2);
            dec /= 2;
        }

        return bin.ToString();
    }

    static string Bin2Dec(string num)
    {
        ulong dec = 0;
        for (int i = 0; i < num.Length; i++)
        {
            int bDigit = num[i] - '0';
            if (bDigit == 0 || bDigit == 1)
            {
                dec = dec * 2 + (ulong)bDigit;
            }
        }
        return dec.ToString();
    }

    static string Dec2Hex(string num)
    {
        StringBuilder hex = new StringBuilder();
        ulong dec = 0;
        ulong.TryParse(num, out dec);
        while (dec > 0)
        {
            hex.Insert(0, digits[(int)dec%16]);
            dec /= 16;
        }

        return hex.ToString();
    }

    static string Hex2Dec(string num)
    {
        ulong dec = 0;
        for (int i = 0; i < num.Length; i++)
        {
            int bDigit = digits.IndexOf(num[i]);
            if (bDigit >= 0)
            {
                dec = dec * 16 + (ulong)bDigit;
            }
        }
        return dec.ToString();
    }

    static string Bin2Hex(string num)
    {
        StringBuilder hex = new StringBuilder();
        int hexDigit = 0;
        int count = 0;
        for (int i = num.Length - 1; i >= 0; i--)
        {
            int bDigit = num[i] - '0';
            if (bDigit == 0 || bDigit == 1)
            {
                hexDigit += bDigit * (1 << count);
                count++;
                if (count == 4 || i == 0)
                { 
                    hex.Insert(0, digits[hexDigit]);
                    count = 0;
                    hexDigit = 0;
                }
            }
        }
        return hex.ToString();
    }

    static string Hex2Bin(string num)
    {
        StringBuilder bin = new StringBuilder();
        for (int i = num.Length - 1; i >= 0; i--)
        {
            int hexDigit = digits.IndexOf(num[i]);
            for (int j = 0; (j < 4 && hexDigit >= 0); j++)
            {
                bin.Insert(0, hexDigit % 2);
                hexDigit /= 2;
            }
        }
        return bin.ToString();
    }
}
