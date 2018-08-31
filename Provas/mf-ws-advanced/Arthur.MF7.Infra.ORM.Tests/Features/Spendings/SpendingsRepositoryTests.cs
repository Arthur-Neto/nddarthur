using Arthur.MF7.Common.Tests.Features;
using Arthur.MF7.Domain.Exceptions;
using Arthur.MF7.Domain.Features.Spendings;
using Arthur.MF7.Infra.ORM.Features.Spendings;
using Arthur.MF7.Infra.ORM.Tests.Context;
using Arthur.MF7.Infra.ORM.Tests.Initializer;
using Effort;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Arthur.MF7.Infra.ORM.Tests.Features.Spendings
{
    [TestFixture]
    public class SpendingRepositoryTests : EffortTestBase
    {
        private FakeDbContext _ctx;
        private SpendingRepository _repository;
        private Spending _spending;
        private Spending _spendingSeed;

        [SetUp]
        public void Setup()
        {
            System.Data.Common.DbConnection connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _ctx = new FakeDbContext(connection);
            _repository = new SpendingRepository(_ctx);
            _spending = ObjectMother.GetValidSpending();
            //Seed
            _spendingSeed = ObjectMother.GetValidSpending();
            _ctx.Spendings.Add(_spendingSeed);
            _ctx.SaveChanges();
        }

        [Test]
        public void Spendings_Repository_Add_ShouldBeOk()
        {
            //Action
            Spending spendingRegistered = _repository.Add(_spending);
            //Verify
            spendingRegistered.Should().NotBeNull();
            spendingRegistered.Id.Should().NotBe(0);
            Spending expectedSpending = _ctx.Spendings.Find(spendingRegistered.Id);
            expectedSpending.Should().NotBeNull();
            expectedSpending.Should().Be(spendingRegistered);
        }

        [Test]
        public void Spendings_Repository_GetAll_ShouldBeOk()
        {
            //Action
            System.Collections.Generic.List<Spending> spendings = _repository.GetAll().ToList();

            //Assert
            spendings.Should().NotBeNull();
            spendings.Should().HaveCount(_ctx.Spendings.Count());
            spendings.First().Should().Be(_spendingSeed);
        }

        [Test]
        public void Spendings_Repository_GetById_ShouldBeOk()
        {
            //Action
            Spending spendingResult = _repository.GetById(_spendingSeed.Id);

            //Assert
            spendingResult.Should().NotBeNull();
            spendingResult.Should().Be(_spendingSeed);
        }

        [Test]
        public void Spendings_Repository_GetById_ShouldThrowNotFoundException()
        {
            //Action
            int notFoundId = 10;
            Spending spendingResult = _repository.GetById(notFoundId);

            //Assert
            spendingResult.Should().BeNull();
        }

        [Test]
        public void Spendings_Repository_EmployeeWithSpending_ShouldReturnTrue()
        {
            var employeeId = 1;
            _repository.Add(_spendingSeed);

            //Action
            bool spendingResult = _repository.EmployeeWithSpending(employeeId);

            //Assert
            spendingResult.Should().BeTrue();
        }

        [Test]
        public void Spendings_Repository_EmployeeWithSpending_ShouldReturnFalse()
        {
            var employeeId = 99;

            //Action
            bool spendingResult = _repository.EmployeeWithSpending(employeeId);

            //Assert
            spendingResult.Should().BeFalse();
        }

        [Test]
        public void Spendings_Repository_Delete_ShouldBeOk()
        {
            // Action
            bool isRemoved = _repository.Remove(_spendingSeed);
            // Assert
            isRemoved.Should().BeTrue();
            _ctx.Spendings.Where(p => p.Id == _spendingSeed.Id).FirstOrDefault().Should().BeNull();
        }

        [Test]
        public void Spendings_Repository_Delete_ShouldHandleUnknownSpendingId()
        {
            // Arrange
            _spendingSeed.Id = 10;
            // Action
            Action removeAction = () => _repository.Remove(_spendingSeed);
            // Verify
            removeAction.Should().Throw<NotFoundException>();
        }

        [Test]
        public void Spendings_Repository_Update_ShouldBeOk()
        {
            // Arrange
            bool wasUpdated = false;
            string newDescription = "asdasd";
            _spendingSeed.Description = newDescription;
            //Action
            Action actionUpdate = new Action(() => { wasUpdated = _repository.Update(_spendingSeed); });
            // Verify
            actionUpdate.Should().NotThrow<Exception>();
            wasUpdated.Should().BeTrue();
        }
    }
}
