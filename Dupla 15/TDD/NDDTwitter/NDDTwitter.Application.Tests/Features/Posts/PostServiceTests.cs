using System;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Application.Features.Posts;
using NDDTwitter.Infra;
using System.Collections.Generic;
using NDDTwitter.Domain.Exceptions;

namespace NDDTwitter.Application.Tests.Features.Posts
{
    [TestFixture]
    public class PostServiceTests
    {
        IPostService _service;
        Mock<IPostRepository> _repository;
        Post _post;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IPostRepository>();
            _service = new PostService(_repository.Object);
            _post = new Post()
            {
                Id = 1,
                Message = "asd",
                PostDate = DateTime.Now,
                DisplayPostDate = PostUtil.GetTimeAgoFromDateTime(DateTime.Now)
            };

        }

        [Test]
        [Order(0)]
        public void PostService_ShouldAddIntoRepository()
        {
            _repository.Setup(x => x.Save(_post)).Returns(new Post { Id = 1 });
            Post resultado = _service.Add(_post);
            _repository.Verify(x => x.Save(_post));
            resultado.Id.Should().Be(1);
        }

        [Test]
        public void PostService_ShouldUpdateIntoRepository()
        {
            _repository.Setup(x => x.Update(_post)).Returns(new Post { Id = 1 });
            Post resultado = _service.Update(_post);
            _repository.Verify(x => x.Update(_post));
            resultado.Id.Should().Be(1);
        }

        [Test]
        public void PostService_ShouldGetFromRepository()
        {
            _repository.Setup(x => x.Get(1)).Returns(new Post { Id = 1 });
            Post resultado = _service.Get(1);
            _repository.Verify(x => x.Get(1));
            resultado.Id.Should().Be(1);
        }


        [Test]
        [Order(1)]
        public void PostService_ShouldGetAllFromRepository()
        {
            _repository.Setup(x => x.GetAll()).Returns(new List<Post>());
            IList<Post> resultado = (IList<Post>)_service.GetAll();
            _repository.Verify(x => x.GetAll());
            resultado.Count.Should().BeGreaterOrEqualTo(0);
        }

        [Test]
        public void PostService_ShouldDeleteFromRepository()
        {
            _repository.Setup(x => x.Delete(_post));
            _service.Delete(_post);
            _repository.Verify(x => x.Delete(_post));
        }

        [Test]
        public void PostService_ShouldThrowEmptyMessageExceptionOnAdd()
        {
            Post postBugado = new Post()
            {
                Id = 0,
                Message = " ",
            };

            Action resultado = () => _service.Add(postBugado);
            resultado.Should().Throw<PostMessageEmptyException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_ShouldThrowPostMessageOverflowExceptionOnAdd()
        {
            Post postBugado = new Post()
            {
                Id = 0,
                Message = "asdasdasdasasdasdsdasaddddddddddddddddddddddddddddddddddddddasdasdasdasasdasdsdasaddddddddddddddddddddddddddddddddddddddasdasdasdasasdasdsdasaddddddddddddddddddddddddddddddddddddddasdasdasdasasdasdsdasaddddddddddddddddddddddddddddddddddddddasdasdasdasasdasdsdasaddddddddddddddddddddddddddddddddddddddasdasdasdasasdasdsdasadddddddddddddddddddddddddddddddddddddd",
            };

            Action resultado = () => _service.Add(postBugado);
            resultado.Should().Throw<PostMessageOverflowException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_ShouldThrowPostDateOverflowExceptionOnAdd()
        {
            Post postBugado = new Post()
            {
                Id = 0,
                Message = "asd",
                PostDate = DateTime.Now.AddYears(+1),
            };

            Action resultado = () => _service.Add(postBugado);
            resultado.Should().Throw<PostDateOverflowException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_ShouldThrowEmptyMessageExceptionOnUpdate()
        {
            Post postBugado = new Post()
            {
                Id = 1,
                Message = " ",
            };

            Action resultado = () => _service.Update(postBugado);
            resultado.Should().Throw<PostMessageEmptyException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_ShouldThrowPostMessageOverflowExceptionOnUpdate()
        {
            Post postBugado = new Post()
            {
                Id = 1,
                Message = "asdasdasdasasdasdsdasaddddddddddddddddddddddddddddddddddddddasdasdasdasasdasdsdasaddddddddddddddddddddddddddddddddddddddasdasdasdasasdasdsdasaddddddddddddddddddddddddddddddddddddddasdasdasdasasdasdsdasaddddddddddddddddddddddddddddddddddddddasdasdasdasasdasdsdasaddddddddddddddddddddddddddddddddddddddasdasdasdasasdasdsdasadddddddddddddddddddddddddddddddddddddd",
            };

            Action resultado = () => _service.Update(postBugado);
            resultado.Should().Throw<PostMessageOverflowException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_ShouldThrowPostDateOverflowExceptionOnUpdate()
        {
            Post postBugado = new Post()
            {
                Id = 1,
                Message = "asd",
                PostDate = DateTime.Now.AddYears(+1),
            };

            Action resultado = () => _service.Update(postBugado);
            resultado.Should().Throw<PostDateOverflowException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_ShouldThrowIdentifierUndefinedExceptionOnUpdate()
        {
            Post postBugado = new Post()
            {
                Id = 0,
                Message = "asd",
                PostDate = DateTime.Now.AddYears(+1),
            };

            Action resultado = () => _service.Update(postBugado);
            resultado.Should().Throw<IdentifierUndefinedException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_ShouldThrowIdentifierUndefinedExceptionOnGet()
        {
            Action resultado = () => _service.Get(0);
            resultado.Should().Throw<IdentifierUndefinedException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_ShouldThrowIdentifierUndefinedExceptionOnDelete()
        {
            Post postBugado = new Post()
            {
                Id = 0,
                Message = "asd",
                PostDate = DateTime.Now.AddYears(+1),
            };

            Action resultado = () => _service.Delete(postBugado);
            resultado.Should().Throw<IdentifierUndefinedException>();
            _repository.VerifyNoOtherCalls();
        }
    }
}
