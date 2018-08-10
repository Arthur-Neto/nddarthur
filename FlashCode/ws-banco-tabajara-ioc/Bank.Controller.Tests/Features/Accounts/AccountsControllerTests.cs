using Bank.Application.Features.Accounts;
using Bank.Common.Tests.Features.ObjectMothers;
using Bank.Controller.Tests.Initializer;
using Bank.Domain.Exceptions;
using Bank.Domain.Features.Accounts;
using Bank.Domain.Features.Clients;
using Bank.Domain.Features.Transactions;
using Bank.WebAPI.Controllers.Accounts;
using Bank.WebAPI.Exceptions;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Bank.Controller.Tests.Features.Accounts
{
    [TestFixture]
    public class CheckingAccountsControllerTests : TestControllerBase
    {
        private CheckingAccountsController _checkingAccountsController;
        private Mock<ICheckingAccountService> _checkingAccountServiceMock;
        private Mock<CheckingAccount> _checkingAccount;
        private Mock<AccountTransactionModel> _accountTransactionModel;
        private Mock<ICheckingAccountRepository> _checkingAccountRepositoryMock;
        private Mock<IClientRepository> _clientRepositoryMock;


        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _checkingAccountServiceMock = new Mock<ICheckingAccountService>();
            _checkingAccountRepositoryMock = new Mock<ICheckingAccountRepository>();
            _clientRepositoryMock = new Mock<IClientRepository>();
            _checkingAccountsController = new CheckingAccountsController(_checkingAccountRepositoryMock.Object, _clientRepositoryMock.Object)
            {
                Request = request,
                _accountsService = _checkingAccountServiceMock.Object,
            };
            _checkingAccount = new Mock<CheckingAccount>();
            _accountTransactionModel = new Mock<AccountTransactionModel>();
        }

        #region GET

        [Test]
        public void CheckingAccounts_Controller_Get_ShouldBeOk()
        {
            // Arrange
            var checkingAccount = ObjectMother.GetCheckingAccountValid();
            var response = new List<CheckingAccount>() { checkingAccount }.AsQueryable();
            _checkingAccountServiceMock.Setup(s => s.GetAll(null)).Returns(response);

            // Action
            var callback = _checkingAccountsController.Get();

            //Assert
            _checkingAccountServiceMock.Verify(s => s.GetAll(null), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<CheckingAccount>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(checkingAccount.Id);
        }

        [Test]
        public void CheckingAccounts_Controller_GetByQuantity_ShouldBeOk()
        {
            // Arrange
            var quantity = 1;
            _checkingAccountsController.Request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:6001/api/checkingaccounts?quantity=" + quantity);
            var checkingAccount = ObjectMother.GetCheckingAccountValid();
            var response = new List<CheckingAccount>() { checkingAccount }.AsQueryable();
            _checkingAccountServiceMock.Setup(s => s.GetAll(quantity)).Returns(response);

            // Action
            var callback = _checkingAccountsController.Get();

            //Assert
            _checkingAccountServiceMock.Verify(s => s.GetAll(quantity), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<CheckingAccount>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(checkingAccount.Id);
        }

        [Test]
        public void CheckingAccounts_Controller_GetById_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _checkingAccount.Setup(p => p.Id).Returns(id);
            _checkingAccountServiceMock.Setup(c => c.GetById(id)).Returns(_checkingAccount.Object);

            // Action
            IHttpActionResult callback = _checkingAccountsController.GetById(id);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<CheckingAccount>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Id.Should().Be(id);
            _checkingAccountServiceMock.Verify(s => s.GetById(id), Times.Once);
            _checkingAccount.Verify(p => p.Id, Times.Once);
        }

        [Test]
        public void CheckingAccounts_Controller_GetExtracts_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _checkingAccount.Setup(p => p.Id).Returns(id);
            _checkingAccountServiceMock.Setup(c => c.GetExtract(id)).Returns(_checkingAccount.Object);

            // Action
            IHttpActionResult callback = _checkingAccountsController.GetExtracts(id);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<object>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _checkingAccountServiceMock.Verify(s => s.GetExtract(id), Times.Once);
        }

        #endregion

        #region POST

        [Test]
        public void CheckingAccounts_Controller_Post_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _checkingAccountServiceMock.Setup(c => c.Add(_checkingAccount.Object)).Returns(id);

            // Action
            IHttpActionResult callback = _checkingAccountsController.Post(_checkingAccount.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(id);
            _checkingAccountServiceMock.Verify(s => s.Add(_checkingAccount.Object), Times.Once);
        }

        #endregion

        #region PUT

        [Test]
        public void CheckingAccounts_Controller_Put_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _checkingAccountServiceMock.Setup(c => c.Update(_checkingAccount.Object)).Returns(isUpdated);

            // Action
            IHttpActionResult callback = _checkingAccountsController.Update(_checkingAccount.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _checkingAccountServiceMock.Verify(s => s.Update(_checkingAccount.Object), Times.Once);
        }

        [Test]
        public void CheckingAccounts_Controller_Put_Withdraw_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _checkingAccountServiceMock.Setup(c => c.Withdraw(_accountTransactionModel.Object)).Returns(isUpdated);

            // Action
            IHttpActionResult callback = _checkingAccountsController.Withdraw(_accountTransactionModel.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _checkingAccountServiceMock.Verify(s => s.Withdraw(_accountTransactionModel.Object), Times.Once);
        }

        [Test]
        public void CheckingAccounts_Controller_Put_Deposit_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _checkingAccountServiceMock.Setup(c => c.Deposit(_accountTransactionModel.Object)).Returns(isUpdated);

            // Action
            IHttpActionResult callback = _checkingAccountsController.Deposit(_accountTransactionModel.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _checkingAccountServiceMock.Verify(s => s.Deposit(_accountTransactionModel.Object), Times.Once);
        }

        [Test]
        public void CheckingAccounts_Controller_Put_Transfer_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _checkingAccountServiceMock.Setup(c => c.Transfer(_accountTransactionModel.Object)).Returns(isUpdated);

            // Action
            IHttpActionResult callback = _checkingAccountsController.Transfer(_accountTransactionModel.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _checkingAccountServiceMock.Verify(s => s.Transfer(_accountTransactionModel.Object), Times.Once);
        }

        [Test]
        public void CheckingAccounts_Controller_Put_ShouldHandleNotFoundexception()
        {
            // Arrange
            _checkingAccountServiceMock.Setup(c => c.Update(_checkingAccount.Object)).Throws<NotFoundException>();

            // Action
            IHttpActionResult callback = _checkingAccountsController.Update(_checkingAccount.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.Content.ErrorCode.Should().Be((int)ErrorCodes.NotFound);
            _checkingAccountServiceMock.Verify(s => s.Update(_checkingAccount.Object), Times.Once);
        }

        #endregion

        #region PATCH

        [Test]
        public void CheckingAccounts_Controller_Patch_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _checkingAccountServiceMock.Setup(c => c.UpdateStatus(_checkingAccount.Object.Id)).Returns(isUpdated);

            // Action
            IHttpActionResult callback = _checkingAccountsController.UpdateStatus(_checkingAccount.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _checkingAccountServiceMock.Verify(s => s.UpdateStatus(_checkingAccount.Object.Id), Times.Once);
        }

        #endregion

        #region DELETE

        [Test]
        public void CheckingAccounts_Controller_Delete_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _checkingAccountServiceMock.Setup(c => c.Remove(_checkingAccount.Object)).Returns(isUpdated);

            // Action
            IHttpActionResult callback = _checkingAccountsController.Delete(_checkingAccount.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _checkingAccountServiceMock.Verify(s => s.Remove(_checkingAccount.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        #endregion
    }
}
