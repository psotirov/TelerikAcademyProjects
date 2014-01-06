using System;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace Feedzilla.Client
{
    class Application
    {
        private const int CategoriesPerLine = 3;
        private const int ArticlesPerQuery = 5;
        private const int ConsoleWindowWidth = 120;

        private static HttpClient feedzilla;

        static void Main(string[] args)
        {
            Console.WindowWidth = ConsoleWindowWidth;
            Console.WriteLine("Welcome to Feedzilla content provider\n\n");
            feedzilla = new HttpClient();
            feedzilla.BaseAddress = new Uri("http://api.feedzilla.com");

            while (true)
            {
                int categoryId = GetCategory();
                if (categoryId == 0)
                {
                    Console.WriteLine("\nThank you. Good bye!");
                    break;
                }

                Console.Write("Please enter some text to search [empty to see recent articles]: ");
                string query = Console.ReadLine().Trim();
                
                Console.Write("Please select how many results to show [default is {0}]: ", ArticlesPerQuery);
                int countResults = 0;
                if (!int.TryParse(Console.ReadLine().Trim(), out countResults) || countResults < 1 || countResults > 100)
                {
                    countResults = ArticlesPerQuery;
                }

                ShowResults(categoryId, query, countResults);

                Console.WriteLine("\nPress Enter to continue");
                Console.ReadLine();
            }
        }

        static int GetCategory()
        {
            int catId = 0;

            var categoriesResponse = feedzilla.GetAsync("/v1/categories.json").Result;
            if (categoriesResponse.IsSuccessStatusCode)
            {
                string content = categoriesResponse.Content.ReadAsStringAsync().Result;
                Category[] result = JsonConvert.DeserializeObject<Category[]>(content);
                for (int i = 1; i < result.Length; i++) // skips first category as internal
                {
                    Console.Write(result[i]);
                    if (i % CategoriesPerLine == 0)
                    {
                        Console.WriteLine();
                    }
                }

                Console.Write("\nPlease select category id [or 0 to exit]: ");
                int.TryParse(Console.ReadLine(), out catId);
            }

            return catId;
        }

        static void ShowResults(int category, string query, int count)
        {
            string serviceQuery = "/v1/categories/" + category + "/articles";
            if (query.Length > 0)
            {
                // search for article
                serviceQuery += "/search.json?q=" + query + "&count=" + count;
            }
            else
            {
                // take recent articles
                serviceQuery += ".json?count=" + count;
            }

            var artilceResponse = feedzilla.GetAsync(serviceQuery).Result;
            if (artilceResponse.IsSuccessStatusCode)
            {
                string content = artilceResponse.Content.ReadAsStringAsync().Result;
                int articlesArrayStart = content.IndexOf('[');
                if (articlesArrayStart > 0)
                {
                    // extract only inner JSON array of articles
                    content = content.Substring(articlesArrayStart);
                    content = content.Substring(0, content.LastIndexOf(']') + 1);                    
                }

                var settings = new JsonSerializerSettings();
                settings.MissingMemberHandling = MissingMemberHandling.Ignore;
                Article[] result = JsonConvert.DeserializeObject<Article[]>(content, settings);
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
