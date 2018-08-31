using Arthur.MF7.Application.Features.Spendings;
using Arthur.MF7.Application.Features.Spendings.Commands;
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

namespace Arthur.MF7.Application.Tests.Features.Spendings
{
    [TestFixture]
    public class SpendingAppTests
    {
        private Mock<ISpendingRepository> _mockRepository;
        private ISpendingService _service;
        private Mock<IEmployeeRepository> _employeeRepository;
        private Spending _spending;
        private SpendingRegisterCommand _spendingRegister;
        private SpendingRemoveCommand _spendingRemove;

        [SetUp]
        public void SetUp()
        {
            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
            _spending = ObjectMother.GetValidSpending();
            _spendingRegister = Mapper.Map<SpendingRegisterCommand>(_spending);
            _spendingRemove = Mapper.Map<SpendingRemoveCommand>(_spending);
            _mockRepository = new Mock<ISpendingRepository>();
            _employeeRepository = new Mock<IEmployeeRepository>();
            _service = new SpendingService(_mockRepository.Object, _employeeRepository.Object);
        }

        [Test]
        public void Service_Spendings_Add_Should_Be_OK()
        {
            //Arrange
            _mockRepository.Setup(r => r.Add(It.IsAny<Spending>())).Returns(_spending);
            _employeeRepository.Setup(r => r.GetById(It.IsAny<long>())).Returns(new Employee() { Id = 1 });

            //Action
            long idInsert = _service.Add(_spendingRegister);

            //Verify
            _mockRepository.Verify(r => r.Add(It.IsAny<Spending>()));
        }

        [Test]
        public void Service_Spendings_Delete_Should_Be_OK()
        {
            //Arrange
            bool returns = true;
            _mockRepository.Setup(r => r.Remove(_spending))
                .Returns(returns);
            _mockRepository.Setup(r => r.GetById(_spending.Id)).Returns(_spending);

            //Action
            bool idInsert = _service.Remove(_spendingRemove);

            //Verify
            idInsert.Should().Be(returns);
            _mockRepository.Verify(r => r.Remove(It.IsAny<Spending>()));
            _mockRepository.Verify(r => r.GetById(It.IsAny<long>()));
        }

        [Test]
        public void Service_Spendings_GetAll_Should_Be_OK()
        {
            //Arrange
            List<Spending> list = new List<Spending>();
            IQueryable<Spending> query = list.AsQueryable();
            _mockRepository.Setup(r => r.GetAll())
                .Returns(query);

            //Action
            IQueryable<Spending> listReturn = _service.GetAll();

            //Verify
            listReturn.Count().Should().Be(query.Count());
            _mockRepository.Verify(r => r.GetAll());
        }

        [Test]
        public void Service_Spendings_GetAll_With_Quantity_Should_Be_Ok()
        {
            List<Spending> list = new List<Spending>();
            IQueryable<Spending> query = list.AsQueryable();
            _mockRepository.Setup(r => r.GetAll())
                .Returns(query);

            //Action
            IQueryable<Spending> listReturn = _service.GetAll();

            //Verify
            listReturn.Count().Should().Be(query.Count());
            _mockRepository.Verify(r => r.GetAll());
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_Spendings_GetByID_Should_Be_OK()
        {
            //Arrange
            int id = 1;
            _mockRepository.Setup(r => r.GetById(id))
                .Returns(new Spending() { Id = 1 });

            //Action
            Spending find = _service.GetById(id);

            //Verify
            find.Id.Should().Be(id);
            _mockRepository.Verify(r => r.GetById(id));
        }

        [Test]
        public void Service_Spendings_GetByID_Should_Throw_NotFoundException()
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
