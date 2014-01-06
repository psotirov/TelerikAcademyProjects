using System;
using System.Threading;

class NumberOperations
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        Console.WriteLine("15 - Perform some operations on set of numbers\n\n");

        Console.Write("Please enter numbers sequence (divided with spaces): ");
        string line = Console.ReadLine();

        bool hasDouble = (line.IndexOf('.') >= 0); // checks the string for decimal point in order to choose between int and double 
        string[] nums = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        dynamic[] numbers = new dynamic[nums.Length];
        bool isOK = true;
        for (int i = 0; i < nums.Length; i++)
        {
            if (hasDouble)
            {
                double n;
                isOK = double.TryParse(nums[i], out n); // parsing to double
                numbers[i] = (dynamic)n;
            }
            else
            {
                int n;
                isOK = int.TryParse(nums[i], out n); // parsing to int
                numbers[i] = (dynamic)n;
            }
            if (!isOK) // there is an error in parsing
            {
                Console.WriteLine("Wrong format of number sequence");
                return;
            }
        }

        Console.WriteLine("The minimum is " + CalcMinimum(numbers));
        Console.WriteLine("The maximum is " + CalcMaximum(numbers));
        Console.WriteLine("The average is " + CalcAverage(numbers));
        Console.WriteLine("The sum is " + CalcSum(numbers));
        Console.WriteLine("The product is " + CalcProd(numbers));

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }

    static T CalcMinimum<T>(params T[] numbs)
    {
        dynamic result = numbs[0];
        foreach (var n in numbs)
        {
            if (result.CompareTo(n) > 0) result = n;
        }

        return (T)result;
    }

    static T CalcMaximum<T>(params T[] numbs)
    {
        dynamic result = numbs[0];
        foreach (var n in numbs)
        {
            if (result.CompareTo(n) < 0) result = n;
        }

        return (T)result;
    }

    static T CalcAverage<T>(params T[] numbs)
    {
        dynamic result = numbs[0];
        int count = 0;
        for (int i = 1; i < numbs.Length; i++)
        {
            result += (dynamic)numbs[i];
            count++;
        }

        result /= count;
        return (T)result;
    }

    static T CalcSum<T>(params T[] numbs)
    {
        dynamic result = numbs[0];
        for (int i = 1; i < numbs.Length; i++)
        {
            result += (dynamic)numbs[i];
        }

        return (T)result;
    }

    static T CalcProd<T>(params T[] numbs)
    {
        dynamic result = numbs[0];
        for (int i = 1; i < numbs.Length; i++)
        {
            result *= (dynamic)numbs[i];
        }

        return (T)result;
    }
}
