using System;
using NUnit.Framework;
using NDDTwitter.Infra;
using NDDTwitter.Domain.Exceptions;
using FluentAssertions;
using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Common.Tests.Base;

namespace NDDTwitter.Domain.Tests.Features.Posts
{
    [TestFixture]
    public class PostTests
    {
        Post post;
        [SetUp]
        public void TestSetup()
        {
            post = ObjectMother.GetPost();
        }

        [Test]
        public void Posts_ShouldValidateAllOk()
        {
            post.DisplayPostDate = PostUtil.GetTimeAgoFromDateTime(post.PostDate);
            post.Validate();
        }

        [Test]
        public void Posts_ShouldThrowExceptionEmptyMessage()
        {
            post = ObjectMother.GetNoMessagePost();
            post.DisplayPostDate = PostUtil.GetTimeAgoFromDateTime(post.PostDate);
            Action action = () => post.Validate();
            action.Should().Throw<PostMessageEmptyException>();
        }

        [Test]
        public void Posts_ShouldThrowExceptionMaxCharacters()
        {
            post = ObjectMother.GetMessageOverflowPost();
            post.DisplayPostDate = PostUtil.GetTimeAgoFromDateTime(post.PostDate);
            Action action = () => post.Validate();
            action.Should().Throw<PostMessageOverflowException>();
        }

        [Test]
        public void Posts_ShouldThrowExceptionDateCreationHigherDateNow()
        {
            post = ObjectMother.GetInvalidPostDatePost();
            post.DisplayPostDate = PostUtil.GetTimeAgoFromDateTime(post.PostDate);
            Action action = () => post.Validate();
            action.Should().Throw<PostDateOverflowException>();
        }
    }
}
