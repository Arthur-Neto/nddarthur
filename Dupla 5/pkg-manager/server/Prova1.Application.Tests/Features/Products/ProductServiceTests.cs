using FluentAssertions;
using Moq;
using NUnit.Framework;
using Prova1.Application.Features.Products;
using Prova1.Common.Tests.Features.ObjectMothers;
using Prova1.Domain.Products;
using Prova1.Domain.Exceptions;
using Prova1.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using Prova1.Application.Tests.Initializer;
using Prova1.Application.Features.Products.Queries;

namespace Prova1.Application.Tests.Features.Products
{
    [TestFixture]
    public class ProductServiceTests : TestServiceBase
    {
        private IProductService _service;
        private Mock<IProductRepository> _productRepositoryFake;

        [SetUp]
        public void Initialize()
        {
            _productRepositoryFake = new Mock<IProductRepository>();
            _service = new ProductService(_productRepositoryFake.Object);
        }

        #region ADD 
        [Test]
        public void Products_Service_Add_ShouldBeOk()
        {
            //Arrange
            var product = ObjectMother.GetProductValid();
            var productCmd = ObjectMother.GetProductValidToRegister();
            _productRepositoryFake.Setup(pr => pr.Add(It.IsAny<Product>())).Returns(product);
            //Action
            var newCustomerId = _service.Add(productCmd);
            //Assert
            _productRepositoryFake.Verify(pr => pr.Add(It.IsAny<Product>()), Times.Once);
            newCustomerId.Should().Be(product.Id);
        }

        [Test]
        public void Products_Service_Add_ShouldBeHandleException()
        {
            //Arrange
            var product = ObjectMother.GetProductValid();
            var productCmd = ObjectMother.GetProductValidToRegister();
            // Aqui usamos genérico para simular uma exceção qualquer (de banco, etc) disparada pelo repositório
            _productRepositoryFake.Setup(pr => pr.Add(It.IsAny<Product>())).Throws<Exception>();
            //Action
            Action newCustomerAction = () => _service.Add(productCmd);
            //Assert
            newCustomerAction.Should().Throw<Exception>();
            // Perceba que nesse caso estamos simulando um cenário onde o repositório reporta uma exception para o nosso serviço
            _productRepositoryFake.Verify(pr => pr.Add(It.IsAny<Product>()), Times.Once);
        }

        #endregion

        #region GET 
        [Test]
        public void Products_Service_GetAll_ShouldBeOk()
        {
            //Arrange
            var product = ObjectMother.GetProductValid();
            var repositoryMockValue = new List<Product>() { product }.AsQueryable();
            _productRepositoryFake.Setup(pr => pr.GetAll()).Returns(repositoryMockValue);
            //Action
            var productResult = _service.GetAll();
            //Assert
            _productRepositoryFake.Verify(pr => pr.GetAll(), Times.Once);
            productResult.Should().NotBeNull();
            productResult.Count().Should().Be(repositoryMockValue.Count());
            //Perceba que Equals de Entity já compara os Id's
            productResult.First().Should().Be(repositoryMockValue.First());
        }

        [Test]
        public void Products_Service_GetAllWithSize_ShouldBeOk()
        {
            //Arrange
            var product = ObjectMother.GetProductValid();
            var size = 1;
            var repositoryMockValue = new List<Product>() { product }.AsQueryable();
            var query = new ProductQuery(size);
            _productRepositoryFake.Setup(pr => pr.GetAll(query.Size)).Returns(repositoryMockValue);
            //Action
            var productResult = _service.GetAll(query);
            //Assert
            _productRepositoryFake.Verify(pr => pr.GetAll(query.Size), Times.Once);
            productResult.Should().NotBeNull();
            productResult.Count().Should().Be(repositoryMockValue.Count());
            //Perceba que Equals de Entity já compara os Id's
            productResult.First().Should().Be(repositoryMockValue.First());
        }

        [Test]
        public void Products_Service_GetbyId_ShouldBeOk()
        {
            //Arrange
            var product = ObjectMother.GetProductValid();
            _productRepositoryFake.Setup(pr => pr.GetById(product.Id)).Returns(product);
            //Action
            var productResult = _service.GetById(product.Id);
            //Assert
            _productRepositoryFake.Verify(pr => pr.GetById(product.Id), Times.Once);
            productResult.Should().NotBeNull();
            productResult.Id.Should().Be(product.Id);
        }

        [Test]
        public void Products_Service_GetbyId_ShouldBeHandleNotFoundException()
        {
            //Arrange
            var product = ObjectMother.GetProductValid();
            var exception = new NotFoundException();
            _productRepositoryFake.Setup(pr => pr.GetById(product.Id)).Throws(exception);
            //Action
            Action productAction = () => _service.GetById(product.Id);
            //Assert
            productAction.Should().Throw<NotFoundException>();
            // Perceba que nesse caso estamos simulando um cenário onde o repositório
            // reporta uma exception - logo ele deve ser chamado
            _productRepositoryFake.Verify(pr => pr.GetById(product.Id), Times.Once);
        }

        #endregion

        #region DELETE
        [Test]
        public void Products_Service_Delete_ShouldBeOk()
        {
            //Arrange
            var productCmd = ObjectMother.GetProductValidToRemove();
            var mockIsRemoved = true;
            _productRepositoryFake.Setup(pr => pr.Remove(productCmd.Id)).Returns(mockIsRemoved);
            //Action
            var isProductRemoved = _service.Remove(productCmd);
            //Assert
            _productRepositoryFake.Verify(pr => pr.Remove(productCmd.Id), Times.Once);
            isProductRemoved.Should().BeTrue();
        }

        [Test]
        public void Products_Service_Delete_ShouldBeHandleNotFoundException()
        {
            //Arrange
            var productCmd = ObjectMother.GetProductValidToRemove();
            _productRepositoryFake.Setup(pr => pr.Remove(productCmd.Id)).Throws<NotFoundException>();
            //Action
            Action productAction = () => _service.Remove(productCmd);
            //Assert
            productAction.Should().Throw<NotFoundException>();
            // Perceba que nesse caso estamos simulando um cenário onde o repositório
            // reporta uma exception - logo ele deve ser chamado
            _productRepositoryFake.Verify(pr => pr.Remove(productCmd.Id), Times.Once);
        }

        #endregion

        #region UPDATE
        [Test]
        public void Products_Service_Update_ShouldBeOk()
        {
            //Arrange
            var product = ObjectMother.GetProductValid();
            var productCmd = ObjectMother.GetProductValidToUpdate();
            var isUpdated = true;
            _productRepositoryFake.Setup(pr => pr.GetById(productCmd.Id)).Returns(product);
            _productRepositoryFake.Setup(pr => pr.Update(product)).Returns(isUpdated);
            //Action
            var isProductRemoved = _service.Update(productCmd);
            //Assert
            _productRepositoryFake.Verify(pr => pr.GetById(productCmd.Id), Times.Once);
            _productRepositoryFake.Verify(pr => pr.Update(product), Times.Once);
            isProductRemoved.Should().BeTrue();
        }

        [Test]
        public void Products_Service_Update_ShouldBeHandleNotFoundException()
        {
            //Arrange
            var productCmd = ObjectMother.GetProductValidToUpdate();
            _productRepositoryFake.Setup(pr => pr.GetById(productCmd.Id)).Returns((Product)null);
            //Action
            Action productAction = () => _service.Update(productCmd);
            //Assert
            productAction.Should().Throw<NotFoundException>();
            // Perceba que nesse caso estamos simulando um cenário onde o repositório
            // reporta null - logo ele deve ser chamado
            _productRepositoryFake.Verify(pr => pr.GetById(productCmd.Id), Times.Once);
            _productRepositoryFake.Verify(pr => pr.Update(It.IsAny<Product>()), Times.Never);
        }

        #endregion
    }
}
