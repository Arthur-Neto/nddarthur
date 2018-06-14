using NDDTwitter.Infra.Twitter.Base.Exceptions;
using System.Collections.Generic;
using Tweetinvi;
using Tweetinvi.Models;

namespace NDDTwitter.Infra.Twitter.Base
{
    public class TwitterService : ITwitterService
    {
        public TwitterService()
        {
            SetCredentials();
        }

        public bool DeleteTweet(long id)
        {
            if (id < 0)
                throw new TwitterMessageIdentifierUndefinedException();
            return Tweet.DestroyTweet(id);
        }

        public ITweet GetTweet(long id)
        {
            if (id < 0)
                throw new TwitterMessageIdentifierUndefinedException();
            return Tweet.GetTweet(id);
        }

        public IEnumerable<ITweet> ListTweetsOnHomeTimeline()
        {
            return Timeline.GetHomeTimeline();
        }

        public ITweet SendTweet(string message)
        {
            if (message.Length > 140)
                throw new TwitterMessageLengthOverflowException();
            if (string.IsNullOrWhiteSpace(message))
                throw new TwitterMessageEmptyException();
            return Tweet.PublishTweet(message);
        }

        public void SetCredentials()
        {
            Auth.SetUserCredentials("iPRnOxSSRUspvsy7t15a3zi0h", "qlV3cndKhLlyzS8wngk22X3JnHz1pR8CpRu8tko0SPhqyFGAOS", "186853301-5YSbiB23WFmI4ITpcHVElSjsEoMdnzimlGlrxEzN", "mg7A2leGWS4x1SyYQxKLXPYptfHWJS36Zna8IezUR7nDG");
        }
    }
}
