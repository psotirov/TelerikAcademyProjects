using System;

class AstrologicalDigits
{

    static int CalcAstroDigit(int number)
    {
        int result = 0; // initial result - empty
        while (number > 0) // until empty number
        {
            result += number % 10; // extracts last digit
            number /= 10; // shifts number one digit to the right
        }
        if (result > 9) result = CalcAstroDigit(result); // recursive call(s) until obtains the one digit result
        return result;
    }

    static void Main()
    {
        string input = Console.ReadLine(); // reads the number from the console
        int number = 0; // initial sum
        for (int i = 0; i < input.Length; i++)
        {
            int digit = input[i] - (int)'0'; // takes into account only digits
            if (digit >= 0 && digit <= 9)
            {
                number += digit;
            }
        }

        Console.WriteLine(CalcAstroDigit(number)); // prints the result on the console
    }
}

