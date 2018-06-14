using FluentAssertions;
using NDDTwitter.Application.Features.Posts;
using NDDTwitter.Common.Tests.Base;
using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Infra.Twitter.Base;
using NDDTwitter.Infra.Twitter.Base.Exceptions;
using NDDTwitter.Infra.Twitter.Features.Posts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NDDTwitter.Integration.Tests.Features.Posts
{
    [TestFixture]
    public class PostIntegrationTwitterTests
    {
        IPostService _service;
        ITwitterService _serviceTwitter;
        PostTwitterRepository _repository;
        Post _post;
        Post _result;

        [SetUp]
        public void SetUp()
        {
            _serviceTwitter = new TwitterService();
            _repository = new PostTwitterRepository(_serviceTwitter);
            _service = new PostService(_repository);

            _post = ObjectMother.GetPost();
        }

        [Test]
        [Order(0)]
        public void PostIntegrationTwitter_Add_ShouldBeOk()
        {
            _result = _service.Add(_post);
            _result.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(1)]
        public void PostIntergrationTwitter_Get_ShouldBeOk()
        {
            Post result = _service.Get(_result.Id);
            result.Id.Should().Be(_result.Id);
        }

        [Test]
        [Order(2)]
        public void PostIntegrationTwitter_GetAll_ShouldBeOk()
        {
            IEnumerable<Post> list = _service.GetAll();
            list.Count().Should().BeGreaterThan(0);
            list.First().Id.Should().Be(_result.Id);
        }

        [Test]
        [Order(3)]
        public void PostIntegrationTwiiter_Delete_ShouldBeOk()
        {
            _service.Delete(_result);
            Post resultado = _repository.Get(_result.Id);
            resultado.Should().BeNull();
        }

        [Test]
        public void PostIntergrationTwitter_Add_ShouldThrowPostMessageEmptyException()
        {
            _post = ObjectMother.GetNoMessagePost();
            Action action = () => _service.Add(_post);
            action.Should().Throw<PostMessageEmptyException>();
            IEnumerable<Post> list = _service.GetAll();
            list.Should().NotContain(_post);

        }

        [Test]
        public void PostIntergrationTwitter_Add_ShouldThrowPostMessageOverflowException()
        {
            _post = ObjectMother.GetMessageOverflowPost();
            Action action = () => _service.Add(_post);
            action.Should().Throw<PostMessageOverflowException>();
            IEnumerable<Post> list = _service.GetAll();
            list.Should().NotContain(_post);
        }

        [Test]
        public void PostIntergrationTwitter_Add_ShouldThrowInvalidPostDateException()
        {
            _post = ObjectMother.GetInvalidPostDatePost();
            Action action = () => _service.Add(_post);
            action.Should().Throw<PostDateOverflowException>();
            IEnumerable<Post> list = _service.GetAll();
            list.Should().NotContain(_post);
        }
        
        [Test]
        public void PostIntergrationTwitter_Delete_ShouldThrowIdentifierUndefinedException()
        {
            _post = ObjectMother.GetInvalidIdPost();
            Action action = () => _service.Delete(_post);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void PostIntergrationTwitter_Get_ShouldReturnNull()
        {
            Post resultado = _service.Get(1);
            resultado.Should().BeNull();
        }
    }
}
