using web.Models;

namespace web.Managers
{
    public interface ITweetManager
    {
        AuthenticateResponse GetToken();
        TweetResultModel GetTweets(string accessToken, string tokenType);
    }
}