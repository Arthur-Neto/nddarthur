using FluentAssertions;
using Moq;
using NUnit.Framework;
using Prova1.Common.Tests.Features.ObjectMothers;
using Prova1.Domain.Products;

namespace Prova1.Domain.Tests.Features.Products
{
    [TestFixture]
    public class OrderDomainTest
    {
        private Mock<Product> _product;

        [SetUp]
        public void Initialize() {
            _product = new Mock<Product>();
        }

        [Test]
        public void Orders_Domain_CalculateTotal_ShouldBeOk()
        {
            // Arrange
            var expense = 10;
            var sale = 30;
            var quantity = 2;
            var expectedResult = 40;
            var order = ObjectMother.GetOrder(_product.Object);
            _product.Setup(p => p.Expense).Returns(expense);
            _product.Setup(p => p.Sale).Returns(sale);
            order.Quantity = quantity;
            // Action
            var total = order.Total;
            // Assert
            total.Should().Be(expectedResult);
            _product.Verify(p => p.Expense, Times.Once);
            _product.Verify(p => p.Sale, Times.Once);
        }

        [Test]
        public void Orders_Domain_CalculateTotal_WithoutProduct_ShouldBeOk()
        {
            // Arrange
            var expectedResult = 0;
            var order = ObjectMother.GetOrder(null);
            // Action
            var total = order.Total;
            // Assert
            total.Should().Be(expectedResult);
        }

    }
}
