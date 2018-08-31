using Arthur.MF7.Application.Features.Spendings;
using Arthur.MF7.Application.Features.Spendings.Commands;
using Arthur.MF7.Application.Features.Spendings.ViewModels;
using Arthur.MF7.Application.Mapping;
using Arthur.MF7.Common.Tests.Features;
using Arthur.MF7.Domain.Features.Spendings;
using Arthur.MF7.WebAPI.Controllers.Spendings;
using FluentAssertions;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Arthur.MF7.Controllers.Tests.Features.Spendings
{
    [TestFixture]
    public class SpendingsControllerTests
    {
        private SpendingsController _spendingsController;
        private Mock<ISpendingRepository> _mockSpendingRepository;
        private Mock<ISpendingService> _mockSpendingService;
        private Mock<Spending> _mockSpending;
        private Mock<SpendingRegisterCommand> _spendingRegister;
        private Mock<SpendingRemoveCommand> _spendingRemove;

        [SetUp]
        public void SetUp()
        {
            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.SetConfiguration(new HttpConfiguration());
            _spendingRegister = new Mock<SpendingRegisterCommand>();
            _spendingRemove = new Mock<SpendingRemoveCommand>();

            _mockSpendingService = new Mock<ISpendingService>();
            _mockSpending = new Mock<Spending>();
            _mockSpendingRepository = new Mock<ISpendingRepository>();
            _spendingsController = new SpendingsController(_mockSpendingService.Object)
            {
                Request = httpRequestMessage,
                _spendingService = _mockSpendingService.Object
            };
        }

        [Test]
        public void Spending_Controller_Get_Should_Be_Ok()
        {
            //Arrange
            Spending spending = ObjectMother.GetValidSpending();
            IQueryable<Spending> listSpendings = new List<Spending> { spending }.AsQueryable();
            _mockSpendingService.Setup(s => s.GetAll()).Returns(listSpendings);

            //Action
            IHttpActionResult callBack = _spendingsController.Get();

            //Verify
            _mockSpendingService.Verify(s => s.GetAll());
            OkNegotiatedContentResult<List<SpendingViewModel>> httpResponse = callBack.Should().BeOfType<OkNegotiatedContentResult<List<SpendingViewModel>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(spending.Id);
        }

        [Test]
        public void Spending_Controller_GetById_ShouldBeOk()
        {
            // Arrange
            int id = 1;
            _mockSpending.Setup(p => p.Id).Returns(id);
            _mockSpendingService.Setup(c => c.GetById(id)).Returns(_mockSpending.Object);

            // Action
            IHttpActionResult callback = _spendingsController.GetById(id);

            // Assert
            OkNegotiatedContentResult<SpendingViewModel> httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<SpendingViewModel>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Id.Should().Be(id);
            _mockSpendingService.Verify(s => s.GetById(id), Times.Once);
            _mockSpending.Verify(p => p.Id);
        }

        [Test]
        public void Spending_Controller_Post_ShouldBeOk()
        {
            // Arrange
            int id = 1;
            _mockSpendingService.Setup(c => c.Add(_spendingRegister.Object)).Returns(id);
            _spendingRegister.Setup(c => c.Validate()).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            IHttpActionResult callback = _spendingsController.Post(_spendingRegister.Object);

            // Assert
            OkNegotiatedContentResult<long> httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(id);
            _mockSpendingService.Verify(s => s.Add(_spendingRegister.Object), Times.Once);
        }

        [Test]
        public void Spending_Controller_Post_ShouldHandleValidationFailure()
        {
            // Arrange
            _spendingRegister.Setup(c => c.Validate().IsValid).Returns(false);

            // Action
            IHttpActionResult callback = _spendingsController.Post(_spendingRegister.Object);

            // Assert
            NegotiatedContentResult<IList<ValidationFailure>> httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
        }

        [Test]
        public void Spending_Controller_Delete_ShouldBeOk()
        {
            // Arrange
            bool isUpdated = true;
            _mockSpendingService.Setup(c => c.Remove(_spendingRemove.Object)).Returns(isUpdated);
            _spendingRemove.Setup(c => c.Validate()).Returns(new FluentValidation.Results.ValidationResult());

            // Action
            IHttpActionResult callback = _spendingsController.Delete(_spendingRemove.Object);
            // Assert
            OkNegotiatedContentResult<bool> httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _mockSpendingService.Verify(s => s.Remove(_spendingRemove.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        [Test]
        public void Spending_Controller_Delete_ShouldHandleValidationFailure()
        {
            // Arrange
            _spendingRemove.Setup(c => c.Validate().IsValid).Returns(false);

            // Action
            IHttpActionResult callback = _spendingsController.Delete(_spendingRemove.Object);

            // Assert
            NegotiatedContentResult<IList<ValidationFailure>> httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
        }
    }
}
