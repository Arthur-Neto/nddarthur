using Bank.Common.Tests.Features.ObjectMothers;
using Bank.Domain.Exceptions;
using Bank.Domain.Features.Accounts;
using Bank.Infra.Data.Features.Accounts;
using Bank.Infra.Data.Tests.Context;
using Bank.Infra.Data.Tests.Initializer;
using Effort;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Bank.Infra.Data.Tests.Features.Accounts
{
    [TestFixture]
    public class CheckingAccountRepositoryTests : EffortTestBase
    {
        private FakeDbContext _ctx;
        private CheckingAccountRepository _repository;
        private CheckingAccount _account;
        private CheckingAccount _accountSeed;

        [SetUp]
        public void Setup()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _ctx = new FakeDbContext(connection);
            _repository = new CheckingAccountRepository(_ctx);
            _account = ObjectMother.GetCheckingAccountValid();
            //Seed
            _accountSeed = ObjectMother.GetCheckingAccountValid();
            _accountSeed.Transactions.Add(ObjectMother.GetTransactionCredit());
            _ctx.CheckingAccounts.Add(_accountSeed);
            _ctx.SaveChanges();
        }

        [Test]
        public void CheckingAccounts_Repository_Add_ShouldBeOk()
        {
            //Action
            var orderRegistered = _repository.Add(_account);
            //Verify
            orderRegistered.Should().NotBeNull();
            orderRegistered.Id.Should().NotBe(0);
            var expectedCustomer = _ctx.CheckingAccounts.Find(orderRegistered.Id);
            expectedCustomer.Should().NotBeNull();
            expectedCustomer.Should().Be(orderRegistered);
        }

        [Test]
        public void CheckingAccounts_Repository_GetAll_ShouldBeOk()
        {
            //Action
            var orders = _repository.GetAll().ToList();

            //Assert
            orders.Should().NotBeNull();
            orders.Should().HaveCount(_ctx.CheckingAccounts.Count());
            orders.First().Should().Be(_accountSeed);
        }

        [Test]
        public void CheckingAccounts_Repository_GetByQuantity_ShouldBeOk()
        {
            //Action
            var quantity = 1;
            var orders = _repository.GetAll(quantity).ToList();

            //Assert
            orders.Should().NotBeNull();
            orders.Should().HaveCount(quantity);
            orders.First().Should().Be(_accountSeed);
        }

        [Test]
        public void CheckingAccounts_Repository_GetById_ShouldBeOk()
        {
            //Action
            var orderResult = _repository.GetById(_accountSeed.Id);

            //Assert
            orderResult.Should().NotBeNull();
            orderResult.Should().Be(_accountSeed);
        }

        [Test]
        public void CheckingAccounts_Repository_GetById_ShouldThrowNotFoundException()
        {
            //Action
            var notFoundId = 10;
            var orderResult = _repository.GetById(notFoundId);

            //Assert
            orderResult.Should().BeNull();
        }

        [Test]
        public void CheckingAccounts_Repository_Delete_ShouldBeOk()
        {
            // Action
            var isRemoved = _repository.Remove(_accountSeed);
            // Assert
            isRemoved.Should().BeTrue();
            _ctx.CheckingAccounts.Where(p => p.Id == _accountSeed.Id).FirstOrDefault().Should().BeNull();
        }

        [Test]
        public void CheckingAccounts_Repository_Delete_ShouldHandleUnknownCheckingAccountId()
        {
            // Arrange
            _accountSeed.Id = 10;
            // Action
            Action removeAction = () => _repository.Remove(_accountSeed);
            // Verify
            removeAction.Should().Throw<NotFoundException>();
        }

        [Test]
        public void CheckingAccounts_Repository_Update_ShouldBeOk()
        {
            // Arrange
            var wasUpdated = false;
            var newLimit = 50;
            _accountSeed.Limit = newLimit;
            //Action
            var actionUpdate = new Action(() => { wasUpdated = _repository.Update(_accountSeed); });
            // Verify
            actionUpdate.Should().NotThrow<Exception>();
            wasUpdated.Should().BeTrue();
        }
    }
}
