using Bank.Application.Features.Accounts;
using Bank.Application.Features.Accounts.Commands;
using Bank.Application.Features.Accounts.Queries;
using Bank.Application.Features.Accounts.ViewModels;
using Bank.Application.Mapping;
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
        private CheckingAccountQuery _accountQuery;
        private CheckingAccountsController _checkingAccountsController;
        private Mock<ICheckingAccountService> _checkingAccountServiceMock;
        private Mock<CheckingAccount> _checkingAccount;
        private Mock<CheckingAccountRegisterCommand> _checkingAccountRegister;
        private Mock<CheckingAccountRemoveCommand> _checkingAccountRemove;
        private Mock<CheckingAccountUpdateCommand> _checkingAccountUpdate;
        private Mock<CheckingAccountTransactionCommand> _accountTransactionCommand;
        private Mock<ICheckingAccountRepository> _checkingAccountRepositoryMock;
        private Mock<IClientRepository> _clientRepositoryMock;


        [SetUp]
        public void Initialize()
        {
            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
            _accountQuery = new CheckingAccountQuery();
            _checkingAccountRegister = new Mock<CheckingAccountRegisterCommand>();
            _checkingAccountRemove = new Mock<CheckingAccountRemoveCommand>();
            _checkingAccountUpdate = new Mock<CheckingAccountUpdateCommand>();
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _checkingAccountServiceMock = new Mock<ICheckingAccountService>();
            _checkingAccountRepositoryMock = new Mock<ICheckingAccountRepository>();
            _clientRepositoryMock = new Mock<IClientRepository>();
            _checkingAccountsController = new CheckingAccountsController(_checkingAccountServiceMock.Object)
            {
                Request = request,
                _accountsService = _checkingAccountServiceMock.Object,
            };
            _checkingAccount = new Mock<CheckingAccount>();
            _accountTransactionCommand = new Mock<CheckingAccountTransactionCommand>();
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
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<CheckingAccountViewModel>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(checkingAccount.Id);
        }

        [Test]
        public void CheckingAccounts_Controller_GetByQuantity_ShouldBeOk()
        {
            // Arrange
            var quantity = 1;
            _accountQuery.Quantity = quantity;
            _checkingAccountsController.Request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:6001/api/checkingaccounts?quantity=" + quantity);
            var checkingAccount = ObjectMother.GetCheckingAccountValid();
            var response = new List<CheckingAccount>() { checkingAccount }.AsQueryable();
            _checkingAccountServiceMock.Setup(s => s.GetAll(It.IsAny<CheckingAccountQuery>())).Returns(response);

            // Action
            var callback = _checkingAccountsController.Get();

            //Assert
            _checkingAccountServiceMock.Verify(s => s.GetAll(It.IsAny<CheckingAccountQuery>()), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<CheckingAccountViewModel>>>().Subject;
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
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<CheckingAccountViewModel>>().Subject;
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
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<CheckingAccount>>().Subject;
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
            _checkingAccountServiceMock.Setup(c => c.Add(_checkingAccountRegister.Object)).Returns(id);
            _checkingAccountRegister.Setup(c => c.Validate()).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            IHttpActionResult callback = _checkingAccountsController.Post(_checkingAccountRegister.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(id);
            _checkingAccountServiceMock.Verify(s => s.Add(_checkingAccountRegister.Object), Times.Once);
        }

        #endregion

        #region PUT

        [Test]
        public void CheckingAccounts_Controller_Put_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _checkingAccountServiceMock.Setup(c => c.Update(_checkingAccountUpdate.Object)).Returns(isUpdated);
            _checkingAccountUpdate.Setup(c => c.Validate()).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            IHttpActionResult callback = _checkingAccountsController.Update(_checkingAccountUpdate.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _checkingAccountServiceMock.Verify(s => s.Update(_checkingAccountUpdate.Object), Times.Once);
        }

        [Test]
        public void CheckingAccounts_Controller_Put_Withdraw_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _checkingAccountServiceMock.Setup(c => c.Withdraw(_accountTransactionCommand.Object)).Returns(isUpdated);
            _accountTransactionCommand.Setup(c => c.Validate(TransactionType.DEBT)).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            IHttpActionResult callback = _checkingAccountsController.Withdraw(_accountTransactionCommand.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _checkingAccountServiceMock.Verify(s => s.Withdraw(_accountTransactionCommand.Object), Times.Once);
        }

        [Test]
        public void CheckingAccounts_Controller_Put_Deposit_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _checkingAccountServiceMock.Setup(c => c.Deposit(_accountTransactionCommand.Object)).Returns(isUpdated);
            _accountTransactionCommand.Setup(c => c.Validate(TransactionType.CREDIT)).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            IHttpActionResult callback = _checkingAccountsController.Deposit(_accountTransactionCommand.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _checkingAccountServiceMock.Verify(s => s.Deposit(_accountTransactionCommand.Object), Times.Once);
        }

        [Test]
        public void CheckingAccounts_Controller_Put_Transfer_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _checkingAccountServiceMock.Setup(c => c.Transfer(_accountTransactionCommand.Object)).Returns(isUpdated);
            _accountTransactionCommand.Setup(c => c.Validate(TransactionType.TRANSFER)).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            IHttpActionResult callback = _checkingAccountsController.Transfer(_accountTransactionCommand.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _checkingAccountServiceMock.Verify(s => s.Transfer(_accountTransactionCommand.Object), Times.Once);
        }

        [Test]
        public void CheckingAccounts_Controller_Put_ShouldHandleNotFoundexception()
        {
            // Arrange
            _checkingAccountServiceMock.Setup(c => c.Update(_checkingAccountUpdate.Object)).Throws<NotFoundException>();
            _checkingAccountUpdate.Setup(c => c.Validate()).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            IHttpActionResult callback = _checkingAccountsController.Update(_checkingAccountUpdate.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.Content.ErrorCode.Should().Be((int)ErrorCodes.NotFound);
            _checkingAccountServiceMock.Verify(s => s.Update(_checkingAccountUpdate.Object), Times.Once);
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
            IHttpActionResult callback = _checkingAccountsController.UpdateStatus(_checkingAccount.Object.Id);

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
            _checkingAccountServiceMock.Setup(c => c.Remove(_checkingAccountRemove.Object)).Returns(isUpdated);
            _checkingAccountRemove.Setup(c => c.Validate()).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            IHttpActionResult callback = _checkingAccountsController.Delete(_checkingAccountRemove.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _checkingAccountServiceMock.Verify(s => s.Remove(_checkingAccountRemove.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        #endregion
    }
}
