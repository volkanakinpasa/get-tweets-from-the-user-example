using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using web.Models;

namespace web.Managers
{
    public class TweetManager : ITweetManager
    {
        private readonly ApiModel _apiModel;

        public TweetManager(ApiModel apiModel)
        {
            _apiModel = apiModel;
        }
        public AuthenticateResponse GetToken()
        {
            string tokenResult = Requests.GetToken(_apiModel.OAuthUrl, _apiModel.OAuthConsumerKey, _apiModel.OAuthConsumerSecret);
            return JsonConvert.DeserializeObject<AuthenticateResponse>(tokenResult);
        }

        public TweetResultModel GetTweets(string accessToken, string tokenType)
        {
            TweetResultModel retVal = new TweetResultModel();

            string timeLineResult = Requests.GetTweets(GetTimeLineUrl(), _apiModel.ScreenName, tokenType, accessToken);
            
            retVal.Tweets = JsonConvert.DeserializeObject<List<Tweet>>(timeLineResult);

            if (retVal.Tweets != null && retVal.Tweets.Any())
            {
                Tweet lastTweet = retVal.Tweets.FirstOrDefault();
                if (lastTweet != null) retVal.LastTweetId = Convert.ToString(lastTweet.id);
            }
            return retVal;
        }

        private string GetTimeLineUrl()
        {
            string url = string.Format(_apiModel.UserTimeLineUrlFormat, _apiModel.ScreenName);

            if (!string.IsNullOrEmpty(_apiModel.SinceId))
            {
                url += string.Format("&since_id={0}", _apiModel.SinceId);
            }

            return url;
        }



    }
}