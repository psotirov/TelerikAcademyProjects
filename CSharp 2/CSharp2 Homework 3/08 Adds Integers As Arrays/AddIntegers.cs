using System;

class AddsIntegersAsDigits
{
    static void Main()
    {
        Console.WriteLine("Task 08 - Adds two integers as arrays of its digits\n\n");

        int num1 = 0;
        Console.Write("Please enter first number: ");
        string num = Console.ReadLine();
        int len = num.Length; // counts number of digits
        if (!int.TryParse(num, out num1) || num1 <= 0) // incorrect integer was entered
        {
            Console.WriteLine("Not a valid integer");
            return;
        }

        int num2 = 0;
        Console.Write("Please enter first number: ");
        num = Console.ReadLine();
        if (len < num.Length) len=num.Length; // takes the greater number of digits
        if (!int.TryParse(num, out num2) || num2 <= 0) // incorrect integer was entered
        {
            Console.WriteLine("Not a valid integer");
            return;
        }

        int[][] nums = new int[3][]; // creates array 0-first number, 1-second number, 2- result (len+1 to carry out the possible overflow)
        for (int i = 0; i < 3; i++)
            nums[i] = new int[len + 1];

        // fills the array with numbers' digits
        for (int i = 0; i < len; i++)
        {
            nums[0][i] = num1 % 10;
            num1 /= 10;
            nums[1][i] = num2 % 10;
            num2 /= 10;
        }

        AddNumbers(nums);
        Array.Reverse(nums[2]); // reverses the digits positions of the result, then Concat will show the result number correcty
        Console.WriteLine("The result is " + String.Concat(nums[2]).TrimStart('0'));

        Console.WriteLine("\nPlease hit Enter to finish");
        Console.ReadLine();
    }

    static void AddNumbers(int[][] numbs)
    {
        for (int i = 0; i < numbs[0].Length-1; i++) //iterates through all digits of numbers
        {
            int partial = numbs[0][i] + numbs[1][i]; // partial sum of current digits
            if (partial > 9) // we have overflow in current sum
            {
                numbs[2][i + 1] = 1; // increases the next position 
                partial %= 10; 
            }
            numbs[2][i] += partial;
        }
    }
}