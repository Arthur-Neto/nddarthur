using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Infra.Twitter.Base;
using NDDTwitter.Infra.Twitter.Base.Exceptions;
using System;
using System.Collections.Generic;
using Tweetinvi.Models;

namespace NDDTwitter.Infra.Twitter.Features.Posts
{
    public class PostTwitterRepository : IPostRepository
    {
        ITwitterService _service;

        public PostTwitterRepository(ITwitterService service)
        {
            _service = service;
        }

        public void Delete(Post post)
        {
            if (post.Id == 0)
                throw new TwitterMessageIdentifierUndefinedException();
            _service.DeleteTweet(post.Id);
        }

        public Post Get(long id)
        {
            if (id == 0)
                throw new TwitterMessageIdentifierUndefinedException();
            Post post = Make(_service.GetTweet(id));
            return post;
        }

        public IEnumerable<Post> GetAll()
        {
            IList<Post> posts = new List<Post>();
            Post post;
            foreach (var item in _service.ListTweetsOnHomeTimeline())
            {
                post = Make(item);
                posts.Add(post);
            }
            return posts;
        }

        public Post Save(Post post)
        {
            post.Validate();
            if (string.IsNullOrWhiteSpace(post.Message))
                throw new TwitterMessageEmptyException();

            ITweet tweet = _service.SendTweet(post.Message);
            return Make(tweet);
        }

        public Post Update(Post post)
        {
            throw new NotImplementedException();
        }

        public Post Make(ITweet tweet)
        {
            if(tweet == null)
            {
                return null;
            }

            Post post = new Post()
            {
                Id = tweet.Id,
                Message = tweet.Text,
                PostDate = tweet.CreatedAt,
                DisplayPostDate = PostUtil.GetTimeAgoFromDateTime(tweet.CreatedAt)
            };

            return post;
        }
    }
}
