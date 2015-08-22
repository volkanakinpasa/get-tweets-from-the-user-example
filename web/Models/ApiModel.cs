using System;
using System.Configuration;

namespace web.Models
{
    public class ApiModel
    {
        public ApiModel()
        {
            OAuthConsumerKey = ConfigurationManager.AppSettings["OAuthConsumerKey"];
            OAuthConsumerSecret = ConfigurationManager.AppSettings["OAuthConsumerSecret"];
            OAuthUrl = ConfigurationManager.AppSettings["OAuthUrl"];
            ScreenName = ConfigurationManager.AppSettings["ScreenName"];
            UserTimeLineUrlFormat = ConfigurationManager.AppSettings["UserTimeLineUrlFormat"];
        }
        public string OAuthConsumerKey { get; set; }
        public string OAuthConsumerSecret { get; set; }
        public string OAuthUrl { get; set; }
        public string ScreenName { get; set; }
        public string SinceId { get; set; }
        public string UserTimeLineUrlFormat { get; set; }
    }
}