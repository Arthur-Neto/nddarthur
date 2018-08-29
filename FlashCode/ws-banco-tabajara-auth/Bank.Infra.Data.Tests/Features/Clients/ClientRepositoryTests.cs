using Bank.Common.Tests.Features.ObjectMothers;
using Bank.Domain.Exceptions;
using Bank.Domain.Features.Clients;
using Bank.Infra.Data.Features.Clients;
using Bank.Infra.Data.Tests.Context;
using Bank.Infra.Data.Tests.Initializer;
using Effort;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Bank.Infra.Data.Tests.Features.Clients
{
    [TestFixture]
    public class ClientRepositoryTests : EffortTestBase
    {
        private FakeDbContext _ctx;
        private ClientRepository _repository;
        private Client _client;
        private Client _clientSeed;

        [SetUp]
        public void Setup()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _ctx = new FakeDbContext(connection);
            _repository = new ClientRepository(_ctx);
            _client = ObjectMother.GetClientValid();
            //Seed
            _clientSeed = ObjectMother.GetClientValid();
            _ctx.Clients.Add(_clientSeed);
            _ctx.SaveChanges();
        }

        [Test]
        public void Clients_Repository_Add_ShouldBeOk()
        {
            //Action
            var orderRegistered = _repository.Add(_client);
            //Verify
            orderRegistered.Should().NotBeNull();
            orderRegistered.Id.Should().NotBe(0);
            var expectedCustomer = _ctx.Clients.Find(orderRegistered.Id);
            expectedCustomer.Should().NotBeNull();
            expectedCustomer.Should().Be(orderRegistered);
        }

        [Test]
        public void Clients_Repository_GetAll_ShouldBeOk()
        {
            //Action
            var orders = _repository.GetAll().ToList();

            //Assert
            orders.Should().NotBeNull();
            orders.Should().HaveCount(_ctx.Clients.Count());
            orders.First().Should().Be(_clientSeed);
        }

        [Test]
        public void Clients_Repository_GetById_ShouldBeOk()
        {
            //Action
            var orderResult = _repository.GetById(_clientSeed.Id);

            //Assert
            orderResult.Should().NotBeNull();
            orderResult.Should().Be(_clientSeed);
        }

        [Test]
        public void Clients_Repository_GetById_ShouldThrowNotFoundException()
        {
            //Action
            var notFoundId = 10;
            var orderResult = _repository.GetById(notFoundId);

            //Assert
            orderResult.Should().BeNull();
        }

        [Test]
        public void Clients_Repository_Delete_ShouldBeOk()
        {
            // Action
            var isRemoved = _repository.Remove(_clientSeed);
            // Assert
            isRemoved.Should().BeTrue();
            _ctx.Clients.Where(p => p.Id == _clientSeed.Id).FirstOrDefault().Should().BeNull();
        }

        [Test]
        public void Clients_Repository_Delete_ShouldHandleUnknownClientId()
        {
            // Arrange
            _clientSeed.Id = 10;
            // Action
            Action removeAction = () => _repository.Remove(_clientSeed);
            // Verify
            removeAction.Should().Throw<NotFoundException>();
        }

        [Test]
        public void Clients_Repository_Update_ShouldBeOk()
        {
            // Arrange
            var wasUpdated = false;
            var newCpf = "123123123";
            _clientSeed.Cpf = newCpf;
            //Action
            var actionUpdate = new Action(() => { wasUpdated = _repository.Update(_clientSeed); });
            // Verify
            actionUpdate.Should().NotThrow<Exception>();
            wasUpdated.Should().BeTrue();
        }
    }
}
