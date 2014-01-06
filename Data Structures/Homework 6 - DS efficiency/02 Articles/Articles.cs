using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02_Articles
{
    class Articles
    {
        const int CountProducts = 50000;
        const double MaxPrice = 1000.0;
        const double MinPrice = 10.0;

        private static void Main()
        {
            Console.WriteLine("Creating articles data.....");
            OrderedMultiDictionary<double, Article> articles = GenerateProducts();

            double lowestPrice = 100.00;
            double highestPrice = 120.00;

            IEnumerable<KeyValuePair<double, ICollection<Article>>> extract =articles.Range(lowestPrice, true, highestPrice, true);
            Console.WriteLine("Search result for a price range from {0:F2} to {1:F2}:", lowestPrice, highestPrice);
            int count = 1;
            foreach (var pair in extract)
            {
                foreach (var item in pair.Value)
                {
                    Console.WriteLine("{0,3}. {1} - {2,7:N2} lv", count, item, pair.Key);
                    count++;
                }

            }
        }

        private static OrderedMultiDictionary<double, Article> GenerateProducts()
        {
            Random randomNumberGenerator = new Random();

            OrderedMultiDictionary<double, Article> articles = new OrderedMultiDictionary<double, Article>(true /* = allow duplicate values*/);

            for (int i = 0; i < CountProducts; i++)
            {
                double price = (randomNumberGenerator.Next(Convert.ToInt32(MaxPrice - MinPrice) * 100) + MinPrice) / 100.0;
                articles.Add(price, new Article(string.Format("Article {0,5}",(i+1))));
            }

            return articles;
        }
    }
}
