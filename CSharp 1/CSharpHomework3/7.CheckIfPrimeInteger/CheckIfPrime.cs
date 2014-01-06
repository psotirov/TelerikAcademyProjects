using System;

class CheckIfPrime
{
    static void Main()
    {
        int number = 1;
        while (number != 0)
	    {
            string input = Console.ReadLine();
            if (int.TryParse(input, out number) && (number > 1)) // 1 is not a prime nor a composite number
            {
                //Prime Numbers are 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113
                int MaxDivider = (int)Math.Round(Math.Sqrt(number)) + 1; // if the number is not prime, it has at least one divider in the range (1,sqrt(number))
                int i = 2; // the correction (MaxDivider + 1) ensures at least on flow through the for cycle (if the number is in the range [2, 6]
                for (; (i < MaxDivider) && (number % i != 0); i++);
                if (i == MaxDivider) Console.WriteLine("The number is prime");
                else Console.WriteLine("The number is not prime. Its first divider is " + i);
            }
        }
    } 
}
