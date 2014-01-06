using System;
using System.Numerics;

class Tribonacci
{
    static void Main()
    {
        //Tribonacci sequence: Tn = Tn-1 + Tn-2 + Tn-3
        BigInteger firstMember = BigInteger.Parse(Console.ReadLine());
        BigInteger secondMember = BigInteger.Parse(Console.ReadLine());
        BigInteger thirdMember = BigInteger.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());

        if (N == 1)
        {
            Console.WriteLine(firstMember);
            return;
        }

        if (N == 2)
        {
            Console.WriteLine(secondMember);
            return;
        }

        if (N == 3)
        {
            Console.WriteLine(thirdMember);
            return;
        }

        for (int i = 4; i <= N; i++)
        {
            BigInteger temp = firstMember; // shifts Ti to Ti-1 for all three members
            firstMember = secondMember;
            secondMember = thirdMember;
            thirdMember = temp + firstMember + secondMember; // Tn = Tn-1 + Tn-2 + Tn-3
        }

        Console.WriteLine(thirdMember);
    }
}
