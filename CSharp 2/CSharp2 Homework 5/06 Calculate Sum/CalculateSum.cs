using System;

class CalculateSum
{
    static void Main()
    {
        Console.WriteLine("Task 06 - Calculate sum of values as per user input\n\n");

        Console.Write("Please enter a sequence of values (separated with spaces): ");
        string values = Console.ReadLine();

        int sum = SumValues(values);
        if (sum > 0) Console.WriteLine("The sum is " + sum);
        else Console.WriteLine("Incorrect Input!"); 

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
    static int SumValues(string vals)
    {
        int sum = 0;
        string[] nums = vals.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        foreach (string num in nums)
        {
            int val = 0;
            if (!int.TryParse(num, out val) || val < 0) return -1; // signals for parsing error
            sum += val;
        }
        return sum;
    }
}

