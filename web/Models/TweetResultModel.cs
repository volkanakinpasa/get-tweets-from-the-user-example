using System;
using System.Collections.Generic;

namespace web.Models
{
    public class TweetResultModel
    {
        public List<Tweet> Tweets { get; set; }
        public string LastTweetId { get; set; }
    }
}