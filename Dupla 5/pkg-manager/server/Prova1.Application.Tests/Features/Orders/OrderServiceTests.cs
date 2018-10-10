using FluentAssertions;
using Moq;
using NUnit.Framework;
using Prova1.Application.Features.Orders;
using Prova1.Common.Tests.Features.ObjectMothers;
using Prova1.Domain.Orders;
using Prova1.Domain.Exceptions;
using Prova1.Domain.Features.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using Prova1.Application.Tests.Initializer;
using Prova1.Application.Features.Orders.Queries;
using Prova1.Domain.Features.Products;
using Prova1.Domain.Products;
using Prova1.Application.Features.Orders.ViewModels;

namespace Prova1.Application.Tests.Features.Orders
{
    [TestFixture]
    public class OrderServiceTests : TestServiceBase
    {
        private IOrderService _service;
        private Mock<IOrderRepository> _orderRepositoryFake;
        private Mock<IProductRepository> _productRepositoryFake;


        [SetUp]
        public void Initialize()
        {
            _orderRepositoryFake = new Mock<IOrderRepository>();
            _productRepositoryFake = new Mock<IProductRepository>();
            _service = new OrderService(_orderRepositoryFake.Object, _productRepositoryFake.Object);
        }

        #region ADD 
        [Test]
        public void Orders_Service_Add_ShouldBeOk()
        {
            //Arrange
            var orderCmd = ObjectMother.GetOrderValidToRegister();
            var order = ObjectMother.GetOrderValid();
            _productRepositoryFake.Setup(odr => odr.GetById(order.Product.Id)).Returns(order.Product);
            _orderRepositoryFake.Setup(odr => odr.Add(It.IsAny<Order>())).Returns(order);
            //Action
            var newCustomerId = _service.Add(orderCmd);
            //Assert
            _orderRepositoryFake.Verify(odr => odr.Add(It.IsAny<Order>()), Times.Once);
            newCustomerId.Should().Be(order.Id);
        }


        [Test]
        public void Orders_Service_Add_ShouldBeHandleNotFoundExceptionInProduct()
        {
            //Arrange
            var order = ObjectMother.GetOrderValidToRegister();
            _productRepositoryFake.Setup(odr => odr.GetById(order.ProductId)).Returns((Product)null);
            // Aqui usamos genérico para simular uma exceção qualquer (de banco, etc) disparada pelo repositório
            _orderRepositoryFake.Setup(odr => odr.Add(It.IsAny<Order>())).Throws<NotFoundException>();
            //Action
            Action newCustomerAction = () => { _service.Add(order); };
            //Assert
            newCustomerAction.Should().Throw<NotFoundException>();
            _orderRepositoryFake.Verify(odr => odr.Add(It.IsAny<Order>()), Times.Never);
        }

        [Test]
        public void Orders_Service_Add_ShouldBeHandleException()
        {
            //Arrange
            var order = ObjectMother.GetOrderValid();
            var orderCmd = ObjectMother.GetOrderValidToRegister();
            _productRepositoryFake.Setup(odr => odr.GetById(order.Product.Id)).Returns(order.Product);
            // Aqui usamos genérico para simular uma exceção qualquer (de banco, etc) disparada pelo repositório
            _orderRepositoryFake.Setup(odr => odr.Add(It.IsAny<Order>())).Throws<Exception>();
            var newOrderId = 0;
            //Action
            Action newCustomerAction = () => { newOrderId = _service.Add(orderCmd); };
            //Assert
            newCustomerAction.Should().Throw<Exception>();
            // Perceba que nesse caso estamos simulando um cenário onde o repositório reporta uma exception para o nosso serviço
            _orderRepositoryFake.Verify(odr => odr.Add(It.IsAny<Order>()), Times.Once);
        }

        #endregion

        #region GET 
        [Test]
        public void Orders_Service_GetAll_ShouldBeOk()
        {
            //Arrange
            var order = ObjectMother.GetOrderValid();
            var repositoryMockValue = new List<Order>() { order }.AsQueryable();
            _orderRepositoryFake.Setup(odr => odr.GetAll()).Returns(repositoryMockValue);
            //Action
            var orderCB = _service.GetAll();
            //Assert
            _orderRepositoryFake.Verify(odr => odr.GetAll(), Times.Once);
            orderCB.Should().NotBeNull();
            orderCB.Count().Should().Be(repositoryMockValue.Count());
            //Perceba que Equals de Entity já compara os Id's
            orderCB.First().Should().Be(repositoryMockValue.First());
        }

        [Test]
        public void Orders_Service_GetAllWithSize_ShouldBeOk()
        {
            //Arrange
            var size = 1;
            var order = ObjectMother.GetOrderValid();
            var query = new OrderQuery(size);
            var repositoryMockValue = new List<Order>() { order }.AsQueryable();
            _orderRepositoryFake.Setup(odr => odr.GetAll(query.Size)).Returns(repositoryMockValue);
            //Action
            var orderResult = _service.GetAll(query);
            //Assert
            _orderRepositoryFake.Verify(odr => odr.GetAll(query.Size), Times.Once);
            orderResult.Should().NotBeNull();
            orderResult.Count().Should().Be(repositoryMockValue.Count());
            //Perceba que Equals de Entity já compara os Id's
            orderResult.First().Should().Be(repositoryMockValue.First());
        }

        [Test]
        public void Orders_Service_GetbyId_ShouldBeOk()
        {
            //Arrange
            var order = ObjectMother.GetOrderValid();
            _orderRepositoryFake.Setup(odr => odr.GetById(order.Id)).Returns(order);
            //Action
            var orderResult = _service.GetById(order.Id);
            //Assert
            _orderRepositoryFake.Verify(odr => odr.GetById(order.Id), Times.Once);
            orderResult.Should().NotBeNull();
            orderResult.Should().BeOfType<Order>();
            orderResult.Id.Should().Be(order.Id);
        }

        [Test]
        public void Orders_Service_GetbyId_ShouldBeHandleNotFoundException()
        {
            //Arrange
            var order = ObjectMother.GetOrderValid();
            var exception = new NotFoundException();
            _orderRepositoryFake.Setup(odr => odr.GetById(order.Id)).Throws(exception);
            //Action
            Action orderAction = () => _service.GetById(order.Id);
            //Assert
            orderAction.Should().Throw<NotFoundException>();
            // Perceba que nesse caso estamos simulando um cenário onde o repositório
            // reporta uma exception - logo ele deve ser chamado
            _orderRepositoryFake.Verify(odr => odr.GetById(order.Id), Times.Once);
        }

        #endregion

        #region DELETE
        [Test]
        public void Orders_Service_Delete_ShouldBeOk()
        {
            //Arrange
            var orderCmd = ObjectMother.GetOrderValidToRemove();
            var mockIsRemoved = true;
            _orderRepositoryFake.Setup(odr => odr.Remove(orderCmd.Id)).Returns(mockIsRemoved);
            //Action
            var isOrderRemoved = _service.Remove(orderCmd);
            //Assert
            _orderRepositoryFake.Verify(odr => odr.Remove(orderCmd.Id), Times.Once);
            isOrderRemoved.Should().BeTrue();
        }

        [Test]
        public void Orders_Service_Delete_ShouldBeHandleNotFoundException()
        {
            //Arrange
            var orderCmd = ObjectMother.GetOrderValidToRemove();
            var exception = new NotFoundException();
            _orderRepositoryFake.Setup(odr => odr.Remove(orderCmd.Id)).Throws(exception);
            //Action
            Action orderAction = () => _service.Remove(orderCmd);
            //Assert
            orderAction.Should().Throw<NotFoundException>();
            // Perceba que nesse caso estamos simulando um cenário onde o repositório
            // reporta uma exception - logo ele deve ser chamado
            _orderRepositoryFake.Verify(odr => odr.Remove(orderCmd.Id), Times.Once);
        }

        #endregion

        #region UPDATE
        [Test]
        public void Orders_Service_Update_ShouldBeOk()
        {
            //Arrange
            var order = ObjectMother.GetOrderValid();
            var orderCmd = ObjectMother.GetOrderValidToUpdate();
            var isUpdated = true;
            _orderRepositoryFake.Setup(odr => odr.GetById(orderCmd.Id)).Returns(order);
            _productRepositoryFake.Setup(odr => odr.GetById(orderCmd.ProductId)).Returns(order.Product);
            _orderRepositoryFake.Setup(odr => odr.Update(order)).Returns(isUpdated);
            //Action
            var isOrderRemoved = _service.Update(orderCmd);
            //Assert
            _orderRepositoryFake.Verify(odr => odr.GetById(orderCmd.Id), Times.Once);
            _productRepositoryFake.Verify(p => p.GetById(orderCmd.ProductId), Times.Once);
            _orderRepositoryFake.Verify(odr => odr.Update(order), Times.Once);
            isOrderRemoved.Should().BeTrue();
        }

        [Test]
        public void Orders_Service_Update_ShouldBeHandleNotFoundExceptionInOrder()
        {
            //Arrange
            var order = ObjectMother.GetOrderValidToUpdate();
            _orderRepositoryFake.Setup(odr => odr.GetById(order.Id)).Returns((Order)null);
            //Action
            Action orderAction = () => _service.Update(order);
            //Assert
            orderAction.Should().Throw<NotFoundException>();
            // Perceba que nesse caso estamos simulando um cenário onde o repositório
            // reporta null - logo ele deve ser chamado
            _orderRepositoryFake.Verify(odr => odr.GetById(order.Id), Times.Once);
            _orderRepositoryFake.Verify(odr => odr.Update(It.IsAny<Order>()), Times.Never);
        }

        [Test]
        public void Orders_Service_Update_ShouldBeHandleNotFoundExceptionInProduct()
        {
            //Arrange
            var orderCmd = ObjectMother.GetOrderValidToUpdate();
            var order = ObjectMother.GetOrderValid();
            _orderRepositoryFake.Setup(odr => odr.GetById(orderCmd.Id)).Returns(order);
            _productRepositoryFake.Setup(odr => odr.GetById(orderCmd.ProductId)).Returns((Product)null);
            //Action
            Action orderAction = () => _service.Update(orderCmd);
            //Assert
            orderAction.Should().Throw<NotFoundException>();
            // Perceba que nesse caso estamos simulando um cenário onde o repositório
            // reporta null - logo ele deve ser chamado
            _orderRepositoryFake.Verify(odr => odr.GetById(orderCmd.Id), Times.Once);
            _orderRepositoryFake.Verify(odr => odr.Update(It.IsAny<Order>()), Times.Never);
        }

        #endregion
    }
}
