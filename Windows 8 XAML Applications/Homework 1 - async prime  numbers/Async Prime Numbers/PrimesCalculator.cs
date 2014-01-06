using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_Prime_Numbers
{
    public static class PrimesCalculator
    {
        public static async Task<List<int>> GetPrimesConcatenationsAsync(int rangeFirst, int rangeLast, bool onlyPrimes)
        {
            return await Task.Run( () => GetPrimesConcatenations(rangeFirst, rangeLast, onlyPrimes));
        }

        private static async Task<List<int>> GetPrimesConcatenations(int rangeFirst, int rangeLast, bool onlyPrimes)
        {
            List<int> primesList = await GetPrimesInRangeAsync(rangeFirst, rangeLast);

            List<int> primesConcatenations = new List<int>();

            foreach (var primeNumber in primesList)
            {
                string primeStr = primeNumber.ToString();
                char firstDigit = primeStr[primeStr.Length - 1];

                foreach (var primeNumberInner in primesList)
                {
                    string primeInnerStr = primeNumberInner.ToString();
                    char secondDigit = primeInnerStr[0];

                    if (firstDigit == secondDigit)
                    {
                        int newNumber = int.Parse(primeStr + primeInnerStr);
                        if (IsPrime(newNumber) == onlyPrimes)
                        {
                            primesConcatenations.Add(newNumber);                            
                        }
                    }
                }
            }

            return primesConcatenations;
        }

        public static async Task<List<int>> GetPrimesInRangeAsync(int rangeFirst, int rangeLast)
        {
            return await Task.Run( () =>
            {
                List<int> primes = new List<int>();

                for (int number = rangeFirst; number < rangeLast; number++)
                {
                    if (IsPrime(number))
                    {
                        primes.Add(number);
                    }
                }

                return primes;
            });
        }

        private static bool IsPrime(int number)
        {
            for (int divider = 2; divider < number; divider++)
            {
                if (number % divider == 0)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
