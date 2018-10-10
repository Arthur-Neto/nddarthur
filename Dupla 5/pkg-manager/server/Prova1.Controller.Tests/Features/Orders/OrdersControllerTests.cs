using FluentAssertions;
using Moq;
using Prova1.API.Controllers.Orders;
using NUnit.Framework;
using Prova1.Application.Features.Orders;
using Prova1.Domain.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Prova1.Application.Features.Orders.Queries;
using Prova1.Application.Features.Orders.Commands;
using Prova1.Domain.Exceptions;
using Prova1.Controller.Tests.Initializer;
using FluentValidation;
using FluentValidation.Results;
using Prova1.Common.Tests.Features.ObjectMothers;
using Prova1.API.Exceptions;
using Prova1.Application.Features.Orders.ViewModels;
using Microsoft.AspNet.OData;
using System;

namespace Prova1.Controller.Tests.Features.Orders
{
    [TestFixture]
    public class OrdersControllerTests : TestControllerBase
    {
        private OrdersController _ordersController;
        private Mock<IOrderService> _orderServiceMock;
        private Mock<Order> _order;
        private Mock<OrderRegisterCommand> _orderRegisterCmd;
        private Mock<OrderUpdateCommand> _orderUpdateCmd;
        private Mock<OrderRemoveCommand> _orderRemoveCmd;
        private Mock<ValidationResult> _validator;

        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _orderServiceMock = new Mock<IOrderService>();
            _ordersController = new OrdersController(_orderServiceMock.Object)
            {
                Request = request,
            };
            _order = new Mock<Order>();
            _validator = new Mock<ValidationResult>();
            _orderRegisterCmd = new Mock<OrderRegisterCommand>();
            _orderRegisterCmd.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
            _orderUpdateCmd = new Mock<OrderUpdateCommand>();
            _orderUpdateCmd.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
            _orderRemoveCmd = new Mock<OrderRemoveCommand>();
            _orderRemoveCmd.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
            // Retorno padrão: pode ser sobreescrito nos testes
            var isValid = true;
            _validator.Setup(v => v.IsValid).Returns(isValid);
        }

        #region GET

        [Test]
        public void Orders_Controller_Get_ShouldOk()
        {
            // Arrange
            var order = ObjectMother.GetOrderValid();
            var response = new List<Order>() { order }.AsQueryable();
            _orderServiceMock.Setup(s => s.GetAll()).Returns(response);
            var odataOptions = GetOdataQueryOptions<Order>(_ordersController);
            // Action
            var callback = _ordersController.Get(odataOptions);
            //Assert
            _orderServiceMock.Verify(s => s.GetAll(), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<PageResult<OrderViewModel>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(order.Id);
        }

        [Test]
        public void Orders_Controller_GetById_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _order.Setup(p => p.Id).Returns(id);
            _orderServiceMock.Setup(c => c.GetById(id)).Returns(_order.Object);
            // Action
            IHttpActionResult callback = _ordersController.GetById(id);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<OrderViewModel>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Id.Should().Be(id);
            _orderServiceMock.Verify(s => s.GetById(id), Times.Once);
            _order.Verify(p => p.Id, Times.Once);
        }

        #endregion

        #region POST

        [Test]
        public void Orders_Controller_Post_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _orderServiceMock.Setup(c => c.Add(_orderRegisterCmd.Object)).Returns(id);
            // Action
            IHttpActionResult callback = _ordersController.Post(_orderRegisterCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<int>>().Subject;
            httpResponse.Content.Should().Be(id);
            _orderServiceMock.Verify(s => s.Add(_orderRegisterCmd.Object), Times.Once);
        }

        [Test]
        public void Orders_Controller_Post_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validator.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _ordersController.Post(_orderRegisterCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _orderRegisterCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _orderRegisterCmd.VerifyNoOtherCalls();
        }

        #endregion

        #region PUT

        [Test]
        public void Orders_Controller_Put_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _orderServiceMock.Setup(c => c.Update(_orderUpdateCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _ordersController.Update(_orderUpdateCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _orderServiceMock.Verify(s => s.Update(_orderUpdateCmd.Object), Times.Once);
        }

        [Test]
        public void Orders_Controller_Put_ShouldHandleNotFoundexception()
        {
            // Arrange
            _orderServiceMock.Setup(c => c.Update(_orderUpdateCmd.Object)).Throws<NotFoundException>();
            // Action
            Action action = () => _ordersController.Update(_orderUpdateCmd.Object);
            // Assert
            action.Should().ThrowExactly<NotFoundException>();
            // Perceba que é um cenário onde o servico disporou a exception. Logo, ele deve ser chamado.
            _orderServiceMock.Verify(s => s.Update(_orderUpdateCmd.Object), Times.Once);
        }

        [Test]
        public void Orders_Controller_Update_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validator.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _ordersController.Update(_orderUpdateCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _orderUpdateCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _orderUpdateCmd.VerifyNoOtherCalls();
        }


        #endregion

        #region DELETE

        [Test]
        public void Orders_Controller_Delete_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _orderServiceMock.Setup(c => c.Remove(_orderRemoveCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _ordersController.Delete(_orderRemoveCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _orderServiceMock.Verify(s => s.Remove(_orderRemoveCmd.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        [Test]
        public void Orders_Controller_Delete_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validator.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _ordersController.Delete(_orderRemoveCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _orderRemoveCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _orderRemoveCmd.VerifyNoOtherCalls();
        }

        #endregion
    }
}
