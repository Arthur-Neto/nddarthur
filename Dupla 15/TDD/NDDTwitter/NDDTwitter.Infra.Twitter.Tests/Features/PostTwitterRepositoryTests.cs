using FluentAssertions;
using Moq;
using NDDTwitter.Common.Tests.Base;
using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Infra.Twitter.Base;
using NDDTwitter.Infra.Twitter.Base.Exceptions;
using NDDTwitter.Infra.Twitter.Features.Posts;
using NUnit.Framework;
using System;
using Tweetinvi;
using Tweetinvi.Models;
using System.Linq;
using System.Collections.Generic;

namespace NDDTwitter.Infra.Twitter.Tests.Features
{
    [TestFixture]
    public class PostTwitterRepositoryTests
    {
        Mock<ITwitterService> _service;
        IPostRepository _repository;
        Post _post;
        Mock<ITweet> _tweet;

        [SetUp]
        public void SetUp()
        {
            _service = new Mock<ITwitterService>();
            _repository = new PostTwitterRepository(_service.Object);
            _tweet = new Mock<ITweet>();
            _post = ObjectMother.GetPost();
        }

        [Test]
        [Order(0)]
        public void PostTwitterRepository_ShouldSavePost()
        {
            //Cenario
            _service.Setup(x => x.SendTweet(_post.Message)).Returns(_tweet.Object);
            //Acao
            Post resultado = _repository.Save(_post);
            //Verificacao
            _service.Verify(x => x.SendTweet(_post.Message));
            resultado.Id.Should().Be(_tweet.Object.Id);
        }

        [Test]
        [Order(1)]
        public void PostTwitterRepository_ShouldGetPost()
        {
            _service.Setup(x => x.GetTweet(_post.Id)).Returns(_tweet.Object);

            Post resultado = _repository.Get(_post.Id);

            _service.Verify(x => x.GetTweet(_post.Id));
            resultado.Id.Should().Be(_tweet.Object.Id);
        }

        [Test]
        [Order(2)]
        public void PostTwitterRepository_ShouldGetAll()
        {
            _tweet.Setup(x => x.Text).Returns("asd");
            _service.Setup(x => x.ListTweetsOnHomeTimeline()).Returns(new List<ITweet>() { _tweet.Object });

            IEnumerable<Post> tweets = _repository.GetAll();

            _service.Verify(x => x.ListTweetsOnHomeTimeline());

            tweets.Count().Should().BeGreaterThan(0);
            tweets.First().Message.Should().Be(_tweet.Object.Text);
        }

        [Test]
        [Order(2)]
        public void PostTwitterRepository_ShouldGetAllFakeTweetClass()
        {
            List<FakeTweet> fakes = new List<FakeTweet>();
            FakeTweet fake = new FakeTweet();
            fakes.Add(fake);
            _service.Setup(x => x.ListTweetsOnHomeTimeline()).Returns(fakes);

            IEnumerable<Post> tweets = _repository.GetAll();

            _service.Verify(x => x.ListTweetsOnHomeTimeline());

            tweets.Count().Should().BeGreaterThan(0);
            tweets.First().Message.Should().Be(fake.Text);
        }

        [Test]
        [Order(3)]
        public void PostTwitterRepository_ShouldDelete()
        {
            _service.Setup(x => x.DeleteTweet(_post.Id));

            _repository.Delete(_post);

            _service.Verify(x => x.DeleteTweet(_post.Id));
        }

        [Test]
        public void PostTwitterRepository_ShouldUpdate()
        {
            Action action = () => _repository.Update(_post);
            action.Should().Throw<NotImplementedException>();
            _service.VerifyNoOtherCalls();
        }

        [Test]
        public void PostTwitterRepository_ShouldThrowEmptyMessageException()
        {
            Post postErr = ObjectMother.GetNoMessagePost();
            Action action = () => _repository.Save(postErr);
            action.Should().Throw<PostMessageEmptyException>();
            _service.VerifyNoOtherCalls();
        }

        [Test]
        public void PostTwitterRepository_ShouldThrowMessageLengthException()
        {
            Post postErr = ObjectMother.GetMessageOverflowPost();
            Action action = () => _repository.Save(postErr);
            action.Should().Throw<PostMessageOverflowException>();
            _service.VerifyNoOtherCalls();
        }

        [Test]
        public void PostTwitterRepository_ShouldThrowIndentifierUndefinedExceptionOnDelete()
        {
            Post postErr = ObjectMother.GetInvalidIdPost();
            Action action = () => _repository.Delete(postErr);
            action.Should().Throw<TwitterMessageIdentifierUndefinedException>();
            _service.VerifyNoOtherCalls();
        }

        [Test]
        public void PostTwitterRepository_ShouldThrowIndentifierUndefinedExceptionOnGet()
        {
            Post postErr = ObjectMother.GetInvalidIdPost();
            Action action = () => _repository.Get(postErr.Id);
            action.Should().Throw<TwitterMessageIdentifierUndefinedException>();
            _service.VerifyNoOtherCalls();
        }
    }
}
