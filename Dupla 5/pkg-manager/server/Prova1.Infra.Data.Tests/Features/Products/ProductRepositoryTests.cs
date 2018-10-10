using Effort;
using FluentAssertions;
using NUnit.Framework;
using Prova1.Common.Tests.Features.ObjectMothers;
using Prova1.Domain.Exceptions;
using Prova1.Domain.Products;
using Prova1.Infra.Data.Tests.Context;
using Prova1.Infra.ORM.Features.Products;
using Prova1.Infra.ORM.Tests.Initializer;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Prova1.Infra.ORM.Tests.Features.Products
{
    [TestFixture]
    public class ProductRepositoryTests : EffortTestBase
    {
        private FakeDbContext _ctx;
        private ProductRepository _repository;
        private Product _product;
        private Product _productSeed;

        [SetUp]
        public void Setup()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _ctx = new FakeDbContext(connection);
            _repository = new ProductRepository(_ctx);
            _product = ObjectMother.GetProductValid();
            //Seed
            _productSeed = ObjectMother.GetProductValid();
            _ctx.Products.Add(_productSeed);
            _ctx.SaveChanges();
        }

        #region ADD
        [Test]
        public void Products_Repository_Add_ShouldBeOk()
        {
            //Action
            var productRegistered = _repository.Add(_product);

            //Assert
            productRegistered.Should().NotBeNull();
            productRegistered.Should().Be(_product);
        }

        #endregion

        #region GET

        [Test]
        public void Products_Repository_GetAll_ShouldBeOk()
        {
            //Action
            var products = _repository.GetAll().ToList();

            //Assert
            products.Should().NotBeNull();
            products.Should().HaveCount(_ctx.Products.Count());
            products.First().Should().Be(_productSeed);
        }

        [Test]
        public void Products_Repository_GetAllWithSize_ShouldBeOk()
        {
            //Arrange
            var size = 1;
            _ctx.Products.Add(_product); // Adiciona mais um além do seed
            _ctx.SaveChanges();
            //Action
            var products = _repository.GetAll(size).ToList();

            //Assert
            products.Should().NotBeNull();
            products.Should().HaveCount(size);
            products.First().Should().Be(_productSeed);
        }

        [Test]
        public void Products_Repository_GetById_ShouldBeOk()
        {
            //Action
            var productResult = _repository.GetById(_productSeed.Id);

            //Assert
            productResult.Should().NotBeNull();
            productResult.Should().Be(_productSeed);
        }

        [Test]
        public void Products_Repository_GetById_ShouldBeNull()
        {
            //Arrange
            var notFoundId = 10;
            //Action
            var productResult = _repository.GetById(notFoundId);
            //Assert
            productResult.Should().BeNull();
        }

        #endregion

        #region DELETE
        [Test]
        public void Products_Repository_Delete_ShouldBeOk()
        {
            // Action
            var wasRemoved = _repository.Remove(_productSeed.Id);
            //Verify
            wasRemoved.Should().BeTrue();
            _ctx.Products.Where(p => p.Id == _productSeed.Id).ToList().Should().BeEmpty();
        }

        [Test]
        public void Products_Repository_Delete_ShouldHandleNotFoundException()
        {
            //Assert
            var notFoundId = 10;
            // Action
            Action callbackRemove = () => _repository.Remove(notFoundId);
            //Verify
            callbackRemove.Should().Throw<NotFoundException>();
        }
        #endregion

        #region UPDATE

        [Test]
        public void Products_Repository_Update_ShouldBeOk()
        {
            var wasUpdated = false;
            var newExpense = 200;
            _productSeed.Expense = newExpense;
            var action = new Action(() => { wasUpdated = _repository.Update(_productSeed); });
            // O EF não deve lançar exception
            action.Should().NotThrow<Exception>();
            wasUpdated.Should().BeTrue();
        }

        [Test]
        public void Products_Repository_Update_ShouldHandleUnknownId()
        {
            _product.Id = 20;
            var action = new Action(() => _repository.Update(_product));

            action.Should().Throw<DbUpdateConcurrencyException>();
        }
        #endregion
    }
}
