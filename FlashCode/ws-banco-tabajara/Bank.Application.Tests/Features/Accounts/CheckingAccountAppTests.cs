using Bank.Application.Features.Accounts;
using Bank.Common.Tests.Features.ObjectMothers;
using Bank.Domain.Exceptions;
using Bank.Domain.Features.Accounts;
using Bank.Domain.Features.Clients;
using Bank.Domain.Features.Transactions;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank.Application.Tests.Features.Accounts
{
    [TestFixture]
    public class CheckingAccountAppTests
    {
        private CheckingAccount _checkingAccount;
        private ICheckingAccountService _service;
        private Mock<ICheckingAccountRepository> _mockRepositoryAccount;
        private Mock<IClientRepository> _mockRepositoryClient;
        private Mock<ITransactionRepository> _mockRepositoryTransaction;

        [SetUp]
        public void SetUp()
        {
            _checkingAccount = ObjectMother.GetCheckingAccountValid();
            _mockRepositoryAccount = new Mock<ICheckingAccountRepository>();
            _mockRepositoryClient = new Mock<IClientRepository>();
            _mockRepositoryTransaction = new Mock<ITransactionRepository>();
            _service = new CheckingAccountService(_mockRepositoryAccount.Object, _mockRepositoryClient.Object, _mockRepositoryTransaction.Object);
        }

        [Test]
        public void CheckingAccounts_Service_Add_Should_Be_OK()
        {
            //Arrange

            _mockRepositoryAccount.Setup(r => r.Add(_checkingAccount))
                .Returns(_checkingAccount);

            _mockRepositoryClient.Setup(r => r.GetById(_checkingAccount.Client.Id))
                .Returns(_checkingAccount.Client);

            _mockRepositoryTransaction.Setup(r => r.Add(_checkingAccount.Transactions.First()))
                .Returns(_checkingAccount.Transactions.First());

            //Action
            var idInsert = _service.Add(_checkingAccount);

            //Verify
            idInsert.Should().Be(_checkingAccount.Id);
            _mockRepositoryAccount.Verify(r => r.Add(_checkingAccount));
            _mockRepositoryClient.Verify(r => r.GetById(_checkingAccount.Client.Id));
            _mockRepositoryTransaction.Verify(r => r.Add(_checkingAccount.Transactions.First()));
        }

        [Test]
        public void CheckingAccounts_Service_Update_Should_Be_OK()
        {
            //Arrange
            var returns = true;

            _mockRepositoryAccount.Setup(r => r.GetById(_checkingAccount.Id))
                .Returns(_checkingAccount);

            _mockRepositoryAccount.Setup(r => r.Update(_checkingAccount))
                .Returns(returns);

            _mockRepositoryTransaction.Setup(r => r.Add(_checkingAccount.Transactions.First()))
                .Returns(_checkingAccount.Transactions.First());

            //Action
            var idInsert = _service.Update(_checkingAccount);

            //Verify
            idInsert.Should().Be(returns);
            _mockRepositoryAccount.Verify(r => r.GetById(_checkingAccount.Id));
            _mockRepositoryAccount.Verify(r => r.Update(_checkingAccount));
            _mockRepositoryTransaction.Verify(r => r.Add(_checkingAccount.Transactions.First()));
        }

        [Test]
        public void CheckingAccounts_Service_Update_NullAccount_Should_ThrowException()
        {
            //Arrange
            var returns = false;

            _mockRepositoryAccount.Setup(r => r.GetById(_checkingAccount.Id));

            _mockRepositoryAccount.Setup(r => r.Update(_checkingAccount))
                .Returns(returns);

            //Action
            Action action = () => _service.Update(_checkingAccount);

            //Verify
            action.Should().Throw<NotFoundException>();
            _mockRepositoryAccount.Verify(r => r.GetById(_checkingAccount.Id));
            _mockRepositoryAccount.VerifyNoOtherCalls();
        }

        [Test]
        public void CheckingAccounts_Service_Withdraw_Should_Be_OK()
        {
            //Arrange
            var returns = true;
            AccountTransactionModel model = new AccountTransactionModel() { AccountOriginId = 1, Value = 50 };

            _mockRepositoryAccount.Setup(r => r.GetById(_checkingAccount.Id))
                .Returns(_checkingAccount);

            _mockRepositoryAccount.Setup(r => r.Update(_checkingAccount))
                .Returns(returns);

            _mockRepositoryTransaction.Setup(r => r.Add(_checkingAccount.Transactions.First()))
                .Returns(_checkingAccount.Transactions.First());
            //Action
            var idInsert = _service.Withdraw(model);

            //Verify
            idInsert.Should().Be(returns);
            _mockRepositoryAccount.Verify(r => r.GetById(_checkingAccount.Id));
            _mockRepositoryAccount.Verify(r => r.Update(_checkingAccount));
            _mockRepositoryTransaction.Verify(r => r.Add(_checkingAccount.Transactions.First()));
        }

        [Test]
        public void CheckingAccounts_Service_Withdraw_InvalidValue_Should_ThrowException()
        {
            //Arrange
            var returns = false;
            AccountTransactionModel model = new AccountTransactionModel() { AccountOriginId = 1, Value = -50 };

            _mockRepositoryAccount.Setup(r => r.GetById(_checkingAccount.Id))
                .Returns(_checkingAccount);

            _mockRepositoryAccount.Setup(r => r.Update(_checkingAccount))
                .Returns(returns);

            //Action
            Action action = () => _service.Withdraw(model);

            //Verify
            action.Should().Throw<InvalidObjectException>();
            _mockRepositoryAccount.Verify(r => r.GetById(_checkingAccount.Id));
        }

        [Test]
        public void CheckingAccounts_Service_Deposit_Should_Be_OK()
        {
            //Arrange
            var returns = true;
            AccountTransactionModel model = new AccountTransactionModel() { AccountOriginId = 1, Value = 50 };

            _mockRepositoryAccount.Setup(r => r.GetById(model.AccountOriginId))
                .Returns(_checkingAccount);

            _mockRepositoryAccount.Setup(r => r.Update(_checkingAccount))
                .Returns(returns);

            _mockRepositoryTransaction.Setup(r => r.Add(_checkingAccount.Transactions.First()))
                .Returns(_checkingAccount.Transactions.First());

            //Action
            var idInsert = _service.Deposit(model);

            //Verify
            idInsert.Should().Be(returns);
            _mockRepositoryAccount.Verify(r => r.GetById(model.AccountOriginId));
            _mockRepositoryAccount.Verify(r => r.Update(_checkingAccount));
            _mockRepositoryTransaction.Verify(r => r.Add(_checkingAccount.Transactions.First()));
        }

        [Test]
        public void CheckingAccounts_Service_Deposit_InvalidValue_Should_ThroException()
        {
            //Arrange
            AccountTransactionModel model = new AccountTransactionModel() { AccountOriginId = 1, Value = -50 };

            _mockRepositoryAccount.Setup(r => r.GetById(_checkingAccount.Id))
                .Returns(_checkingAccount);

            //Action
            Action action = () => _service.Deposit(model);

            //Verify
            action.Should().Throw<InvalidObjectException>();
            _mockRepositoryAccount.Verify(r => r.GetById(_checkingAccount.Id));
        }

        [Test]
        public void CheckingAccounts_Service_Transfer_Should_Be_OK()
        {
            //Arrange
            var returns = true;
            AccountTransactionModel model = new AccountTransactionModel() { AccountOriginId = 1, AccountDestinationId = 2, Value = 50 };
            CheckingAccount accountDestination = new CheckingAccount() { Id = 2, IsActive = true };
            accountDestination.Transactions.Add(new Transaction { Type = TransactionType.CREDIT, Value = 50 });

            _mockRepositoryAccount.Setup(r => r.GetById(model.AccountOriginId))
                .Returns(_checkingAccount);

            _mockRepositoryAccount.Setup(r => r.GetById(model.AccountDestinationId))
                .Returns(accountDestination);

            _mockRepositoryAccount.Setup(r => r.Update(_checkingAccount))
                .Returns(returns);

            _mockRepositoryAccount.Setup(r => r.Update(accountDestination))
                .Returns(returns);

            _mockRepositoryTransaction.Setup(r => r.Add(_checkingAccount.Transactions.First()))
                .Returns(_checkingAccount.Transactions.First());

            _mockRepositoryTransaction.Setup(r => r.Add(accountDestination.Transactions.First()))
                .Returns(_checkingAccount.Transactions.First());

            //Action
            var idInsert = _service.Transfer(model);

            //Verify
            idInsert.Should().Be(returns);
            _mockRepositoryAccount.Verify(r => r.GetById(_checkingAccount.Id));
            _mockRepositoryAccount.Verify(r => r.Update(_checkingAccount));
            _mockRepositoryAccount.Verify(r => r.GetById(accountDestination.Id));
            _mockRepositoryAccount.Verify(r => r.Update(accountDestination));
            _mockRepositoryTransaction.Verify(r => r.Add(_checkingAccount.Transactions.First()));
            _mockRepositoryTransaction.Verify(r => r.Add(accountDestination.Transactions.First()));
        }

        [Test]
        public void CheckingAccounts_Service_Transfer_InvalidValue_Should_ThrowException()
        {
            //Arrange
            AccountTransactionModel model = new AccountTransactionModel() { AccountOriginId = 1, AccountDestinationId = 2, Value = -50 };
            CheckingAccount accountDestination = new CheckingAccount() { Id = 2, IsActive = true };
            accountDestination.Transactions.Add(new Transaction { Type = TransactionType.CREDIT, Value = 50 });

            //Action
            Action action = () => _service.Transfer(model);

            //Verify
            action.Should().Throw<InvalidObjectException>();
        }

        [Test]
        public void CheckingAccounts_Service_Transfer_NullAccount_Should_ThrowException()
        {
            //Arrange
            AccountTransactionModel model = new AccountTransactionModel() { AccountOriginId = 1234, AccountDestinationId = 2222, Value = 50 };
            CheckingAccount accountDestination = new CheckingAccount() { Id = 2, IsActive = true };
            accountDestination.Transactions.Add(new Transaction { Type = TransactionType.CREDIT, Value = 50 });

            //Action
            Action action = () => _service.Deposit(model);

            //Verify
            action.Should().Throw<NotFoundException>();
        }

        [Test]
        public void CheckingAccounts_Service_Delete_Should_Be_OK()
        {
            //Arrange
            var returns = true;
            _mockRepositoryAccount.Setup(r => r.Remove(_checkingAccount))
                .Returns(returns);
            _mockRepositoryAccount.Setup(r => r.GetById(_checkingAccount.Id)).Returns(_checkingAccount);

            //Action
            var idInsert = _service.Remove(_checkingAccount);

            //Verify
            idInsert.Should().Be(returns);
            _mockRepositoryAccount.Verify(r => r.Remove(_checkingAccount));
            _mockRepositoryAccount.Verify(r => r.GetById(_checkingAccount.Id));
        }

        [Test]
        public void CheckingAccounts_Service_GetAll_Should_Be_OK()
        {
            //Arrange
            var list = new List<CheckingAccount>();
            IQueryable<CheckingAccount> query = list.AsQueryable();
            _mockRepositoryAccount.Setup(r => r.GetAll(null))
                .Returns(query);

            //Action
            var listReturn = _service.GetAll();

            //Verify
            listReturn.Count().Should().Be(query.Count());
            _mockRepositoryAccount.Verify(r => r.GetAll(null));
        }

        [Test]
        public void CheckingAccounts_Service_GetExtract_Should_Be_OK()
        {
            //Arrange
            long id = 1;
            _mockRepositoryAccount.Setup(r => r.GetById(id))
                .Returns(_checkingAccount);

            //Action
            object returns = _service.GetExtract(id);
            //Verify
            _mockRepositoryAccount.Verify(r => r.GetById(id));
            returns.Should().NotBeNull();

            var type = returns.GetType();
            foreach (var item in type.Properties())
                item.GetValue(returns).Should().NotBeNull();

        }

        [Test]
        public void CheckingAccounts_Service_GetByID_Should_Be_OK()
        {
            //Arrange
            var id = 1;
            _mockRepositoryAccount.Setup(r => r.GetById(id))
                .Returns(new CheckingAccount() { Id = id });

            //Action
            var find = _service.GetById(id);

            //Verify
            find.Id.Should().Be(id);
            _mockRepositoryAccount.Verify(r => r.GetById(id));
        }

        [Test]
        public void CheckingAccounts_Service_UpdateStatus_Should_Be_OK()
        {
            //Arrange
            var returns = true;
            var id = 1;
            _mockRepositoryAccount.Setup(r => r.GetById(_checkingAccount.Id))
                .Returns(_checkingAccount);

            _mockRepositoryAccount.Setup(r => r.Update(_checkingAccount))
                .Returns(returns);

            //Action
            var updated = _service.UpdateStatus(id);

            //Verify
            updated.Should().Be(returns);
            _mockRepositoryAccount.Verify(r => r.Update(_checkingAccount));
            _mockRepositoryAccount.Verify(r => r.GetById(id));
        }

        [Test]
        public void CheckingAccounts_Service_UpdateStatus_Should_ThrowException()
        {
            //Arrange
            var id = 1234;
            _mockRepositoryAccount.Setup(r => r.GetById(_checkingAccount.Id));

            //Action
            Action action = () => _service.UpdateStatus(id);

            //Verify
            action.Should().Throw<NotFoundException>();
        }

        [Test]
        public void CheckingAccounts_Service_UpdateStatus_Account_Inactive_Should_Return_False()
        {
            //Arrange
            var returns = false;
            var id = 1;
            _checkingAccount.IsActive = false;
            _mockRepositoryAccount.Setup(r => r.GetById(_checkingAccount.Id))
                .Returns(_checkingAccount);

            _mockRepositoryAccount.Setup(r => r.Update(_checkingAccount))
                .Returns(returns);

            //Action
            var updated = _service.UpdateStatus(id);

            //Verify
            updated.Should().Be(returns);
            _mockRepositoryAccount.Verify(r => r.Update(_checkingAccount));
            _mockRepositoryAccount.Verify(r => r.GetById(id));
        }
    }
}
