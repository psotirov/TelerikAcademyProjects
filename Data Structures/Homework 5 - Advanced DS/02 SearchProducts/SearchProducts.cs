using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Wintellect.PowerCollections;

class ProductSearch
{
    const int CountProducts = 500000;
    const int CountSearches = 10000;
    const double MaxPrice = 10000.0;
    const double MinPrice = 10.0;
    const int CountResults = 20;

    private static Random randomNumberGenerator = new Random();



    private static void Main()
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();
        Console.WriteLine("Creating products data.....");
        OrderedMultiDictionary<double, string> products = GenerateProducts();
        timer.Stop();
        Console.WriteLine("Time needed: "+timer.Elapsed);
        timer.Reset();
        double lowestPrice = randomNumberGenerator.NextDouble() * (MaxPrice/2 - MinPrice) + MinPrice;
        double highestPrice = randomNumberGenerator.NextDouble() * (MaxPrice - lowestPrice) + lowestPrice;
        bool isFirstSearch = true;
        timer.Start();

        for (int i = 0; i < CountSearches; i++)
        {
            IEnumerable<KeyValuePair<double, ICollection<string>>> extract = products.Range(lowestPrice, true, highestPrice, true).Take(CountResults);
            if (isFirstSearch)
            {
                timer.Stop();
                Console.WriteLine("First search result");
                Console.WriteLine("Price range from {0:F2} to {1:F2}:", lowestPrice, highestPrice);
                PrintSearchResults(extract);
                isFirstSearch = false;
                Console.WriteLine("Time needed: {0}\n {1} more to go......", timer.Elapsed, CountSearches - 1);
                timer.Start();
            }
        }
        timer.Stop();
        Console.WriteLine("Total search time: "+timer.Elapsed);
    }

    private static OrderedMultiDictionary<double, string> GenerateProducts()
    {
        OrderedMultiDictionary<double, string> products = new OrderedMultiDictionary<double, string>(true /* = allow duplicate values*/);

        for (int i = 0; i < CountProducts; i++)
        {
            double price = randomNumberGenerator.NextDouble() * (MaxPrice - MinPrice) + MinPrice;
            string name = string.Format("Product with {0:N2} price", price);
            products.Add(price, name);
        }

        return products;
    }

    private static void PrintSearchResults(IEnumerable<KeyValuePair<double, ICollection<string>>> extract)
    {
        int count = 0;

        foreach (var pair in extract)
        {
            foreach (var name in pair.Value)
            {
                Console.WriteLine("{0,3}. {1}", count + 1, name);
                count++;
                if (count > CountResults)
                {
                    return;
                }
            }
        }
    }
}
