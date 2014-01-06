using System;
using System.Numerics;


class Fibonacci
{
    static void Main()
    {
        //Fibonacci sequence: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
        BigInteger firstMember = 0;
        BigInteger secondMember = 1;
        Console.WriteLine("1-{0}", firstMember);
        Console.WriteLine("2-{0}", secondMember);
        for (int i = 3; i < 101; i++)
        {
            secondMember = firstMember + secondMember;
            firstMember = secondMember - firstMember;
            if (secondMember < firstMember)
            {
                Console.Write("OVERFLOW !!!!!!");
                return;
            }
            Console.WriteLine("{0,-3} - {1}", i, secondMember);
        }
    }
}
