using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Moq;
using NUnit.Framework;
using Prova1.API.Controllers.Products;
using Prova1.Application.Features.Products;
using Prova1.Application.Features.Products.Commands;
using Prova1.Application.Features.Products.Queries;
using Prova1.Application.Features.Products.ViewModels;
using Prova1.Common.Tests.Features.ObjectMothers;
using Prova1.Controller.Tests.Initializer;
using Prova1.Domain.Products;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Prova1.Controller.Tests.Features.Products
{
    [TestFixture]
    public class ProductsControllerTests : TestControllerBase
    {
        private ProductsController _productsController;
        private Mock<IProductService> _productServiceMock;

        private Mock<ProductUpdateCommand> _productUpdateCmd;
        private Mock<ProductRegisterCommand> _productRegisterCmd;
        private Mock<ProductRemoveCommand> _productRemoveCmd;
        private Mock<Product> _product;
        private Mock<ValidationResult> _validator;
    
        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _productServiceMock = new Mock<IProductService>();
            _productsController = new ProductsController(_productServiceMock.Object)
            {
                Request = request,
            };
            _validator = new Mock<ValidationResult>();
            _productUpdateCmd = new Mock<ProductUpdateCommand>();
            _productUpdateCmd.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
            _productRegisterCmd = new Mock<ProductRegisterCommand>();
            _productRegisterCmd.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
            _productRemoveCmd = new Mock<ProductRemoveCommand>();
            _productRemoveCmd.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
            _product = new Mock<Product>();
            // Retorno padrão: pode ser sobreescrito nos testes
            var isValid = true;
            _validator.Setup(v => v.IsValid).Returns(isValid);
        }

        #region GET

        [Test]
        public void Products_Controller_Get_ShouldOk()
        {
            // Arrange
            var product = ObjectMother.GetProductValid();
            var response = new List<Product>() { product }.AsQueryable();
            _productServiceMock.Setup(s => s.GetAll()).Returns(response);
            var id = 1;
            _productUpdateCmd.Setup(p => p.Id).Returns(id);
            var odataOptions = GetOdataQueryOptions<Product>(_productsController);
            // Action
            var callback = _productsController.Get(odataOptions);

            //Assert
            _productServiceMock.Verify(s => s.GetAll(), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<PageResult<ProductViewModel>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(id);
        }

        [Test]
        public void Products_Controller_GetById_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _productUpdateCmd.Setup(p => p.Id).Returns(id);
            _product.Setup(p => p.Id).Returns(id);
            _productServiceMock.Setup(c => c.GetById(id)).Returns(_product.Object);
            // Action
            IHttpActionResult callback = _productsController.GetById(id);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<ProductViewModel>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Id.Should().Be(id);
            _productServiceMock.Verify(s => s.GetById(id), Times.Once);
        }

        [Test]
        public void Products_Controller_GetWithSize_ShouldBeOk()
        {
            // Arrange
            var size = 1;
            var id = 1;
            var odataOptions = GetOdataQueryOptions<Product>(_productsController);
            _productsController.Request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:9005/api/products?size=" + size);
            _product.Setup(p => p.Id).Returns(id);
            var response = new List<Product>() { _product.Object }.AsQueryable();
            _productServiceMock.Setup(s => s.GetAll(It.IsAny<ProductQuery>())).Returns(response);
            // Action
            var callback = _productsController.Get(odataOptions);
            //Assert
            _productServiceMock.Verify(s => s.GetAll(It.IsAny<ProductQuery>()), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<PageResult<ProductViewModel>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(id);
        }

        #endregion

        #region POST

        [Test]
        public void Products_Controller_Post_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _productServiceMock.Setup(c => c.Add(_productRegisterCmd.Object)).Returns(id);
            // Action
            IHttpActionResult callback = _productsController.Post(_productRegisterCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<int>>().Subject;
            httpResponse.Content.Should().Be(id);
            _productServiceMock.Verify(s => s.Add(_productRegisterCmd.Object), Times.Once);
        }

        [Test]
        public void products_Controller_Post_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validator.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _productsController.Post(_productRegisterCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _productRegisterCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _productRegisterCmd.VerifyNoOtherCalls();
        }

        #endregion

        #region PUT

        [Test]
        public void Products_Controller_Put_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _productServiceMock.Setup(c => c.Update(_productUpdateCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _productsController.Update(_productUpdateCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _productServiceMock.Verify(s => s.Update(_productUpdateCmd.Object), Times.Once);
        }

        [Test]
        public void products_Controller_Update_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validator.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _productsController.Update(_productUpdateCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _productUpdateCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _productUpdateCmd.VerifyNoOtherCalls();
        }

        #endregion

        #region DELETE

        [Test]
        public void Products_Controller_Delete_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _productServiceMock.Setup(c => c.Remove(_productRemoveCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _productsController.Delete(_productRemoveCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _productServiceMock.Verify(s => s.Remove(_productRemoveCmd.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        [Test]
        public void Products_Controller_Delete_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validator.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _productsController.Delete(_productRemoveCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _productRemoveCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _productRemoveCmd.VerifyNoOtherCalls();
        }

        #endregion

    }
}
