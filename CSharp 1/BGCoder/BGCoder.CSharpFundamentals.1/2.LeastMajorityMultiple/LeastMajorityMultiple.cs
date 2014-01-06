using System;

class LeastMajorityMultiple
{
    static int GCD(int a, int b) // Greatest Common Divisor - Euclidean's algorithm, based on differences
    {
        while (a != b)
        {
            if (a > b) a -= b;
            else b -= a;
        }
        return a;
    }

    static void Main()
    {
        int numbersCount = 5; // The quantity of numbers to lookup for LMM

        int[] numbers = new int[numbersCount];
        for (int i = 0; i < 5; i++) // Loop to enter numbers
        {
            numbers[i] = int.Parse(Console.ReadLine()); // reads a number from the console
        }

        int LMM = int.MaxValue; // Least Majority Multiple takes the greatest possible number as initial value (all others should be less)
        for (int i = 0; i < numbersCount - 2; i++) // prepares all number combinations in the next three loops  
            for (int j = i + 1; j < numbersCount - 1; j++)
                for (int k = j + 1; k < numbersCount; k++)
                {
                    int LCM1 = numbers[i] * numbers[j] / GCD(numbers[i], numbers[j]);
                    // Least Common Multiply of i-th and j-th element (LCM * GCD = i-th * j-th)

                    int LCM2 = numbers[j] * numbers[k] / GCD(numbers[j], numbers[k]);
                    // Least Common Multiply of j-th and k-th element (LCM * GCD = j-th * k-th)

                    LCM1 = LCM1 * LCM2 / GCD(LCM1, LCM2);
                    // Least Common Multiply of LCM(i,j) and LCM(J,k) - that gives LCM of all three numbers


                    if (LCM1 < LMM) LMM = LCM1; // Looks for the smallest possible LCM - this should be LMM
                }

        Console.WriteLine(LMM);
    }
}
