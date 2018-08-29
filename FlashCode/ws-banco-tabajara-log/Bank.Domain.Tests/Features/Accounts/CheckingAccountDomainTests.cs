using Bank.Common.Tests.Features.ObjectMothers;
using Bank.Domain.Features.Accounts;
using Bank.Domain.Features.Accounts.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Bank.Domain.Tests.Features.Accounts
{
    [TestFixture]
    public class CheckingAccountDomainTests
    {
        CheckingAccount _account;

        [SetUp]
        public void SetUp()
        {
            _account = ObjectMother.GetCheckingAccountValid();
        }

        [Test]
        public void Domain_Account_Withdraw_Should_Be_Ok()
        {
            //Arrange
            decimal value = 100;
            var balance = 150;
            _account.Balance = balance;
            var quantity = 2;

            //Action
            _account.Withdraw(value);

            //Verify
            _account.Balance.Should().Be(balance - value);
            _account.Transactions.Count.Should().Be(quantity);
        }

        [Test]
        public void Domain_Account_Withdraw_Should_Throw_AccountInactiveException()
        {
            //Arrange
            var value = 10;
            _account.IsActive = false;

            //Action
            Action action = () => _account.Withdraw(value);

            //Verify
            action.Should().Throw<AccountInactiveException>();
        }

        [Test]
        public void Domain_Account_Withdraw_Should_Be_BalanceShort_Exception()
        {
            //Arrange
            decimal value = 100;
            var balance = 10;
            _account.Balance = balance;

            //Action
            Action action = () => _account.Withdraw(value);

            //Verify
            action.Should().Throw<ShortBalanceException>();
        }

        [Test]
        public void Domain_Account_Deposit_Should_Be_Ok()
        {
            //Arrange
            decimal value = 100;
            var balance = 150;
            _account.Balance = balance;
            var quantity = 2;

            //Action
            _account.Deposit(value);

            //Verify
            _account.Balance.Should().Be(balance + value);
            _account.Transactions.Count.Should().Be(quantity);
        }

        [Test]
        public void Domain_Account_Deposit_Should_Throw_AccountInactiveException()
        {
            //Arrange
            var value = 10;
            _account.IsActive = false;

            //Action
            Action action = () => _account.Deposit(value);

            //Verify
            action.Should().Throw<AccountInactiveException>();
        }

        [Test]
        public void Domain_Account_Trasnfer_Should_Be_Ok()
        {
            //Arrange
            decimal value = 100;
            var balance = 150;
            _account.Balance = balance;
            var quantity = 2;

            var accountDest = ObjectMother.GetCheckingAccountValid();
            accountDest.Balance = balance;

            //Action
            _account.Transfer(value, accountDest);

            //Verify
            _account.Balance.Should().Be(balance - value);
            accountDest.Balance.Should().Be(balance + value);
            _account.Transactions.Count.Should().Be(quantity);
            accountDest.Transactions.Count.Should().Be(quantity);
        }

        [Test]
        public void Domain_Account_Transfer_Should_Throw_AccountInactiveException()
        {
            //Arrange
            var accountDest = ObjectMother.GetCheckingAccountValid();
            var value = 10;
            _account.IsActive = false;

            //Action
            Action action = () => _account.Transfer(value, accountDest);

            //Verify
            action.Should().Throw<AccountInactiveException>();
        }

        [Test]
        public void Domain_Account_Transfer_Should_Throw_ShortBalanceException()
        {
            //Arrange
            var accountDest = ObjectMother.GetCheckingAccountValid();
            decimal value = 100;
            var balance = 50;
            var limit = 10;
            _account.Balance = balance;
            _account.Limit = limit;

            //Action
            Action action = () => _account.Transfer(value, accountDest);

            //Verify
            action.Should().Throw<ShortBalanceException>();
        }
    }
}
