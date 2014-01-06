using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Blog.Data;
using Blog.Models;
using Blog.Services.Models;

namespace Blog.Services.Controllers
{
    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const string ValidUsernameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";
        private const string ValidDisplayNameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_. -";

        private static readonly Random rand = new Random();

        private const int Sha1Length = 40;

        public UsersController()
        {
        }

        /*
        {  "username": "DonchoMinkov",
           "displayName": "Doncho Minkov",
           "authCode":   "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e" }
        */

        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new BlogEntities();
                    using (context)
                    {
                        this.ValidateUsername(model.Username);
                        this.ValidateDisplayName(model.DisplayName);
                        this.ValidateAuthCode(model.AuthCode);
                        var usernameToLower = model.Username.ToLower();
                        var displaynameToLower = model.DisplayName.ToLower();
                        var user = context.Users.FirstOrDefault(
                            usr => usr.Username == usernameToLower
                            || usr.DisplayName.ToLower() == displaynameToLower);

                        if (user != null)
                        {
                            throw new InvalidOperationException("User exists");
                        }

                        user = new User()
                        {
                            Username = usernameToLower,
                            DisplayName = model.DisplayName,
                            AuthCode = model.AuthCode
                        };

                        context.Users.Add(user);
                        context.SaveChanges();

                        user.SessionKey = this.GenerateSessionKey(user.UserId);
                        context.SaveChanges();

                        var loggedModel = new LoggedUserModel()
                        {
                            DisplayName = user.DisplayName,
                            SessionKey = user.SessionKey
                        };

                        var response =
                            this.Request.CreateResponse(HttpStatusCode.Created,
                                            loggedModel);
                        return response;
                    }
                });

            return responseMsg;
        }

        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  var context = new BlogEntities();
                  using (context)
                  {
                      this.ValidateUsername(model.Username);
                      this.ValidateAuthCode(model.AuthCode);
                      var usernameToLower = model.Username.ToLower();
                      var user = context.Users.FirstOrDefault(
                          usr => usr.Username == usernameToLower
                          && usr.AuthCode == model.AuthCode);

                      if (user == null)
                      {
                          throw new InvalidOperationException("Invalid username or password");
                      }
                      if (user.SessionKey == null)
                      {
                          user.SessionKey = this.GenerateSessionKey(user.UserId);
                          context.SaveChanges();
                      }

                      var loggedModel = new LoggedUserModel()
                      {
                          DisplayName = user.DisplayName,
                          SessionKey = user.SessionKey
                      };

                      var response =
                          this.Request.CreateResponse(HttpStatusCode.Created,
                                          loggedModel);
                      return response;
                  }
              });

            return responseMsg;
        }

        [ActionName("logout")]
        public HttpResponseMessage PutLogoutUser(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  var context = new BlogEntities();
                  using (context)
                  {
                      int UserId = this.ValidateSessionKey(sessionKey);
                      var user = context.Users.Find(UserId);

                      if (user == null)
                      {
                          throw new InvalidOperationException("Invalid Session Key");
                      }
                      user.SessionKey = null;
                      context.SaveChanges();

                      var response = this.Request.CreateResponse(HttpStatusCode.OK);
                      return response;
                  }
              });

            return responseMsg;
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder skeyBuilder = new StringBuilder(SessionKeyLength);
            skeyBuilder.Append(userId);
            while (skeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                skeyBuilder.Append(SessionKeyChars[index]);
            }
            return skeyBuilder.ToString();
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1Length)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted");
            }
        }

        private void ValidateDisplayName(string displayName)
        {
            ValidateName(displayName, ValidDisplayNameCharacters, "Display Name");
        }

        private void ValidateUsername(string username)
        {
            ValidateName(username, ValidUsernameCharacters);
        }

        private void ValidateName(string name, string symbolsPermitted, string type = "Username")
        {
            if (name == null)
            {
                throw new ArgumentNullException(type + " cannot be null");
            }
            else if (name.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("{0} must be at least {1} characters long",
                    type, MinUsernameLength));
            }
            else if (name.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("{0} must be less than {1} characters long",
                    type, MaxUsernameLength));
            }
            else if (name.Any(ch => !symbolsPermitted.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    type + " must contain only Latin letters, digits .,_");
            }
        }
    }
}