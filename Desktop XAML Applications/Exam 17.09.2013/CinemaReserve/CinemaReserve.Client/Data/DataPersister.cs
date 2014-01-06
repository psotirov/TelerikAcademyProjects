using CinemaReserve.ResponseModels;
using CinemaReserve.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaReserve.Client.Data
{
    public class DataPersister
    {
        private const string baseUrl = @"http://localhost:50971/api/";

        internal static IEnumerable<CinemaViewModel> GetAllCinemas()
        {
            var headers = new Dictionary<string, string>();
            //headers["X-accessToken"] = "";

            var cinemaModels = HttpRequester.Get<IEnumerable<CinemaModel>>(
                string.Format("{0}cinemas", baseUrl),
                headers);
            var models = cinemaModels.AsQueryable().Select(cinema => new CinemaViewModel()
            {
                Id = cinema.Id,
                Name = cinema.Name,
            });

            return models;
        }

        internal static IEnumerable<MovieModel> GetCinemaMovies(int cinemaId)
        {
            var headers = new Dictionary<string, string>();
            //headers["X-accessToken"] = "";

            var movieModels = HttpRequester.Get<IEnumerable<MovieModel>>(
                string.Format("{0}cinemas/{1}", baseUrl, cinemaId),
                headers);
            var models = movieModels.AsQueryable().Select(movie => new MovieModel()
            {
                Id = movie.Id,
                Title = movie.Title,
            });

            return models;
        }

        internal static IEnumerable<ProjectionModel> GetMovieProjections(int cinemaId, int movieId)
        {
            var headers = new Dictionary<string, string>();
            //headers["X-accessToken"] = "";

            var projectionModels = HttpRequester.Get<IEnumerable<ProjectionModel>>(
                string.Format("{0}cinemas/{1}/projections/{2}", baseUrl, cinemaId, movieId),
                headers);
            var models = projectionModels.AsQueryable().Select(projection => new ProjectionModel()
            {
                Id = projection.Id,
                Time = projection.Time,
                Movie = projection.Movie,
                Cinema = projection.Cinema,
            });

            return models;
        }

        internal static IEnumerable<MovieViewModel> GetAllMovies()
        {
            var headers = new Dictionary<string, string>();
            //headers["X-accessToken"] = "";

            var movieModels = HttpRequester.Get<IEnumerable<MovieModel>>(
                string.Format("{0}movies", baseUrl),
                headers);
            var models = movieModels.AsQueryable().Select(movie => new MovieViewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
            });

            return models;
        }

        internal static MovieDetailsModel GetMovieDetails(int movieId)
        {
            var headers = new Dictionary<string, string>();
            //headers["X-accessToken"] = "";

            var movieDetails = HttpRequester.Get<MovieDetailsModel>(
                string.Format("{0}movies/{1}", baseUrl, movieId),
                headers);

            return movieDetails;
        }


        internal static IEnumerable<MovieViewModel> SearchMovies(string keyword)
        {
            var headers = new Dictionary<string, string>();
            //headers["X-accessToken"] = "";

            var movieModels = HttpRequester.Get<IEnumerable<MovieModel>>(
                string.Format("{0}movies?keyword={1}", baseUrl, keyword),
                headers);
            var models = movieModels.AsQueryable().Select(movie => new MovieViewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
            });

            return models;
        }

        //internal static void AddTag(string tagName)
        //{
        //    var headers = new Dictionary<string, string>();
        //    headers["X-accessToken"] = AccessToken;

        //    var newTag = new TagModel()
        //    {
        //        Name = tagName
        //    };

        //    HttpRequester.Post<TagModel>(string.Format("{0}tags", baseUrl), newTag, headers);
        //}

        //internal static void AddNewCategory(string title)
        //{
        //    var categoryModel = new CategoryModel()
        //    {
        //        Name = title
        //    };

        //    var headers = new Dictionary<string, string>();
        //    headers["X-accessToken"] = AccessToken;
        //    var response = HttpRequester.Post<CategoryModel>(baseUrl + "categories", categoryModel, headers);
        //}

        //internal static IEnumerable<AdvertisementViewModel> SearchByQueryString(string queryString)
        //{
        //    var headers = new Dictionary<string, string>();
        //    headers["X-accessToken"] = AccessToken;

        //    var models = HttpRequester.Get<IEnumerable<AdvertisementViewModel>>(string.Format("{0}advertisements?keyword={1}", baseUrl, queryString), headers);

        //    return models;
        //}

    }
}
