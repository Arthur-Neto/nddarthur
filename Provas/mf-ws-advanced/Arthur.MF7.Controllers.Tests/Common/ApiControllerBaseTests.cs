using Arthur.MF7.Domain.Exceptions;
using Arthur.MF7.WebAPI.Exceptions;
using Arthur.MF7.WebAPI.Models;
using FluentAssertions;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Arthur.MF7.Controllers.Tests.Common
{
    [TestFixture]
    public class ApiControllerBaseTests
    {
        private ApiControllerBaseFake _apiControllerBase;
        private Mock<ApiControllerBaseDummy> _dummy;

        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _apiControllerBase = new ApiControllerBaseFake()
            {
                Request = request
            };
            _dummy = new Mock<ApiControllerBaseDummy>();
        }

        #region HandleCallback

        [Test]
        public void Base_Controller_HandleCallback_ShouldHandleBusinessException()
        {
            //Arrange
            string message = "message error test";
            BusinessException exception = new BusinessException(ErrorCodes.AlreadyExists, message);

            // Action
            IHttpActionResult callback = _apiControllerBase.HandleCallback<ApiControllerBaseDummy>(() => throw exception);

            //Assert
            NegotiatedContentResult<ExceptionPayload> httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            httpResponse.Content.ErrorCode.Should().Be((int)ErrorCodes.AlreadyExists);
            httpResponse.Content.ErrorMessage.Should().Be(message);
        }

        [Test]
        public void Base_Controller_HandleCallback_ShouldHandleRuntimeException()
        {
            //Arrange
            string message = "message error test";
            Exception exception = new Exception(message);

            // Action
            IHttpActionResult callback = _apiControllerBase.HandleCallback<ApiControllerBaseDummy>(() => throw exception);

            //Assert
            NegotiatedContentResult<ExceptionPayload> httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
            httpResponse.Content.ErrorCode.Should().Be((int)ErrorCodes.Unhandled);
            httpResponse.Content.ErrorMessage.Should().Be(message);
        }

        #endregion

        #region HandleQuery

        [Test]
        public void Base_Controller_HandleQuery_ShouldBeOk()
        {
            //Arrange
            IQueryable<ApiControllerBaseDummy> query = new List<ApiControllerBaseDummy>() { _dummy.Object }.AsQueryable();

            // Action
            IHttpActionResult callback = _apiControllerBase.HandleQuery(query);

            //Assert
            OkNegotiatedContentResult<List<ApiControllerBaseDummy>> httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<ApiControllerBaseDummy>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
        }

        [Test]
        public async Task Base_Controller_HandleQuery_ShouldHandleCSVExportAsync()
        {
            //Arrange
            IQueryable<ApiControllerBaseDummy> query = new List<ApiControllerBaseDummy>() { _dummy.Object }.AsQueryable();
            _apiControllerBase.Request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(MediaTypes.Csv));

            // Action
            IHttpActionResult callback = _apiControllerBase.HandleQuery(query);

            //Assert
            HttpResponseMessage httpResponse = callback.Should().BeOfType<ResponseMessageResult>().Subject.Response;
            string data = await httpResponse.Content.ReadAsStringAsync();
            data.Should().NotBeNull();
        }

        [Test]
        public async Task Base_Controller_HandleQuery_ShouldHandleCSVExportAsyncWithoutData()
        {
            //Arrange
            IQueryable<ApiControllerBaseDummy> query = new List<ApiControllerBaseDummy>().AsQueryable();
            _apiControllerBase.Request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(MediaTypes.Csv));

            // Action
            IHttpActionResult callback = _apiControllerBase.HandleQuery(query);

            //Assert
            HttpResponseMessage httpResponse = callback.Should().BeOfType<ResponseMessageResult>().Subject.Response;
            string data = await httpResponse.Content.ReadAsStringAsync();
            data.Trim().Should().Be(string.Empty);
            httpResponse.Content.Headers.ContentDisposition.DispositionType.Should().Be("attachment");
            httpResponse.Content.Headers.ContentType.MediaType.Should().Be(MediaTypes.OctetStream);
        }

        #endregion

        #region HandleQueryable
        [Test]
        public void Base_Controller_HandleQueryable_ShouldBeOk()
        {
            //Arrange
            IQueryable<ApiControllerBaseDummy> query = new List<ApiControllerBaseDummy>() { _dummy.Object }.AsQueryable();

            // Action
            IHttpActionResult callback = _apiControllerBase.HandleQueryable<ApiControllerBaseDummy>(query);

            //Assert
            OkNegotiatedContentResult<List<ApiControllerBaseDummy>> httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<ApiControllerBaseDummy>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
        }

        [Test]
        public async Task Base_Controller_HandleQueryable_ShouldHandleCSVExportAsync()
        {
            //Arrange
            IQueryable<ApiControllerBaseDummy> query = new List<ApiControllerBaseDummy>() { _dummy.Object }.AsQueryable();
            _apiControllerBase.Request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(MediaTypes.Csv));

            // Action
            IHttpActionResult callback = _apiControllerBase.HandleQueryable<ApiControllerBaseDummy>(query);

            //Assert
            HttpResponseMessage httpResponse = callback.Should().BeOfType<ResponseMessageResult>().Subject.Response;
            string data = await httpResponse.Content.ReadAsStringAsync();
            data.Should().NotBeNull();
        }

        #endregion

        #region HandleValidationFailure

        [Test]
        public void Base_Controller_HandleValidationFailure_ShouldBeHandleValidationErrors()
        {
            //Arrange
            ValidationFailure validationFailure = new ValidationFailure("", ((int)ErrorCodes.Unhandled).ToString());
            IList<ValidationFailure> errors = new List<ValidationFailure>() { validationFailure };

            // Action
            IHttpActionResult callback = _apiControllerBase.HandleValidationFailure(errors);

            //Assert
            NegotiatedContentResult<IList<ValidationFailure>> httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.FirstOrDefault().Should().Be(validationFailure);
        }

        #endregion

    }
}
