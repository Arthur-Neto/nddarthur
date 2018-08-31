using Arthur.MF7.Application.Features.Employees;
using Arthur.MF7.Application.Features.Employees.Commands;
using Arthur.MF7.Application.Mapping;
using Arthur.MF7.Common.Tests.Features;
using Arthur.MF7.Domain.Exceptions;
using Arthur.MF7.Domain.Features.Employees;
using Arthur.MF7.Domain.Features.Spendings;
using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arthur.MF7.Application.Tests.Features.Employees
{
    [TestFixture]
    public class EmployeeAppTests
    {
        private Mock<IEmployeeRepository> _mockRepository;
        private Mock<ISpendingRepository> _mockSpendingRepo;
        private IEmployeeService _service;
        private Employee _employee;
        private EmployeeRegisterCommand _employeeRegister;
        private EmployeeUpdateCommand _employeeUpdate;
        private EmployeeRemoveCommand _employeeRemove;

        [SetUp]
        public void SetUp()
        {
            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
            _employee = ObjectMother.GetValidEmployee();
            _employeeRegister = Mapper.Map<EmployeeRegisterCommand>(_employee);
            _employeeUpdate = Mapper.Map<EmployeeUpdateCommand>(_employee);
            _employeeRemove = Mapper.Map<EmployeeRemoveCommand>(_employee);
            _mockRepository = new Mock<IEmployeeRepository>();
            _mockSpendingRepo = new Mock<ISpendingRepository>();
            _service = new EmployeeService(_mockRepository.Object, _mockSpendingRepo.Object);
        }

        [Test]
        public void Service_Employees_Add_Should_Be_OK()
        {
            //Arrange
            _mockRepository.Setup(r => r.Add(It.IsAny<Employee>())).Returns(_employee);

            //Action
            long idInsert = _service.Add(_employeeRegister);

            //Verify
            _mockRepository.Verify(r => r.Add(It.IsAny<Employee>()));
        }

        [Test]
        public void Service_Employees_Update_Should_Be_OK()
        {
            //Arrange
            bool returns = true;

            _mockRepository.Setup(r => r.GetById(_employee.Id))
                .Returns(_employee);

            _mockRepository.Setup(r => r.Update(_employee))
                .Returns(returns);

            //Action
            bool idInsert = _service.Update(_employeeUpdate);

            //Verify
            idInsert.Should().Be(returns);
            _mockRepository.Verify(r => r.Update(It.IsAny<Employee>()));
        }

        [Test]
        public void Service_Employees_Delete_Should_Be_OK()
        {
            //Arrange
            bool returns = true;
            _mockRepository.Setup(r => r.Remove(_employee))
                .Returns(returns);
            _mockRepository.Setup(r => r.GetById(_employee.Id)).Returns(_employee);

            //Action
            bool idInsert = _service.Remove(_employeeRemove);

            //Verify
            idInsert.Should().Be(returns);
            _mockRepository.Verify(r => r.Remove(It.IsAny<Employee>()));
            _mockRepository.Verify(r => r.GetById(It.IsAny<long>()));
        }

        [Test]
        public void Service_Employees_Delete_EmployeWithSpending_Should_ReturnFalse()
        {
            //Arrange
            bool returns = false;
            _mockRepository.Setup(r => r.GetById(_employee.Id)).Returns(_employee);
            _mockSpendingRepo.Setup(r => r.EmployeeWithSpending(It.IsAny<long>())).Returns(true);

            //Action
            bool idInsert = _service.Remove(_employeeRemove);

            //Verify
            idInsert.Should().Be(returns);
            _mockRepository.Verify(r => r.GetById(It.IsAny<long>()));
        }

        [Test]
        public void Service_Employees_GetAll_Should_Be_OK()
        {
            //Arrange
            List<Employee> list = new List<Employee>();
            IQueryable<Employee> query = list.AsQueryable();
            _mockRepository.Setup(r => r.GetAll())
                .Returns(query);

            //Action
            IQueryable<Employee> listReturn = _service.GetAll();

            //Verify
            listReturn.Count().Should().Be(query.Count());
            _mockRepository.Verify(r => r.GetAll());
        }

        [Test]
        public void Service_Employees_GetByID_Should_Be_OK()
        {
            //Arrange
            int id = 1;
            _mockRepository.Setup(r => r.GetById(id))
                .Returns(new Employee() { Id = id });

            //Action
            Employee find = _service.GetById(id);

            //Verify
            find.Id.Should().Be(id);
            _mockRepository.Verify(r => r.GetById(id));
        }

        [Test]
        public void Service_Employees_GetByID_Should_Throw_NotFoundException()
        {
            //Arrange
            int id = 0;

            //Action
            Action action = () => _service.GetById(id);

            //Verify
            action.Should().ThrowExactly<NotFoundException>();
        }
    }
}
