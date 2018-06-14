using System;
using NUnit.Framework;
using FluentAssertions;
using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Common.Tests.Base;
using NDDTwitter.Infra.Data.Features.Posts;
using System.Collections.Generic;
using NDDTwitter.Domain.Exceptions;

namespace NDDTwitter.Infra.Data.Tests.Features.Posts
{
    [TestFixture]
    public class PostSqlRepositoryTest
    {
        PostRepository repository;
        Post post;

        [SetUp]
        public void SetUp()
        {
            repository = new PostRepository();
            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void PostSqlRepository_ShouldAddIntoDataBase()
        {
            post = ObjectMother.GetPost();

            Post postSaved = repository.Save(post);
            postSaved.Id.Should().Be(post.Id);
        }

        [Test]
        public void PostSqlRepository_ShouldUpdateIntoDataBase()
        {
            post = ObjectMother.GetPost();

            repository.Update(post);

            Post postAfterUpdate = repository.Get(post.Id);
            postAfterUpdate.Message.Should().Be(post.Message);
        }

        [Test]
        public void PostSqlRepository_ShouldGetIntoDataBase()
        {
            post = repository.Get(1);

            post.Id.Should().Be(1);
        }

        [Test]
        public void PostSqlRepository_ShouldGetAllIntoDataBase()
        {
            List<Post> PostList = (List<Post>)repository.GetAll();

            PostList.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void PostSqlRepository_ShouldDeleteIntoDataBase()
        {
            post = repository.Get(1);

            repository.Delete(post);

            foreach (var item in repository.GetAll())
            {
                item.Id.Should().NotBe(post.Id);
            }
        }

        [Test]
        public void PostSqlRepository_ShouldThrowEmptyMessageExceptionOnAdd()
        {
            post = ObjectMother.GetNoMessagePost();

            Action resultado = () => repository.Save(post);
            resultado.Should().Throw<PostMessageEmptyException>();
        }

        [Test]
        public void PostSqlRepository_ShouldThrowPostMessageOverflowExceptionOnAdd()
        {
            post = ObjectMother.GetMessageOverflowPost();

            Action resultado = () => repository.Save(post);
            resultado.Should().Throw<PostMessageOverflowException>();
        }

        [Test]
        public void PostSqlRepository_ShouldThrowPostDateOverflowExceptionOnAdd()
        {
            post = ObjectMother.GetInvalidPostDatePost();

            Action resultado = () => repository.Save(post);
            resultado.Should().Throw<PostDateOverflowException>();
        }

        [Test]
        public void PostSqlRepository_ShouldThrowEmptyMessageExceptionOnUpdate()
        {
            post = ObjectMother.GetNoMessagePost();

            Action resultado = () => repository.Update(post);
            resultado.Should().Throw<PostMessageEmptyException>();
        }

        [Test]
        public void PostSqlRepository_ShouldThrowPostMessageOverflowExceptionOnUpdate()
        {
            post = ObjectMother.GetMessageOverflowPost();

            Action resultado = () => repository.Update(post);
            resultado.Should().Throw<PostMessageOverflowException>();
        }

        [Test]
        public void PostSqlRepository_ShouldThrowPostDateOverflowExceptionOnUpdate()
        {
            post = ObjectMother.GetInvalidPostDatePost();
            Action resultado = () => repository.Update(post);
            resultado.Should().Throw<PostDateOverflowException>();
        }

        [Test]
        public void PostSqlRepository_ShouldThrowIdentifierUndefinedExceptionOnUpdate()
        {
            post = ObjectMother.GetInvalidIdPost();
            Action resultado = () => repository.Update(post);
            resultado.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void PostSqlRepository_ShouldThrowIdentifierUndefinedExceptionOnDelete()
        {
            post = ObjectMother.GetInvalidIdPost();

            Action resultado = () => repository.Delete(post);
            resultado.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void PostSqlRepository_ShouldThrowIdentifierUndefinedExceptionOnGet()
        {
            post = ObjectMother.GetInvalidIdPost();

            Action resultado = () => repository.Get(post.Id);
            resultado.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
