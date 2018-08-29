using AutoMapper;
using Bank.Application.Features.Clients;
using Bank.Application.Features.Clients.Commands;
using Bank.Application.Features.Clients.Queries;
using Bank.Application.Mapping;
using Bank.Common.Tests.Features.ObjectMothers;
using Bank.Domain.Exceptions;
using Bank.Domain.Features.Clients;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
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
        private ClientRegisterCommand _clientRegister;
        private ClientUpdateCommand _clientUpdate;
        private ClientRemoveCommand _clientRemove;

        [SetUp]
        public void SetUp()
        {
            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
            _client = ObjectMother.GetClientValid();
            _clientRegister = Mapper.Map<ClientRegisterCommand>(_client);
            _clientUpdate = Mapper.Map<ClientUpdateCommand>(_client);
            _clientRemove = Mapper.Map<ClientRemoveCommand>(_client);
            _mockRepository = new Mock<IClientRepository>();
            _service = new ClientService(_mockRepository.Object);
        }

        [Test]
        public void Service_Clients_Add_Should_Be_OK()
        {
            //Arrange
            _mockRepository.Setup(r => r.Add(It.IsAny<Client>())).Returns(_client);

            //Action
            long idInsert = _service.Add(_clientRegister);

            //Verify
            _mockRepository.Verify(r => r.Add(It.IsAny<Client>()));
        }

        [Test]
        public void Service_Clients_Update_Should_Be_OK()
        {
            //Arrange
            bool returns = true;

            _mockRepository.Setup(r => r.GetById(_client.Id))
                .Returns(_client);

            _mockRepository.Setup(r => r.Update(_client))
                .Returns(returns);

            //Action
            bool idInsert = _service.Update(_clientUpdate);

            //Verify
            idInsert.Should().Be(returns);
            _mockRepository.Verify(r => r.Update(It.IsAny<Client>()));
        }

        [Test]
        public void Service_Clients_Delete_Should_Be_OK()
        {
            //Arrange
            bool returns = true;
            _mockRepository.Setup(r => r.Remove(_client))
                .Returns(returns);
            _mockRepository.Setup(r => r.GetById(_client.Id)).Returns(_client);

            //Action
            bool idInsert = _service.Remove(_clientRemove);

            //Verify
            idInsert.Should().Be(returns);
            _mockRepository.Verify(r => r.Remove(It.IsAny<Client>()));
            _mockRepository.Verify(r => r.GetById(It.IsAny<long>()));
        }

        [Test]
        public void Service_Clients_GetAll_Should_Be_OK()
        {
            //Arrange
            List<Client> list = new List<Client>();
            ClientQuery clientQuery = new ClientQuery();
            clientQuery = null;
            IQueryable<Client> query = list.AsQueryable();
            _mockRepository.Setup(r => r.GetAll(null))
                .Returns(query);

            //Action
            IQueryable<Client> listReturn = _service.GetAll(clientQuery);

            //Verify
            listReturn.Count().Should().Be(query.Count());
            _mockRepository.Verify(r => r.GetAll(null));
        }

        [Test]
        public void Service_Clients_GetAll_With_Quantity_Should_Be_Ok()
        {
            //Arrange
            int quantity = 5;
            List<Client> list = new List<Client>();
            ClientQuery clientQuery = new ClientQuery
            {
                Quantity = quantity
            };
            IQueryable<Client> query = list.AsQueryable();
            _mockRepository.Setup(r => r.GetAll(quantity))
                .Returns(query);

            //Action
            IQueryable<Client> listReturn = _service.GetAll(clientQuery);

            //Verify
            listReturn.Count().Should().Be(query.Count());
            _mockRepository.Verify(r => r.GetAll(quantity));
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_Clients_GetByID_Should_Be_OK()
        {
            //Arrange
            int id = 1;
            _mockRepository.Setup(r => r.GetById(id))
                .Returns(_client);

            //Action
            Client find = _service.GetById(id);

            //Verify
            find.Id.Should().Be(id);
            _mockRepository.Verify(r => r.GetById(id));
        }

        [Test]
        public void Service_Clients_GetByID_Should_Throw_NotFoundException()
        {
            //Arrange
            int id = 0;

            //Action
            Action action = () => _service.GetById(id);

            //Verify
            action.Should().ThrowExactly<NotFoundException>();
        }
    }
}
