using Effort;
using FluentAssertions;
using NUnit.Framework;
using Prova1.Common.Tests.Features.ObjectMothers;
using Prova1.Domain.Exceptions;
using Prova1.Domain.Orders;
using Prova1.Infra.Data.Tests.Context;
using Prova1.Infra.ORM.Features.Orders;
using Prova1.Infra.ORM.Tests.Initializer;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Entity;

namespace Prova1.Infra.ORM.Tests.Features.Orders
{
    [TestFixture]
    public class OrderRepositoryTests : EffortTestBase
    {
        private FakeDbContext _ctx;
        private OrderRepository _repository;
        private Order _order;
        private Order _orderSeed;

        [SetUp]
        public void Setup()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _ctx = new FakeDbContext(connection);
            _repository = new OrderRepository(_ctx);
            _order = ObjectMother.GetOrderValid();
            //Seed
            _orderSeed = ObjectMother.GetOrderValid();
            _ctx.Orders.Add(_orderSeed);
            _ctx.Products.Add(_orderSeed.Product);
            _ctx.Products.Add(_order.Product);
            _ctx.SaveChanges();
            _orderSeed.ProductId = _orderSeed.Product.Id;
            _order.ProductId = _order.Product.Id;
        }

        #region ADD
        [Test]
        public void Orders_Repository_Add_ShouldBeOk()
        {
            //Action
            var orderRegistered = _repository.Add(_order);
            //Verify
            orderRegistered.Should().NotBeNull();
            orderRegistered.Id.Should().NotBe(0);
            var expectedOrder = _ctx.Orders.Find(orderRegistered.Id);
            expectedOrder.Should().NotBeNull();
            expectedOrder.Should().Be(orderRegistered);
        }

        [Test]
        public void Orders_Repository_Add_ShouldBeHandleUnknownProduct()
        {
            //Arrange
            _order = ObjectMother.GetOrderValid(); // Precisamos de um novo: _order.Product já está indexado
            var unknownId = 50;
            _order.ProductId = unknownId;
            _order.Product.Id = unknownId;
            var unknownOrderId = 2;
            //Action
            Action ordersAddAction = () => _repository.Add(_order);
            //Verify
            ordersAddAction.Should().Throw<DbUpdateException>();
            _ctx.Products.Where(p => p.Id == unknownId).FirstOrDefault().Should().BeNull(); // não deve adicionar o produto
            _ctx.Orders.Include(o => o.Product).Where(o => o.Id == unknownOrderId).FirstOrDefault().Should().BeNull(); // não deve adicionar a order
        }

        #endregion

        #region GET

        [Test]
        public void Orders_Repository_GetAll_ShouldBeOk()
        {
            //Action
            var orders = _repository.GetAll().ToList();

            //Assert
            orders.Should().NotBeNull();
            orders.Should().HaveCount(_ctx.Orders.Count());
            orders.First().Should().Be(_orderSeed);
        }

        [Test]
        public void Orders_Repository_GetAllWithSize_ShouldBeOk()
        {
            //Arrange
            _ctx.Orders.Add(_order); // Adiciono mais um (além do seed) na base de dados
            _ctx.SaveChanges();
            var size = 1;
            //Action
            var orders = _repository.GetAll(size).ToList();

            //Assert
            orders.Should().NotBeNull();
            orders.Should().HaveCount(size);
            orders.First().Should().Be(_orderSeed);
        }

        [Test]
        public void Orders_Repository_GetById_ShouldBeOk()
        {
            //Action
            var orderResult = _repository.GetById(_orderSeed.Id);

            //Assert
            orderResult.Should().NotBeNull();
            orderResult.Should().Be(_orderSeed);
        }

        [Test]
        public void Orders_Repository_GetById_ShouldBeNull()
        {
            //Arrange
            var notFoundId = 10;
            //Action
            var orderResult = _repository.GetById(notFoundId);
            //Assert
            orderResult.Should().BeNull();
        }

        #endregion

        #region DELETE
        [Test]
        public void Orders_Repository_Delete_ShouldBeOk()
        {
            // Action
            var wasRemoved = _repository.Remove(_orderSeed.Id);
            // Assert
            wasRemoved.Should().BeTrue();
            _ctx.Orders.Where(p => p.Id == _orderSeed.Id).FirstOrDefault().Should().BeNull();
        }

        [Test]
        public void Orders_Repository_Delete_ShouldHandleUnknownOrderId()
        {
            // Arrange
            var notFoundId = 10;
            // Action
            Action removeAction = () => _repository.Remove(notFoundId);
            // Verify
            removeAction.Should().Throw<NotFoundException>();
        }
        #endregion

        #region UPDATE

        [Test]
        public void Orders_Repository_Update_ShouldBeOk()
        {
            // Arrange
            var wasUpdated = false;
            var newQuantity = 50;
            _orderSeed.Quantity = newQuantity;
            //Action
            var actionUpdate = new Action(() => { wasUpdated = _repository.Update(_orderSeed); });
            // Verify
            actionUpdate.Should().NotThrow<Exception>();  // O EF não deve lançar exception
            wasUpdated.Should().BeTrue();
        }

        [Test]
        public void Orders_Repository_Update_ShouldHandleUnknownOrderId()
        {
            // Arrange
            var unknownId = 20;
            _order.Id = unknownId;
            //Action
            Action updatedAction = () => _repository.Update(_order);
            // Verify
            updatedAction.Should().Throw<DbUpdateException>();
        }

        [Test]
        public void Orders_Repository_Update_ShouldHandleUnknownProductId()
        {
            // Arrange
            var unknownProductId = 20;
            _orderSeed.ProductId = unknownProductId;
            //Action
            Action updatedAction = () => _repository.Update(_orderSeed);
            // Verify
            updatedAction.Should().Throw<DbUpdateException>();
        }
        #endregion
    }
}
