using SimpleAdvertisementSystem.WpfClient.Models;
using SimpleAdvertisementSystem.WpfClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAdvertisementSystem.WpfClient.Data
{
    public class DataPersister
    {
        private const string baseUrl = @"http://localhost:40524/api/";
        protected static string AccessToken { get; set; }

        internal static void RegisterUser(string username, string email, string password)
        {
            // TODO: Validate!

            var userModel = new UserModel()
            {
                Username = username,
                Email = email,
                AuthCode = password
            };

            HttpRequester.Post(
                string.Format("{0}users/register", baseUrl),
                userModel);
        }

        internal static string LoginUser(string username, string sha1Password)
        {
            var userModel = new UserModel()
            {
                Username = username,
                AuthCode = sha1Password
            };

            var loginResponse = HttpRequester.Post<LoginResponseModel>(
                string.Format("{0}auth/token", baseUrl),
                userModel);

            AccessToken = loginResponse.AccessToken;

            return loginResponse.Username;
        }

        internal static bool LogoutUser()
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;
            var isLogoutSuccessful = HttpRequester.Put(string.Format("{0}users/logout", baseUrl), headers);
            return isLogoutSuccessful;
        }

        internal static IEnumerable<AdvertisementViewModel> GetAllAdvertisements()
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;

            var advertisementsModels = HttpRequester.Get<IEnumerable<AdvertisementModel>>(string.Format("{0}advertisements", baseUrl), headers);
            var models = advertisementsModels.AsQueryable().Select(ad => new AdvertisementViewModel()
            {
                Id = ad.Id,
                Text = ad.Text,
                Title = ad.Title,
                Tags = ad.Tags,
                CategoryId = ad.CategoryId
            });

            return models;
        }

        internal static IEnumerable<AdvertisementViewModel> GetAllAdvertisementsByTag(int tagId)
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;

            var advertisementsModels = HttpRequester.Get<IEnumerable<AdvertisementModel>>(string.Format("{0}tags/{1}/posts", baseUrl, tagId), headers);
            var models = advertisementsModels.AsQueryable().Select(ad => new AdvertisementViewModel()
            {
                Id = ad.Id,
                Text = ad.Text,
                Title = ad.Title,
                Tags = ad.Tags
            });

            return models;
        }

        internal static IEnumerable<AdvertisementViewModel> GetAllAdvertisementsByCategory(int categoryId)
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;

            var advertisementsModels = HttpRequester.Get<IEnumerable<AdvertisementModel>>(string.Format("{0}categories/{1}/posts", baseUrl, categoryId), headers);
            var models = advertisementsModels.AsQueryable().Select(ad => new AdvertisementViewModel()
            {
                Id = ad.Id,
                Text = ad.Text,
                Title = ad.Title,
                Tags = ad.Tags
            });

            return models;
        }

        internal static IEnumerable<TagViewModel> GetAllTags()
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;

            var tagModels = HttpRequester.Get<IEnumerable<TagViewModel>>(string.Format("{0}tags", baseUrl), headers);
            var models = tagModels.AsQueryable().Select(tag => new TagViewModel()
            {
                Id = tag.Id,
                Name = tag.Name,
                Posts = tag.Posts
            });

            return models;
        }


        internal static IEnumerable<CategoryViewModel> GetAllCategories()
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;
            var categoriesModels = HttpRequester.Get<IEnumerable<CategoryViewModel>>(string.Format("{0}categories", baseUrl), headers);
            var models = categoriesModels.AsEnumerable().Select(cat => new CategoryViewModel()
            {
                CategoryId = cat.CategoryId,
                Name = cat.Name
            });

            return models;
        }

        internal static void AddTag(string tagName)
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;

            var newTag = new TagModel()
            {
                Name = tagName
            };

            HttpRequester.Post<TagModel>(string.Format("{0}tags", baseUrl), newTag, headers);
        }

        internal static void AddNewCategory(string title)
        {
            var categoryModel = new CategoryModel()
            {
                Name = title
            };

            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;
            var response = HttpRequester.Post<CategoryModel>(baseUrl + "categories", categoryModel, headers);
        }

        internal static IEnumerable<AdvertisementViewModel> SearchByQueryString(string queryString)
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;

            var models = HttpRequester.Get<IEnumerable<AdvertisementViewModel>>(string.Format("{0}advertisements?keyword={1}", baseUrl, queryString), headers);

            return models;
        }

        public static IEnumerable<CommentViewModel> GetAllComments()
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;
            var commentsModels = HttpRequester.Get<IEnumerable<CommentViewModel>>(string.Format("{0}comments", baseUrl), headers);
            var models = commentsModels.AsEnumerable().Select(com => new CommentViewModel()
            {
                CommentId = com.CommentId,
                CommentedBy = com.CommentedBy,
                PostDate = com.PostDate,
                Text = com.Text
            });

            return models;
        }

        public static void AddNewAdvertisement(object advertisement)
        {
            var adv = advertisement as AdvertisementViewModel;
            if (adv == null)
            {
                return;
            }

            var advModel = new AdvertisementModel
            {
                Tags = adv.Tags,
                Text = adv.Text,
                CategoryId = adv.CategoryId,
                Title = adv.Title
            };

            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;
             HttpRequester.Post<AdvertisementModel>(baseUrl + "advertisements", advModel, headers);
        }
    }
}
