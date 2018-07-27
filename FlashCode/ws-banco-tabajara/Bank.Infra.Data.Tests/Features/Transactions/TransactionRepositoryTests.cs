using Bank.Common.Tests.Features.ObjectMothers;
using Bank.Domain.Exceptions;
using Bank.Domain.Features.Transactions;
using Bank.Infra.Data.Features.Transactions;
using Bank.Infra.Data.Tests.Context;
using Bank.Infra.Data.Tests.Initializer;
using Effort;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Bank.Infra.Data.Tests.Features.Transactions
{
    [TestFixture]
    public class TransactionRepositoryTests : EffortTestBase
    {
        private FakeDbContext _ctx;
        private TransactionRepository _repository;
        private Transaction _transaction;
        private Transaction _transactionSeed;

        [SetUp]
        public void Setup()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _ctx = new FakeDbContext(connection);
            _repository = new TransactionRepository(_ctx);
            _transaction = ObjectMother.GetTransactionCredit();
            //Seed
            _transactionSeed = ObjectMother.GetTransactionDebt();
            _ctx.Transactions.Add(_transactionSeed);
            _ctx.SaveChanges();
        }

        [Test]
        public void Transactions_Repository_Add_ShouldBeOk()
        {
            //Action
            var orderRegistered = _repository.Add(_transaction);
            //Verify
            orderRegistered.Should().NotBeNull();
            orderRegistered.Id.Should().NotBe(0);
            var expectedCustomer = _ctx.Transactions.Find(orderRegistered.Id);
            expectedCustomer.Should().NotBeNull();
            expectedCustomer.Should().Be(orderRegistered);
        }

        [Test]
        public void Transactions_Repository_GetAll_ShouldBeOk()
        {
            //Action
            var orders = _repository.GetAll().ToList();

            //Assert
            orders.Should().NotBeNull();
            orders.Should().HaveCount(_ctx.Transactions.Count());
            orders.First().Should().Be(_transactionSeed);
        }

        [Test]
        public void Transactions_Repository_GetById_ShouldBeOk()
        {
            //Action
            var orderResult = _repository.GetById(_transactionSeed.Id);

            //Assert
            orderResult.Should().NotBeNull();
            orderResult.Should().Be(_transactionSeed);
        }

        [Test]
        public void Transactions_Repository_GetById_ShouldThrowNotFoundException()
        {
            //Action
            var notFoundId = 10;
            var orderResult = _repository.GetById(notFoundId);

            //Assert
            orderResult.Should().BeNull();
        }

        [Test]
        public void Transactions_Repository_Delete_ShouldBeOk()
        {
            // Action
            var isRemoved = _repository.Remove(_transactionSeed);
            // Assert
            isRemoved.Should().BeTrue();
            _ctx.Transactions.Where(p => p.Id == _transactionSeed.Id).FirstOrDefault().Should().BeNull();
        }

        [Test]
        public void Transactions_Repository_Delete_ShouldHandleUnknownTransactionId()
        {
            // Arrange
            _transactionSeed.Id = 10;
            // Action
            Action removeAction = () => _repository.Remove(_transactionSeed);
            // Verify
            removeAction.Should().Throw<NotFoundException>();
        }

        [Test]
        public void Transactions_Repository_Update_ShouldBeOk()
        {
            // Arrange
            var wasUpdated = false;
            var newValue = 100;
            _transactionSeed.Value = newValue;
            //Action
            var actionUpdate = new Action(() => { wasUpdated = _repository.Update(_transactionSeed); });
            // Verify
            actionUpdate.Should().NotThrow<Exception>();
            wasUpdated.Should().BeTrue();
        }
    }
}
