using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Moq;
using NUnit.Framework;
using Projeto_NFe.API.Controladores.Destinatarios;
using Projeto_NFe.API.Excecoes;
using Projeto_NFe.Application.Funcionalidades.Destinatarios;
using Projeto_NFe.Application.Funcionalidades.Destinatarios.Comandos;
using Projeto_NFe.Application.Funcionalidades.Destinatarios.Modelos;
using Projeto_NFe.Application.Mapeador;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Controller.Tests.Initializer;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Projeto_NFe.Controller.Tests.Features.Destinatarios
{
    [TestFixture]
    public class DestinatarioControladorTests : TestControllerBase
    {
        private DestinatarioController _destinatariosControlador;
        private Mock<IDestinatarioServico> _destinatarioServicoMock;
        private Mock<Destinatario> _destinatario;
        private Mock<DestinatarioAdicionarComando> _destinatarioAdicionarCmd;
        private Mock<DestinatarioEditarComando> _destinatarioAtualizarCmd;
        private Mock<DestinatarioRemoverComando> _destinatarioRemoverCmd;
        private Mock<ValidationResult> _validador;
        private Mock<DestinatarioModelo> _destinatarioModeloMock;

        [SetUp]
        public void Initialize()
        {
            InicializadorAutoMapper.Resetar();
            InicializadorAutoMapper.Inicializar();
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _destinatarioServicoMock = new Mock<IDestinatarioServico>();
            _destinatariosControlador = new DestinatarioController(_destinatarioServicoMock.Object)
            {
                Request = request,
            };
            _destinatario = new Mock<Destinatario>();
            _validador = new Mock<ValidationResult>();
            _destinatarioAdicionarCmd = new Mock<DestinatarioAdicionarComando>();
            _destinatarioAdicionarCmd.Setup(cmd => cmd.RealizarValidacaoDoComando()).Returns(_validador.Object);
            _destinatarioAtualizarCmd = new Mock<DestinatarioEditarComando>();
            _destinatarioAtualizarCmd.Setup(cmd => cmd.RealizarValidacaoDoComando()).Returns(_validador.Object);
            _destinatarioRemoverCmd = new Mock<DestinatarioRemoverComando>();
            _destinatarioRemoverCmd.Setup(cmd => cmd.RealizarValidacaoDoComando()).Returns(_validador.Object);
            var isValid = true;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            _destinatarioModeloMock = new Mock<DestinatarioModelo>();
        }

        #region GET

        [Test]
        public void Destinatarios_Controller_Get_ShouldOk()
        {
            // Arrange
            var destinatario = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();
            var response = new List<Destinatario>() { destinatario }.AsQueryable();
            _destinatarioServicoMock.Setup(s => s.BuscarTodos()).Returns(response);
            var odataOptions = GetOdataQueryOptions<Destinatario>(_destinatariosControlador);
            // Action
            var callback = _destinatariosControlador.BuscarTodos(odataOptions);
            //Assert
            _destinatarioServicoMock.Verify(s => s.BuscarTodos(), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<PageResult<DestinatarioModelo>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
        }

        [Test]
        public void Destinatarios_Controller_GetById_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _destinatarioServicoMock.Setup(c => c.BuscarPorId(id)).Returns(_destinatario.Object);
            // Action
            IHttpActionResult callback = _destinatariosControlador.BuscarPorId(id);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<Destinatario>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _destinatarioServicoMock.Verify(s => s.BuscarPorId(id), Times.Once);
        }

        #endregion

        #region POST

        [Test]
        public void Destinatarios_Controller_Post_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _destinatarioServicoMock.Setup(c => c.Adicionar(_destinatarioAdicionarCmd.Object)).Returns(id);
            // Action
            IHttpActionResult callback = _destinatariosControlador.Add(_destinatarioAdicionarCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(id);
            _destinatarioServicoMock.Verify(s => s.Adicionar(_destinatarioAdicionarCmd.Object), Times.Once);
        }

        [Test]
        public void Destinatarios_Controller_Post_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            _destinatarioAdicionarCmd.Setup(cmd => cmd.RealizarValidacaoDoComando()).Returns(_validador.Object);
            // Action
            var callback = _destinatariosControlador.Add(_destinatarioAdicionarCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _destinatarioAdicionarCmd.Verify(cmd => cmd.RealizarValidacaoDoComando(), Times.Once);
            _destinatarioAdicionarCmd.VerifyNoOtherCalls();
        }

        #endregion

        #region PUT

        [Test]
        public void Destinatarios_Controller_Put_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _destinatarioServicoMock.Setup(c => c.Atualizar(_destinatarioAtualizarCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _destinatariosControlador.Atualizar(_destinatarioAtualizarCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _destinatarioServicoMock.Verify(s => s.Atualizar(_destinatarioAtualizarCmd.Object), Times.Once);
        }

        [Test]
        public void Destinatarios_Controller_Put_ShouldHandleNotFoundexception()
        {
            // Arrange
            _destinatarioServicoMock.Setup(c => c.Atualizar(_destinatarioAtualizarCmd.Object)).Throws<ExcecaoNaoEncontrado>();
            // Action
            IHttpActionResult callback = _destinatariosControlador.Atualizar(_destinatarioAtualizarCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigosErros.NotFound);
            _destinatarioServicoMock.Verify(s => s.Atualizar(_destinatarioAtualizarCmd.Object), Times.Once);
        }

        [Test]
        public void Destinatarios_Controller_Update_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _destinatariosControlador.Atualizar(_destinatarioAtualizarCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _destinatarioAtualizarCmd.Verify(cmd => cmd.RealizarValidacaoDoComando(), Times.Once);
            _destinatarioAtualizarCmd.VerifyNoOtherCalls();
        }
        #endregion

        #region DELETE

        [Test]
        public void Destinatarios_Controller_Delete_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _destinatarioServicoMock.Setup(c => c.Excluir(_destinatarioRemoverCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _destinatariosControlador.Excluir(_destinatarioRemoverCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _destinatarioServicoMock.Verify(s => s.Excluir(_destinatarioRemoverCmd.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        [Test]
        public void Destinatarios_Controller_Delete_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _destinatariosControlador.Excluir(_destinatarioRemoverCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _destinatarioRemoverCmd.Verify(cmd => cmd.RealizarValidacaoDoComando(), Times.Once);
            _destinatarioRemoverCmd.VerifyNoOtherCalls();
        }

        #endregion
    }
}
