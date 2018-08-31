using Arthur.MF7.Common.Tests.Features;
using Arthur.MF7.Domain.Exceptions;
using Arthur.MF7.Domain.Features.Employees;
using Arthur.MF7.Infra.ORM.Features.Employees;
using Arthur.MF7.Infra.ORM.Tests.Context;
using Arthur.MF7.Infra.ORM.Tests.Initializer;
using Effort;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Arthur.MF7.Infra.ORM.Tests.Features.Employees
{
    [TestFixture]
    public class EmployeeRepositoryTests : EffortTestBase
    {
        private FakeDbContext _ctx;
        private EmployeeRepository _repository;
        private Employee _employee;
        private Employee _employeeSeed;

        [SetUp]
        public void Setup()
        {
            System.Data.Common.DbConnection connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _ctx = new FakeDbContext(connection);
            _repository = new EmployeeRepository(_ctx);
            _employee = ObjectMother.GetValidEmployee();
            //Seed
            _employeeSeed = ObjectMother.GetValidEmployee();
            _ctx.Employees.Add(_employeeSeed);
            _ctx.SaveChanges();
        }

        [Test]
        public void Employees_Repository_Add_ShouldBeOk()
        {
            //Action
            Employee employeeRegistered = _repository.Add(_employee);
            //Verify
            employeeRegistered.Should().NotBeNull();
            employeeRegistered.Id.Should().NotBe(0);
            Employee expectedEmployee = _ctx.Employees.Find(employeeRegistered.Id);
            expectedEmployee.Should().NotBeNull();
            expectedEmployee.Should().Be(employeeRegistered);
        }

        [Test]
        public void Employees_Repository_GetAll_ShouldBeOk()
        {
            //Action
            System.Collections.Generic.List<Employee> employees = _repository.GetAll().ToList();

            //Assert
            employees.Should().NotBeNull();
            employees.Should().HaveCount(_ctx.Employees.Count());
            employees.First().Should().Be(_employeeSeed);
        }

        [Test]
        public void Employees_Repository_GetById_ShouldBeOk()
        {
            //Action
            Employee employeeResult = _repository.GetById(_employeeSeed.Id);

            //Assert
            employeeResult.Should().NotBeNull();
            employeeResult.Should().Be(_employeeSeed);
        }

        [Test]
        public void Employees_Repository_GetById_ShouldThrowNotFoundException()
        {
            //Action
            int notFoundId = 10;
            Employee employeeResult = _repository.GetById(notFoundId);

            //Assert
            employeeResult.Should().BeNull();
        }

        [Test]
        public void Employees_Repository_Delete_ShouldBeOk()
        {
            // Action
            bool isRemoved = _repository.Remove(_employeeSeed);
            // Assert
            isRemoved.Should().BeTrue();
            _ctx.Employees.Where(p => p.Id == _employeeSeed.Id).FirstOrDefault().Should().BeNull();
        }

        [Test]
        public void Employees_Repository_Delete_ShouldHandleUnknownEmployeeId()
        {
            // Arrange
            _employeeSeed.Id = 10;
            // Action
            Action removeAction = () => _repository.Remove(_employeeSeed);
            // Verify
            removeAction.Should().Throw<NotFoundException>();
        }

        [Test]
        public void Employees_Repository_Update_ShouldBeOk()
        {
            // Arrange
            bool wasUpdated = false;
            string newFirstName = "asdasd";
            _employeeSeed.FirstName = newFirstName;
            //Action
            Action actionUpdate = new Action(() => { wasUpdated = _repository.Update(_employeeSeed); });
            // Verify
            actionUpdate.Should().NotThrow<Exception>();
            wasUpdated.Should().BeTrue();
        }
    }
}
