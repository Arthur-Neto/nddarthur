using FluentAssertions;
using NDDTwitter.Application.Features.Posts;
using NDDTwitter.Common.Tests.Base;
using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Infra.Data.Features.Posts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NDDTwitter.Integration.Tests.Features.Posts
{
    [TestFixture]
    public class PostIntegrationBDTests
    {
        private IPostService _service;
        private IPostRepository _repository;
        private Post _post;

        [SetUp]
        public void SetUp()
        {
            _repository = new PostRepository();
            _service = new PostService(_repository);
            _post = ObjectMother.GetPost();
            BaseSqlTest.SeedDatabase();
        }

        [Test]
        [Order(0)]
        public void PostServiceDB_Add_ShouldBeOk()
        {
            Post resultado = _service.Add(_post);
            resultado.Id.Should().Be(_post.Id);
        }

        [Test]
        [Order(1)]
        public void PostServiceDB_Get_ShouldBeOk()
        {
            Post resultado = _service.Get(_post.Id);
            resultado.Id.Should().Be(_post.Id);
        }

        [Test]
        [Order(2)]
        public void PostServiceDB_Update_ShouldBeOk()
        {
            Post resultado = _service.Update(_post);
            resultado.Id.Should().Be(_post.Id);
        }

        [Test]
        [Order(3)]
        public void PostServiceDB_GetAll_ShouldBeOk()
        {
            _service.Add(_post);
            IEnumerable<Post> list = _service.GetAll();
            list.Count().Should().BeGreaterThan(0);
            list.Last().Id.Should().Be(_post.Id);
        }

        [Test]
        [Order(4)]
        public void PostServiceDB_Delete_ShouldBeOk()
        {
            _service.Delete(_post);
            Post resultado = _service.Get(_post.Id);
            resultado.Should().BeNull();
        }

        [Test]
        public void PostServiceDB_Add_ShouldThrowPostMessageEmptyException()
        {
            _post = ObjectMother.GetNoMessagePost();
            Action action = () => _service.Add(_post);
            action.Should().Throw<PostMessageEmptyException>();
            IEnumerable<Post> list = _service.GetAll();
            list.Should().NotContain(_post);
        }

        [Test]
        public void PostServiceDB_Add_ShouldThrowPostMessageOverflowException()
        {
            _post = ObjectMother.GetMessageOverflowPost();
            Action action = () => _service.Add(_post);
            action.Should().Throw<PostMessageOverflowException>();
            IEnumerable<Post> list = _service.GetAll();
            list.Should().NotContain(_post);
        }

        [Test]
        public void PostServiceDB_Add_ShouldThrowInvalidPostDateException()
        {
            _post = ObjectMother.GetInvalidPostDatePost();
            Action action = () => _service.Add(_post);
            action.Should().Throw<PostDateOverflowException>();
            IEnumerable<Post> list = _service.GetAll();
            list.Should().NotContain(_post);
        }

        [Test]
        public void PostServiceDB_Update_ShouldThrowIdentifierUndefinedException()
        {
            _post = ObjectMother.GetInvalidIdPost();
            Action action = () => _service.Update(_post);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void PostServiceDB_Delete_ShouldThrowIdentifierUndefinedException()
        {
            _post = ObjectMother.GetInvalidIdPost();
            Action action = () => _service.Delete(_post);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void PostServiceDB_Get_ShouldThrowIdentifierUndefinedException()
        {
            _post = ObjectMother.GetInvalidIdPost();
            Action action = () => _service.Update(_post);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void PostServiceDB_Update_ShouldReturnNull()
        {
            _post = new Post() { Id = 999 , Message = "asd", PostDate = DateTime.Now };
            Post resultado = _service.Update(_post);
            resultado.Should().BeNull();
        }

        [Test]
        public void PostServiceDB_Get_ShouldReturnNull()
        {
            var invalidId = 9999999;
            Post resultado = _service.Get(invalidId);
            resultado.Should().BeNull();
        }

        //[Test]
        //public void PostServiceDB_GetAll_ShouldThrowSqlException()
        //{
        //    Action acao = () => _service.GetAll();
        //    acao.Should().Throw<SqlException>();
        //}
    }
}
