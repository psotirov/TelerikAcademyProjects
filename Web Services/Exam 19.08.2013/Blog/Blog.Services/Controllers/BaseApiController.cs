using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;

namespace Blog.Services.Controllers
{
    public class BaseApiController : ApiController
    {
        protected const string SessionKeyChars =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";

        protected const int SessionKeyLength = 50;

        protected T PerformOperationAndHandleExceptions<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errResponse);
            }
        }


        protected int ValidateSessionKey(string sessionKey)
        {
            if (sessionKey == null || sessionKey.Length != SessionKeyLength)
            {
                throw new ArgumentOutOfRangeException(string.Format("Session Key must be {0} characters long", SessionKeyLength));
            }

            int userId = 0;
            for (int i = 0; i < sessionKey.Length; i++)
            {
                if (!char.IsDigit(sessionKey[i]))
                {
                    sessionKey = sessionKey.Substring(i);
                    break;
                }

                userId = userId * 10 + (sessionKey[i] - '0');
            }

            if (sessionKey.Any(ch => !SessionKeyChars.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Session Key must contain only Latin letters after UserId");
            }

            return userId;
        }
    }
}
