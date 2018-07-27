using Bank.Application.Features.Clients;
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
        private Mock<IClientService> _mockClientService;
        private Mock<Client> _mockClient;

        [SetUp]
        public void SetUp()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.SetConfiguration(new HttpConfiguration());

            _mockClientService = new Mock<IClientService>();
            _mockClient = new Mock<Client>();

            _clientsController = new ClientsController()
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
            var httpResponse = callBack.Should().BeOfType<OkNegotiatedContentResult<List<Client>>>().Subject;
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
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<Client>>().Subject;
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
            _clientsController.Request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:6001/api/clients?quantity=" + quantity);
            var client = ObjectMother.GetClientValid();
            var response = new List<Client>() { client }.AsQueryable();
            _mockClientService.Setup(s => s.GetAll(quantity)).Returns(response);

            // Action
            var callback = _clientsController.Get();

            //Assert
            _mockClientService.Verify(s => s.GetAll(quantity), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<Client>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(client.Id);
        }


        [Test]
        public void Client_Controller_Post_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _mockClientService.Setup(c => c.Add(_mockClient.Object)).Returns(id);

            // Action
            var callback = _clientsController.Post(_mockClient.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(id);
            _mockClientService.Verify(s => s.Add(_mockClient.Object), Times.Once);
        }

        [Test]
        public void Client_Controller_Put_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _mockClientService.Setup(c => c.Update(_mockClient.Object)).Returns(isUpdated);

            // Action
            var callback = _clientsController.Put(_mockClient.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _mockClientService.Verify(s => s.Update(_mockClient.Object));
        }


        [Test]
        public void Client_Controller_Put_ShouldHandleNotFoundexception()
        {
            // Arrange
            _mockClientService.Setup(c => c.Update(_mockClient.Object)).Throws<NotFoundException>();

            // Action
            var callback = _clientsController.Put(_mockClient.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.Content.ErrorCode.Should().Be((int)ErrorCodes.NotFound);
            _mockClientService.Verify(s => s.Update(_mockClient.Object));
        }


        [Test]
        public void Client_Controller_Delete_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _mockClientService.Setup(c => c.Remove(_mockClient.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _clientsController.Delete(_mockClient.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _mockClientService.Verify(s => s.Remove(_mockClient.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

    }
}
