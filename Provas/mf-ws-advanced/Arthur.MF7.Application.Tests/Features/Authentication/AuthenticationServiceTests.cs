using Arthur.MF7.Application.Features.Authentication;
using Arthur.MF7.Domain.Features.Users;
using Arthur.MF7.Infra.Crypto;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Arthur.MF7.Application.Tests.Features.Authentication
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private AuthenticationService _service;
        private Mock<IUserRepository> _mockRepository;
        private User _user;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IUserRepository>();
            _service = new AuthenticationService(_mockRepository.Object);
            _user = new User() { Id = 1, Username = "test", Password = "test" };
        }

        [Test]
        public void AuthenticationService_Application_Login_Should_BeOk()
        {
            string username = _user.Username;
            string password = _user.Password.GenerateHash();
            _mockRepository.Setup(a => a.GetUser(username, password)).Returns(_user);

            User userLogged = _service.Login(_user.Username, _user.Password);

            _mockRepository.Verify(a => a.GetUser(username, password), Times.Once);
            userLogged.Should().NotBeNull();
            userLogged.Should().Be(_user);
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}
