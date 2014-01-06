using System;
using System.Collections.Generic;

class EratosthenesSieve
{
    //To find all the prime numbers less than or equal to a given integer n by Eratosthenes' method:
    // 1. Create a list of consecutive integers from 2 to n: (2, 3, 4, ..., n).
    // 2. Initially, let p equal 2, the first prime number.
    // 3. Starting from p, count up in increments of p and mark each of these numbers greater than p itself in the list.
    //    These will be multiples of p: 2p, 3p, 4p, etc.; note that some of them may have already been marked.
    // 4. Find the first number greater than p in the list that is not marked. If there was no such number, stop. 
    //    Otherwise, let p now equal this number (which is the next prime), and repeat from step 3.
    //
    // When the algorithm terminates, all the numbers in the list that are not marked are prime.
    //
    // I. As a refinement, it is sufficient to mark the numbers in step 3 starting from p pow 2, as all the smaller multiples of p 
    // will have already been marked at that point. This means that the algorithm is allowed to terminate in step 4
    // when p pow 2 is greater than n (or p is greater than sqrt(n)).
    //
    // II. Another refinement is to initially list odd numbers only, (3, 5, ..., n), and count up using an increment of 2p in step 3, 
    // thus marking only odd multiples of p greater than p itself.
    //
    //The smallest 168 prime numbers (all the prime numbers under 1000) are:
    // 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 
    //  139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 
    //  283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 
    //  457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 
    //  631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 
    //  821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997

    static void Main()
    {
        Console.WriteLine("Task 15 - Quick sort algorithm\n\n");
        int total = 1000000; // find prime numbers in range of [1, 10 000 000] 
        bool[] isNotPrime = new bool[total / 2]; // only odd numbers (2p+1) to check, default value of each is false (i.e. all are assumed primes)

        int limit = (int)Math.Sqrt(total) + 1; // the testing range whether n is a multiple of any integer between 2 and sqrt(n) inclusive
        for (int i = 3; i < limit; i += 2) // As per II. above checks only odd elements
        {
            if (!isNotPrime[i/2-1]) // if the number is prime
            {
                for (int j = i*i ; j < total; j += 2*i) // then removes its multiplies of i*i, + 2*i, + 4*i..... 
                {
                    isNotPrime[j / 2 - 1] = true; // mark each that is not prime
                }            
            }
        }

        List<int> primes = new List<int>(); // creates a list of all prime numbers in the range
        primes.Add(2); // 2 is prime number

        for (int i = 1; i < isNotPrime.Length; i++)
        {
            if (!isNotPrime[i-1]) primes.Add(i * 2 + 1); // since the array is only for odd numbers, uses its index to calc the exact number
        }

        Console.WriteLine("Total prime numbers in the range [1, {0:N0}] are {1}\n", total, primes.Count);
        Console.Write("\nPress Enter to show them\n\n");
        Console.ReadLine();

        int newLine = 0;
        foreach (int prime in primes)
        {
            Console.Write("{0,8:N0}  ", prime);
            if (newLine > 0 && newLine++ % 10 == 0) Console.WriteLine();
        }

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }
}
