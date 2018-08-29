using Bank.Domain.Exceptions;
using Bank.Domain.Features.Users;
using Bank.Infra.Data.Features.Users;
using Bank.Infra.Data.Tests.Context;
using Effort;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Bank.Infra.Data.Tests.Features.Users
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private UserRepository userRepository;
        private User user;
        private FakeDbContext _context;

        [SetUp]
        public void Initialize()
        {
            System.Data.Common.DbConnection connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _context = new FakeDbContext(connection);
            userRepository = new UserRepository(_context);

            User userSeed = new User() { Password = "test", Username = "test" };
            _context.Users.Add(userSeed);
            _context.SaveChanges();
        }

        [Test]
        public void User_InfraData_GetUser_Should_Be_Ok()
        {
            string username = "test";
            string password = "test";

            user = userRepository.GetUser(username, password);

            user.Should().NotBeNull();
            user.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void User_InfraData_GetUser_Should_Throw_InvalidCredentialsException()
        {
            string username = "test";
            string password = "test2";

            Action action = () => userRepository.GetUser(username, password);

            action.Should().Throw<InvalidCredentialsException>();
        }
    }
}
