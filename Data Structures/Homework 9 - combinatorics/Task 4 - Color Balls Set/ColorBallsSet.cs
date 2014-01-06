using System;
using System.Collections.Generic;
using System.Numerics;

/// <summary>
/// Task 4 - Color Balls Set - BGCoder 100/100
/// </summary>
class ColorBallsSet
{
    static void Main()
    {
        // reading balls and counts the number of each unique ball
        string balls = Console.ReadLine();
        Dictionary<char, int> uniqueBalls = new Dictionary<char, int>();
        for (int i = 0; i < balls.Length; i++)
        {
            if (uniqueBalls.ContainsKey(balls[i]))
            {
                uniqueBalls[balls[i]]++;
            }
            else
            {
                uniqueBalls.Add(balls[i], 1);
            }
        }

        // we are looking for all permutations of given balls without repetitions
        // we can calculate their count using following formula:
        // N! / A!.B!.......Z!
        // where N is total number of balls and A, B, C,.... are number of balls of each color 
        BigInteger countPermutations = Factorial(balls.Length);
        foreach (var uniqueBall in uniqueBalls)
        {
            countPermutations /= Factorial(uniqueBall.Value);
        }

        Console.WriteLine(countPermutations);
    }

    static BigInteger Factorial(int index)
    {
        if (index < 3)
        {
            return (BigInteger)index;
        }

        BigInteger result = 2;
        for (int i = 3; i <= index; i++)
        {
            result *= (BigInteger)i;
        }

        return result;
    }
}
