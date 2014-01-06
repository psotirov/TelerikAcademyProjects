using System;
using System.Text;

class Float2Binary
{
    static void Main()
    {
        Console.WriteLine("Task 09 - Binary representation of single float (IEEE754-2008 binary32)\n\n");

        Console.Write("\n\nPlease enter number [{0},{1}]: ", float.MinValue, float.MaxValue);
        double number = 0;
        if (!double.TryParse(Console.ReadLine(), out number) /*|| number <= float.MinValue || number >= float.MaxValue*/)
        {
            Console.WriteLine("Wrong FLOAT number");
            return;
        }

        int sign = 0;
        int exponent = 0;

        // retrieving the single precision value
        if (number < 0) // first - number sign
        {
            sign = 1;
            number = -number;
        }

        // normalizing mantissa and extracting exponent
        while (number != 0.0 && (number < 1.0 || number >= 2.0))
        {
            if (number < 1.0) // negative binary exponent
            {
                number = number * 2.0; // equals to number / 2^-1
                exponent--;
            }
            else //positive binary exponent
            {
                number = number / 2.0; // equals to number / 2^-1
                exponent++;
            }
        }

        // checking exponent for special cases
        if (exponent <= -127) // here we have subnormal number
        {
            exponent = -127;
            number /= 2.0; // in subnormal number we have representaion as 0.xxxxxxxxxx * 2^-127
        }
        else if (exponent >= 128) // here we have overflow (+/- INFINITY)
        {
            exponent = 128; // special case where after biasing (+127) the exponent will have all bits set to 1 (255).
            number = 1.0; // after extracting the leading integer part it will become 0. 
        }
        
        Console.WriteLine("\n\nFLOAT number Sign: " + sign);
        Console.WriteLine("\nExponent number: " + exponent);
        Console.WriteLine("\nFLOAT Mantissa: " + number);

        if (number >= 1.0) number -= 1.0; // finally extracts the leading 1.0 from the mantissa since it is not represented in the memory 
        Console.WriteLine("\n\n                   S SEEEEEEE MMMMMMMMMMMMMMMMMMMMMMM\n" + 
                              "                   3 32222222 22211111111110000000000\n" +
                              "                   1 09876543 21098765432109876543210\n" +
                            "\nThe result number: {0} {1} {2}",
                            sign.ToString(), Dec2Bin(exponent+127).PadLeft(8, '0'), FractDec2Bin(number, 23).PadRight(23, '0'));

        Console.WriteLine("\nPress Enter to exit");
        Console.ReadLine();
    }

    static string Dec2Bin(int num)
    {
        StringBuilder bin = new StringBuilder();

        while (num > 0)
        {
            bin.Insert(0, num % 2);
            num /= 2;
        }

        return bin.ToString();
    }

    static string FractDec2Bin(double num, int precision)
    {
        if (num == 0.0) return "0"; // otherwise enters in endless loop
        StringBuilder bin = new StringBuilder();
        while (num > 0.0 && precision > 0)
        {
            num *= 2.0; // equals to num / 2^-1 (shifting left)
            int digit = 0;
            if (num > 1.0) // we have 1 into the last fraction position 
            {
                num -= 1.0; // extracting the fration digit and goes to the next position
                digit = 1;
            }
            bin.Append(digit);
            precision--;
        }
        // perform rounding if needed
        if (precision == 0 && num * 2.0 > 1.0) // we have 1 as next fraction bit after precision
        {
            int pos = bin.Length-1; // starts from back (right side)
            while (pos >= 0 && bin[pos] == '1') // looking for the first possible zero
            {
                bin[pos] = '0'; // clears that '1'
                pos--; // and goes to the left
            }
            bin[pos] = '1'; // sets first possible 0 position to 1
            // example 0.0011111111(1) = 0.0100000000
        }

        return bin.ToString();
    }
}