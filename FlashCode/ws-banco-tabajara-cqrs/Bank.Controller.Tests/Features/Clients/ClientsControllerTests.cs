using Bank.Application.Features.Clients;
using Bank.Application.Features.Clients.Commands;
using Bank.Application.Features.Clients.Queries;
using Bank.Application.Features.Clients.ViewModels;
using Bank.Application.Mapping;
using Bank.Common.Tests.Features.ObjectMothers;
using Bank.Domain.Exceptions;
using Bank.Domain.Features.Clients;
using Bank.WebAPI.Controllers.Clients;
using Bank.WebAPI.Exceptions;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Bank.Controller.Tests.Features.Clients
{
    [TestFixture]
    public class ClientsControllerTests
    {
        private ClientsController _clientsController;
        private Mock<IClientRepository> _mockClientRepository;
        private Mock<IClientService> _mockClientService;
        private ClientQuery _clientQuery;
        private Mock<Client> _mockClient;
        private Mock<ClientRegisterCommand> _clientRegister;
        private Mock<ClientRemoveCommand> _clientRemove;
        private Mock<ClientUpdateCommand> _clientUpdate;

        [SetUp]
        public void SetUp()
        {
            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.SetConfiguration(new HttpConfiguration());
            _clientRegister = new Mock<ClientRegisterCommand>();
            _clientRemove = new Mock<ClientRemoveCommand>();
            _clientUpdate = new Mock<ClientUpdateCommand>();
            _clientQuery = new ClientQuery();

            _mockClientService = new Mock<IClientService>();
            _mockClient = new Mock<Client>();
            _mockClientRepository = new Mock<IClientRepository>();
            _clientsController = new ClientsController(_mockClientService.Object)
            {
                Request = httpRequestMessage,
                _clientService = _mockClientService.Object
            };
        }

        [Test]
        public void Client_Controller_Get_Should_Be_Ok()
        {
            //Arrange
            var client = ObjectMother.GetClientValid();
            var listClients = new List<Client> { client }.AsQueryable();
            _mockClientService.Setup(s => s.GetAll(null)).Returns(listClients);

            //Action
            var callBack = _clientsController.Get();

            //Verify
            _mockClientService.Verify(s => s.GetAll(null));
            var httpResponse = callBack.Should().BeOfType<OkNegotiatedContentResult<List<ClientViewModel>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(client.Id);
        }

        [Test]
        public void Client_Controller_GetById_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _mockClient.Setup(p => p.Id).Returns(id);
            _mockClientService.Setup(c => c.GetById(id)).Returns(_mockClient.Object);

            // Action
            var callback = _clientsController.GetById(id);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<ClientViewModel>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Id.Should().Be(id);
            _mockClientService.Verify(s => s.GetById(id), Times.Once);
            _mockClient.Verify(p => p.Id);
        }

        [Test]
        public void Client_Controller_GetByQuantity_ShouldBeOk()
        {
            // Arrange
            var quantity = 1;
            _clientQuery.Quantity = quantity;
            _clientsController.Request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:6001/api/clients?quantity=" + quantity);
            var client = ObjectMother.GetClientValid();
            var response = new List<Client>() { client }.AsQueryable();
            _mockClientService.Setup(s => s.GetAll(It.IsAny<ClientQuery>())).Returns(response);

            // Action
            var callback = _clientsController.Get();

            //Assert
            _mockClientService.Verify(s => s.GetAll(It.IsAny<ClientQuery>()), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<ClientViewModel>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(client.Id);
        }


        [Test]
        public void Client_Controller_Post_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _mockClientService.Setup(c => c.Add(_clientRegister.Object)).Returns(id);
            _clientRegister.Setup(c => c.Validate()).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            var callback = _clientsController.Post(_clientRegister.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(id);
            _mockClientService.Verify(s => s.Add(_clientRegister.Object), Times.Once);
        }

        [Test]
        public void Client_Controller_Put_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _mockClientService.Setup(c => c.Update(_clientUpdate.Object)).Returns(isUpdated);
            _clientUpdate.Setup(c => c.Validate()).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            var callback = _clientsController.Put(_clientUpdate.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _mockClientService.Verify(s => s.Update(_clientUpdate.Object));
        }


        [Test]
        public void Client_Controller_Put_ShouldHandleNotFoundexception()
        {
            // Arrange
            _mockClientService.Setup(c => c.Update(_clientUpdate.Object)).Throws<NotFoundException>();
            _clientUpdate.Setup(c => c.Validate()).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            var callback = _clientsController.Put(_clientUpdate.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.Content.ErrorCode.Should().Be((int)ErrorCodes.NotFound);
            _mockClientService.Verify(s => s.Update(_clientUpdate.Object));
        }


        [Test]
        public void Client_Controller_Delete_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _mockClientService.Setup(c => c.Remove(_clientRemove.Object)).Returns(isUpdated);
            _clientRemove.Setup(c => c.Validate()).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            IHttpActionResult callback = _clientsController.Delete(_clientRemove.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _mockClientService.Verify(s => s.Remove(_clientRemove.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

    }
}
