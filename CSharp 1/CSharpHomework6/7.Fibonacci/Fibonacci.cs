using System;
using System.Numerics;


class Fibonacci
{
    static void Main()
    {
        //Fibonacci sequence: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
        BigInteger firstMember = 0;
        BigInteger secondMember = 1;
        BigInteger Sum = 1; // the sum of first two elements
        int N = 0;

        Console.WriteLine("Sum of N members in Fibonacci sequence:\n0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, ...\n");
        Console.Write("Please enter the number of elements N: ");
        if (!int.TryParse(Console.ReadLine(), out N) || N < 3) return;

        for (int i = 3; i <= N; i++)
        {
            secondMember = firstMember + secondMember;
            firstMember = secondMember - firstMember;
            Sum += secondMember;
        }

        Console.WriteLine("The sum is " + Sum);
    }
}
