using Bank.Application.Features.Clients;
using Bank.Common.Tests.Features.ObjectMothers;
using Bank.Domain.Features.Clients;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Bank.Application.Tests.Features.Clients
{
    [TestFixture]
    public class ClientAppTests
    {
        private Mock<IClientRepository> _mockRepository;
        private IClientService _service;
        private Client _client;

        [SetUp]
        public void SetUp()
        {
            _client = ObjectMother.GetClientValid();
            _mockRepository = new Mock<IClientRepository>();
            _service = new ClientService(_mockRepository.Object);
        }

        [Test]
        public void Service_Clients_Add_Should_Be_OK()
        {
            //Arrange
            _mockRepository.Setup(r => r.Add(_client)).Returns(_client);

            //Action
            var idInsert = _service.Add(_client);

            //Verify
            idInsert.Should().Be(_client.Id);
            _mockRepository.Verify(r => r.Add(_client));
        }

        [Test]
        public void Service_Clients_Update_Should_Be_OK()
        {
            //Arrange
            var returns = true;

            _mockRepository.Setup(r => r.GetById(_client.Id))
                .Returns(_client);

            _mockRepository.Setup(r => r.Update(_client))
                .Returns(returns);

            //Action
            var idInsert = _service.Update(_client);

            //Verify
            idInsert.Should().Be(returns);
            _mockRepository.Verify(r => r.Update(_client));
        }

        [Test]
        public void Service_Clients_Delete_Should_Be_OK()
        {
            //Arrange
            var returns = true;
            _mockRepository.Setup(r => r.Remove(_client))
                .Returns(returns);
            _mockRepository.Setup(r => r.GetById(_client.Id)).Returns(_client);

            //Action
            var idInsert = _service.Remove(_client);

            //Verify
            idInsert.Should().Be(returns);
            _mockRepository.Verify(r => r.Remove(_client));
            _mockRepository.Verify(r => r.GetById(_client.Id));
        }

        [Test]
        public void Service_Clients_GetAll_Should_Be_OK()
        {
            //Arrange
            var list = new List<Client>();
            IQueryable<Client> query = list.AsQueryable();
            _mockRepository.Setup(r => r.GetAll(null))
                .Returns(query);

            //Action
            var listReturn = _service.GetAll();

            //Verify
            listReturn.Count().Should().Be(query.Count());
            _mockRepository.Verify(r => r.GetAll(null));
        }

        [Test]
        public void Service_Clients_GetByID_Should_Be_OK()
        {
            //Arrange
            var id = 1;
            _mockRepository.Setup(r => r.GetById(id))
                .Returns(_client);

            //Action
            var find = _service.GetById(id);

            //Verify
            find.Id.Should().Be(id);
            _mockRepository.Verify(r => r.GetById(id));
        }
    }
}
