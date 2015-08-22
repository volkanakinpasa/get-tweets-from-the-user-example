using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Http;
using web.Managers;
using web.Models;

namespace web.Controllers
{
    public class TweetController : ApiController
    {
        [Route("api/tweet")]
        public TweetResultModel Get(string sinceId = null)
        {
            ApiModel apiModel = new ApiModel()
            {
                SinceId = sinceId
            };

            ITweetManager manager = new TweetManager(apiModel);

            NameValueCollection token = CookieManager.GetCookieValues("token");

            AuthenticateResponse authenticateResponse;

            if (token == null)
            {
                authenticateResponse = manager.GetToken();
                CookieManager.WriteCookie("token", new Dictionary<string, object>()
                                                   {
                                                       { "token_type", authenticateResponse.token_type },
                                                       { "access_token", authenticateResponse.access_token }
                                                   });
            }
            else
            {
                authenticateResponse = new AuthenticateResponse() { access_token = token["access_token"], token_type = token["token_type"] };
            }

            TweetResultModel tweetResultModel = manager.GetTweets(authenticateResponse.access_token, authenticateResponse.token_type);

            return tweetResultModel;
        }
    }
}
