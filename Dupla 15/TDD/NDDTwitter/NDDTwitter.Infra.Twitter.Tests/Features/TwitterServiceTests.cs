using FluentAssertions;
using NDDTwitter.Infra.Twitter.Base;
using NDDTwitter.Infra.Twitter.Base.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Tweetinvi.Models;

namespace NDDTwitter.Infra.Twitter.Tests.Features
{
    [TestFixture]
    public class TwitterServiceTests
    {
        TwitterService _service;
        string message;
        ITweet tweet;

        [SetUp]
        public void SetUp()
        {
            _service = new TwitterService();
            _service.SetCredentials();
            message = "testapi";
        }

        [Test]
        [Order(1)]
        public void TwitterService_ShouldPublishTweet()
        {
            tweet = _service.SendTweet(message);
            tweet.Text.Should().Be(message);
        }

        [Test]
        [Order(2)]
        public void TwitterService_ShouldGetTweet()
        {
            var post = _service.GetTweet(tweet.Id);
            post.Text.Should().Be(message);
        }

        [Test]
        [Order(3)]
        public void TwitterService_ShouldGetAllTweets()
        {
            IEnumerable<ITweet> tweets = _service.ListTweetsOnHomeTimeline();
            List<ITweet> lista = new List<ITweet>();
            foreach (var item in tweets)
            {
                lista.Add(item);
            }
            lista.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(4)]
        public void TwitterService_ShouldDeleteTweet()
        {
            bool result = _service.DeleteTweet(tweet.Id);
            result.Should().Be(true);
        }

        [Test]
        [Order(5)]
        public void TwitterService_ShouldReturnExceptionMaxCharacters()
        {
            message = "asdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiuasdokasjdoiasdiousaiudsaiu";
            Action acao = () => tweet = _service.SendTweet(message);
            acao.Should().Throw<TwitterMessageLengthOverflowException>();
        }

        [Test]
        [Order(6)]
        public void TwitterService_ShouldReturnExceptionOnGetId()
        {
            var post = _service.GetTweet(99999999);
            post.Should().BeNull();
        }
    }
}
