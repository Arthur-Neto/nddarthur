using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Linq;
using Moq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Projeto_NFe.Controller.Tests.Initializer;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.API.Excecoes;
using Projeto_NFe.API.Models;
using Projeto_NFe.Application.Mapeador;

namespace Projeto_NFe.Controller.Tests.Common
{
    [TestFixture]
    public class ApiControllerBaseTests : TestControllerBase
    {
        /* Perceba que esse fake serve apenas para expor os comportamentos de ApiControllerBase */
        private ApiControllerBaseFake _apiControllerBase;
        private Mock<ApiControllerBaseDummy> _dummy;


        [SetUp]
        public void Initialize()
        {
            InicializadorAutoMapper.Resetar();
            InicializadorAutoMapper.Inicializar();
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
            var message = "message error test";
            var exception = new ExcecaoDeNegocio(CodigosErros.AlreadyExists, message);
            // Action
            var callback = _apiControllerBase.HandleCallback<ApiControllerBaseDummy>(() => throw exception);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            httpResponse.Content.CodigoErro.Should().Be((int)CodigosErros.AlreadyExists);
            httpResponse.Content.MensagemErro.Should().Be(message);
        }

        [Test]
        public void Base_Controller_HandleCallback_ShouldHandleRuntimeException()
        {
            //Arrange
            var message = "message error test";
            var exception = new Exception(message);
            // Action
            var callback = _apiControllerBase.HandleCallback<ApiControllerBaseDummy>(() => throw exception);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
            httpResponse.Content.CodigoErro.Should().Be((int)CodigosErros.Unhandled);
            httpResponse.Content.MensagemErro.Should().Be(message);
        }

        #endregion

        #region HandleQuery

        [Test]
        public void Base_Controller_HandleQuery_ShouldBeOk()
        {
            //Arrange
            var query = new List<ApiControllerBaseDummy>() { _dummy.Object }.AsQueryable();
            var odataOptions = GetOdataQueryOptions<ApiControllerBaseDummy>(_apiControllerBase);
            // Action
            var callback = _apiControllerBase.HandleQuery<ApiControllerBaseDummy, ApiControllerBaseDummyQuery>(query, odataOptions);
            //Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<PageResult<ApiControllerBaseDummyQuery>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
        }

        [Test]
        public async Task Base_Controller_HandleQuery_ShouldHandleCSVExportAsync()
        {
            //Arrange
            var query = new List<ApiControllerBaseDummy>() { _dummy.Object }.AsQueryable();
            var odataOptions = GetOdataQueryOptions<ApiControllerBaseDummy>(_apiControllerBase);
            _apiControllerBase.Request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(MediaTypes.Csv));
            // Action
            var callback = _apiControllerBase.HandleQuery<ApiControllerBaseDummy, ApiControllerBaseDummyQuery>(query, odataOptions);
            //Assert
            var httpResponse = callback.Should().BeOfType<ResponseMessageResult>().Subject.Response;
            var data = await httpResponse.Content.ReadAsStringAsync();
            data.Should().NotBeNull();
        }

        [Test]
        public async Task Base_Controller_HandleQuery_ShouldHandleCSVExportAsyncWithoutData()
        {
            //Arrange
            var query = new List<ApiControllerBaseDummy>().AsQueryable();
            var odataOptions = GetOdataQueryOptions<ApiControllerBaseDummy>(_apiControllerBase);
            _apiControllerBase.Request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(MediaTypes.Csv));
            var onlyQueryProperty = "Id";
            // Action
            var callback = _apiControllerBase.HandleQuery<ApiControllerBaseDummy, ApiControllerBaseDummyQuery>(query, odataOptions);
            //Assert
            var httpResponse = callback.Should().BeOfType<ResponseMessageResult>().Subject.Response;
            var data = await httpResponse.Content.ReadAsStringAsync();
            data.Trim().Should().Be(onlyQueryProperty);
            httpResponse.Content.Headers.ContentDisposition.DispositionType.Should().Be("attachment");
            httpResponse.Content.Headers.ContentType.MediaType.Should().Be(MediaTypes.OctetStream);
        }

        #endregion

        #region HandlePageResult
        [Test]
        public void Base_Controller_HandlePageResult_ShouldBeOk()
        {
            //Arrange
            var query = new List<ApiControllerBaseDummy>() { _dummy.Object }.AsQueryable();
            var odataOptions = GetOdataQueryOptions<ApiControllerBaseDummy>(_apiControllerBase);
            // Action
            var callback = _apiControllerBase.HandlePageResult<ApiControllerBaseDummy, ApiControllerBaseDummyQuery>(query, odataOptions);
            //Assert
            var contentResponse = callback.Should().BeOfType<PageResult<ApiControllerBaseDummyQuery>>().Subject;
            contentResponse.Should().NotBeNull();
        }

        [Test]
        public void Base_Controller_HandlePageResult_ShouldHandleCSVExportAsync()
        {
            //Arrange
            var query = new List<ApiControllerBaseDummy>() { _dummy.Object }.AsQueryable();
            var odataOptions = GetOdataQueryOptions<ApiControllerBaseDummy>(_apiControllerBase);
            _apiControllerBase.Request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(MediaTypes.Csv));
            // Action
            var callback = _apiControllerBase.HandlePageResult<ApiControllerBaseDummy, ApiControllerBaseDummyQuery>(query, odataOptions);
            //Assert
            var contentResponse = callback.Should().BeOfType<PageResult<ApiControllerBaseDummyQuery>>().Subject;
            contentResponse.Should().NotBeNull();
        }

        #endregion

        #region HandleValidationFailure

        [Test]
        public void Base_Controller_HandleValidationFailure_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var validationFailure = new ValidationFailure("", ((int)CodigosErros.Unhandled).ToString());
            IList<ValidationFailure> errors = new List<ValidationFailure>() { validationFailure };
            // Action
            var callback = _apiControllerBase.HandleValidationFailure(errors);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.FirstOrDefault().Should().Be(validationFailure);
        }

        #endregion
    }
}
