namespace AspNetWebApi.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using CodeFirst.Models;

    public class Program
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:28670/") };

        internal static void Main()
        {
            // Add an Accept header for JSON format.
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // Add an Accept header for XML format.
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/xml"));

            GetArtists();
            AddNewArtist("Some Artist", "Some Country", DateTime.Now.Date);
            GetArtists();
        }

        internal static void AddNewArtist(string name, string country, DateTime birthdate)
        {
            var artist = new Artist { Name = name, Country = country, BirthDate = birthdate };

            // use one of the following two lines per round
            var response = Client.PostAsXmlAsync("api/artists", artist).Result;
            // var response = Client.PostAsJsonAsync("api/artists", artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void GetArtists()
        {
            HttpResponseMessage response = Client.GetAsync("api/artists").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                foreach (var artist in artists)
                {
                    Console.WriteLine("{0,4} {1,-20} {2}", artist.ArtistId, artist.Name, artist.Country);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
