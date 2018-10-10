using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Moq;
using NUnit.Framework;
using Projeto_NFe.API.Controladores.Emitentes;
using Projeto_NFe.API.Excecoes;
using Projeto_NFe.Application.Funcionalidades.Emitentes;
using Projeto_NFe.Application.Funcionalidades.Emitentes.Comandos;
using Projeto_NFe.Application.Funcionalidades.Emitentes.Modelos;
using Projeto_NFe.Application.Mapeador;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Controller.Tests.Initializer;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Documentos.CNPJs;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Projeto_NFe.Controller.Tests.Features.Emitentes
{
    [TestFixture]
    public class EmitenteControladorTests : TestControllerBase
    {
        private EmitenteController _emitentesControlador;
        private Mock<IEmitenteServico> _emitenteServicoMock;
        private Mock<Emitente> _emitente;
        private Mock<EmitenteAdicionarComando> _emitenteAdicionarCmd;
        private Mock<EmitenteEditarComando> _emitenteAtualizarCmd;
        private Mock<EmitenteRemoverComando> _emitenteRemoverCmd;
        private Mock<ValidationResult> _validador;

        [SetUp]
        public void Initialize()
        {
            InicializadorAutoMapper.Resetar();
            InicializadorAutoMapper.Inicializar();
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _emitenteServicoMock = new Mock<IEmitenteServico>();
            _emitentesControlador = new EmitenteController(_emitenteServicoMock.Object)
            {
                Request = request,
            };
            _emitente = new Mock<Emitente>();
            _validador = new Mock<ValidationResult>();
            _emitenteAdicionarCmd = new Mock<EmitenteAdicionarComando>();
            _emitenteAdicionarCmd.Setup(cmd => cmd.RealizarValidacaoDoComando()).Returns(_validador.Object);
            _emitenteAtualizarCmd = new Mock<EmitenteEditarComando>();
            _emitenteAtualizarCmd.Setup(cmd => cmd.RealizarValidacaoDoComando()).Returns(_validador.Object);
            _emitenteRemoverCmd = new Mock<EmitenteRemoverComando>();
            _emitenteRemoverCmd.Setup(cmd => cmd.RealizarValidacaoDoComando()).Returns(_validador.Object);
            var isValid = true;
            _validador.Setup(v => v.IsValid).Returns(isValid);
        }

        #region GET

        [Test]
        public void Emitentes_Controller_Get_ShouldOk()
        {
            // Arrange
            CNPJ fakeCnpj = new CNPJ();
            fakeCnpj.numeroSemPontuacao = "41786250000186";
            var emitente = ObjectMother.PegarEmitenteValido(ObjectMother.PegarEnderecoValido(), fakeCnpj);
            var response = new List<Emitente>() { emitente }.AsQueryable();
            _emitenteServicoMock.Setup(s => s.BuscarTodos()).Returns(response);
            var odataOptions = GetOdataQueryOptions<Emitente>(_emitentesControlador);

            // Action
            var callback = _emitentesControlador.BuscarTodos(odataOptions);
            //Assert
            _emitenteServicoMock.Verify(s => s.BuscarTodos(), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<PageResult<EmitenteModelo>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
        }

        [Test]
        public void Emitentes_Controller_GetById_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _emitenteServicoMock.Setup(c => c.BuscarPorId(id)).Returns(_emitente.Object);
            // Action
            IHttpActionResult callback = _emitentesControlador.BuscarPorId(id);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<Emitente>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _emitenteServicoMock.Verify(s => s.BuscarPorId(id), Times.Once);
        }

        #endregion

        #region POST

        [Test]
        public void Emitentes_Controller_Post_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _emitenteServicoMock.Setup(c => c.Adicionar(_emitenteAdicionarCmd.Object)).Returns(id);
            // Action
            IHttpActionResult callback = _emitentesControlador.Add(_emitenteAdicionarCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(id);
            _emitenteServicoMock.Verify(s => s.Adicionar(_emitenteAdicionarCmd.Object), Times.Once);
        }

        [Test]
        public void Emitentes_Controller_Post_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _emitentesControlador.Add(_emitenteAdicionarCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _emitenteAdicionarCmd.Verify(cmd => cmd.RealizarValidacaoDoComando(), Times.Once);
            _emitenteAdicionarCmd.VerifyNoOtherCalls();
        }

        #endregion

        #region PUT

        [Test]
        public void Emitentes_Controller_Put_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _emitenteServicoMock.Setup(c => c.Atualizar(_emitenteAtualizarCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _emitentesControlador.Atualizar(_emitenteAtualizarCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _emitenteServicoMock.Verify(s => s.Atualizar(_emitenteAtualizarCmd.Object), Times.Once);
        }

        [Test]
        public void Emitentes_Controller_Put_ShouldHandleNotFoundexception()
        {
            // Arrange
            _emitenteServicoMock.Setup(c => c.Atualizar(_emitenteAtualizarCmd.Object)).Throws<ExcecaoNaoEncontrado>();
            // Action
            IHttpActionResult callback = _emitentesControlador.Atualizar(_emitenteAtualizarCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigosErros.NotFound);
            _emitenteServicoMock.Verify(s => s.Atualizar(_emitenteAtualizarCmd.Object), Times.Once);
        }

        [Test]
        public void Emitentes_Controller_Update_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _emitentesControlador.Atualizar(_emitenteAtualizarCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _emitenteAtualizarCmd.Verify(cmd => cmd.RealizarValidacaoDoComando(), Times.Once);
            _emitenteAtualizarCmd.VerifyNoOtherCalls();
        }
        #endregion

        #region DELETE

        [Test]
        public void Emitentes_Controller_Delete_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _emitenteServicoMock.Setup(c => c.Excluir(_emitenteRemoverCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _emitentesControlador.Excluir(_emitenteRemoverCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _emitenteServicoMock.Verify(s => s.Excluir(_emitenteRemoverCmd.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        [Test]
        public void Emitentes_Controller_Delete_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _emitentesControlador.Excluir(_emitenteRemoverCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _emitenteRemoverCmd.Verify(cmd => cmd.RealizarValidacaoDoComando(), Times.Once);
            _emitenteRemoverCmd.VerifyNoOtherCalls();
        }

        #endregion
    }
}
