using System;

class Integer3Digit
{
    static void Main()
    {
        string input = Console.ReadLine();
        int number = 0;
        if (int.TryParse(input, out number) && (number != 0))
        {
            input = number.ToString();
            char digit = input[input.Length - 3];
            if (digit == '7') Console.WriteLine("The third digit of the number is 7");
            else Console.WriteLine("The third digit of the number is not 7, it is " + digit);
        }
    }
}
