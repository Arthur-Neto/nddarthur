using Arthur.MF7.Application.Features.Employees;
using Arthur.MF7.Application.Features.Employees.Commands;
using Arthur.MF7.Application.Features.Employees.ViewModels;
using Arthur.MF7.Application.Mapping;
using Arthur.MF7.Common.Tests.Features;
using Arthur.MF7.Domain.Exceptions;
using Arthur.MF7.Domain.Features.Employees;
using Arthur.MF7.WebAPI.Controllers.Employees;
using Arthur.MF7.WebAPI.Exceptions;
using FluentAssertions;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Arthur.MF7.Controllers.Tests.Features.Employees
{
    [TestFixture]
    public class EmployeesControllerTests
    {
        private EmployeesController _employeesController;
        private Mock<IEmployeeRepository> _mockEmployeeRepository;
        private Mock<IEmployeeService> _mockEmployeeService;
        private Mock<Employee> _mockEmployee;
        private Mock<EmployeeRegisterCommand> _employeeRegister;
        private Mock<EmployeeRemoveCommand> _employeeRemove;
        private Mock<EmployeeUpdateCommand> _employeeUpdate;

        [SetUp]
        public void SetUp()
        {
            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.SetConfiguration(new HttpConfiguration());
            _employeeRegister = new Mock<EmployeeRegisterCommand>();
            _employeeRemove = new Mock<EmployeeRemoveCommand>();
            _employeeUpdate = new Mock<EmployeeUpdateCommand>();

            _mockEmployeeService = new Mock<IEmployeeService>();
            _mockEmployee = new Mock<Employee>();
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _employeesController = new EmployeesController(_mockEmployeeService.Object)
            {
                Request = httpRequestMessage,
                _employeeService = _mockEmployeeService.Object
            };
        }

        [Test]
        public void Employee_Controller_Get_Should_Be_Ok()
        {
            //Arrange
            var employee = ObjectMother.GetValidEmployee();
            var listEmployees = new List<Employee> { employee }.AsQueryable();
            _mockEmployeeService.Setup(s => s.GetAll()).Returns(listEmployees);

            //Action
            var callBack = _employeesController.Get();

            //Verify
            _mockEmployeeService.Verify(s => s.GetAll());
            var httpResponse = callBack.Should().BeOfType<OkNegotiatedContentResult<List<EmployeeViewModel>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(employee.Id);
        }

        [Test]
        public void Employee_Controller_GetById_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _mockEmployee.Setup(p => p.Id).Returns(id);
            _mockEmployeeService.Setup(c => c.GetById(id)).Returns(_mockEmployee.Object);

            // Action
            var callback = _employeesController.GetById(id);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<EmployeeViewModel>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Id.Should().Be(id);
            _mockEmployeeService.Verify(s => s.GetById(id), Times.Once);
            _mockEmployee.Verify(p => p.Id);
        }

        [Test]
        public void Employee_Controller_Post_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _mockEmployeeService.Setup(c => c.Add(_employeeRegister.Object)).Returns(id);
            _employeeRegister.Setup(c => c.Validate()).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            var callback = _employeesController.Post(_employeeRegister.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(id);
            _mockEmployeeService.Verify(s => s.Add(_employeeRegister.Object), Times.Once);
        }

        [Test]
        public void Employee_Controller_Post_ShouldHandleValidationFailure()
        {
            // Arrange
            _employeeRegister.Setup(c => c.Validate().IsValid).Returns(false);

            // Action
            var callback = _employeesController.Post(_employeeRegister.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
        }

        [Test]
        public void Employee_Controller_Put_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _mockEmployeeService.Setup(c => c.Update(_employeeUpdate.Object)).Returns(isUpdated);
            _employeeUpdate.Setup(c => c.Validate()).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            var callback = _employeesController.Put(_employeeUpdate.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _mockEmployeeService.Verify(s => s.Update(_employeeUpdate.Object));
        }

        [Test]
        public void Employee_Controller_Put_ShouldHandleValidationFailure()
        {
            // Arrange
            _employeeUpdate.Setup(c => c.Validate().IsValid).Returns(false);

            // Action
            var callback = _employeesController.Put(_employeeUpdate.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
        }

        [Test]
        public void Employee_Controller_Put_ShouldHandleNotFoundexception()
        {
            // Arrange
            _mockEmployeeService.Setup(c => c.Update(_employeeUpdate.Object)).Throws<NotFoundException>();
            _employeeUpdate.Setup(c => c.Validate()).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            var callback = _employeesController.Put(_employeeUpdate.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.Content.ErrorCode.Should().Be((int)ErrorCodes.NotFound);
            _mockEmployeeService.Verify(s => s.Update(_employeeUpdate.Object));
        }


        [Test]
        public void Employee_Controller_Delete_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _mockEmployeeService.Setup(c => c.Remove(_employeeRemove.Object)).Returns(isUpdated);
            _employeeRemove.Setup(c => c.Validate()).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            IHttpActionResult callback = _employeesController.Delete(_employeeRemove.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _mockEmployeeService.Verify(s => s.Remove(_employeeRemove.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        [Test]
        public void Employee_Controller_Delete_ShouldHandleValidationFailure()
        {
            // Arrange
            _employeeRemove.Setup(c => c.Validate().IsValid).Returns(false);

            // Action
            IHttpActionResult callback = _employeesController.Delete(_employeeRemove.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
        }

    }
}
