using AutoMapper;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Moq;
using NUnit.Framework;
using Projeto_NFe.API.Controladores.NotaFiscals;
using Projeto_NFe.API.Excecoes;
using Projeto_NFe.Application.Funcionalidades.Notas_Fiscais;
using Projeto_NFe.Application.Funcionalidades.Notas_Fiscais.Comandos;
using Projeto_NFe.Application.Funcionalidades.Notas_Fiscais.Modelos;
using Projeto_NFe.Application.Mapeador;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Controller.Tests.Initializer;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Projeto_NFe.Controller.Tests.Features.NotaFiscals
{
    [TestFixture]
    public class NotaFiscalControladorTests : TestControllerBase
    {
        private NotaFiscalController _notasFiscaissControlador;
        private Mock<INotaFiscalServico> _notasFiscaisServicoMock;
        private Mock<NotaFiscal> _notasFiscais;
        private Mock<NotaFiscalAdicionarComando> _notasFiscaisAdicionarCmd;
        private Mock<NotaFiscalEditarComando> _notasFiscaisAtualizarCmd;
        private Mock<NotaFiscalRemoverComando> _notasFiscaisRemoverCmd;
        private Mock<ValidationResult> _validador;

        [SetUp]
        public void Initialize()
        {
            InicializadorAutoMapper.Resetar();
            InicializadorAutoMapper.Inicializar();
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _notasFiscaisServicoMock = new Mock<INotaFiscalServico>();
            _notasFiscaissControlador = new NotaFiscalController(_notasFiscaisServicoMock.Object)
            {
                Request = request,
            };
            _notasFiscais = new Mock<NotaFiscal>();
            _validador = new Mock<ValidationResult>();
            _notasFiscaisAdicionarCmd = new Mock<NotaFiscalAdicionarComando>();
            _notasFiscaisAdicionarCmd.Setup(cmd => cmd.RealizarValidacaoDoComando()).Returns(_validador.Object);
            _notasFiscaisAtualizarCmd = new Mock<NotaFiscalEditarComando>();
            _notasFiscaisAtualizarCmd.Setup(cmd => cmd.RealizarValidacaoDoComando()).Returns(_validador.Object);
            _notasFiscaisRemoverCmd = new Mock<NotaFiscalRemoverComando>();
            _notasFiscaisRemoverCmd.Setup(cmd => cmd.RealizarValidacaoDoComando()).Returns(_validador.Object);
            var isValid = true;
            _validador.Setup(v => v.IsValid).Returns(isValid);
        }

        #region GET

        [Test]
        public void NotaFiscal_Controller_Get_ShouldOk()
        {
            // Arrange
            var notasFiscais = ObjectMother.PegarNotaFiscalValida(ObjectMother.PegarEmitenteValidoSemDependencias(), ObjectMother.PegarDestinatarioValidoComCPF(), ObjectMother.PegarTransportadorValidoComCPF(ObjectMother.PegarEnderecoValido(), new Documento("24760862072", TipoDocumento.CPF)));
            var response = new List<NotaFiscal>() { notasFiscais }.AsQueryable();
            _notasFiscaisServicoMock.Setup(s => s.BuscarTodos()).Returns(response);
            var odataOptions = GetOdataQueryOptions<NotaFiscal>(_notasFiscaissControlador);
            // Action
            var callback = _notasFiscaissControlador.BuscarTodos(odataOptions);
            //Assert
            _notasFiscaisServicoMock.Verify(s => s.BuscarTodos(), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<PageResult<NotaFiscalModelo>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void NotaFiscal_Controller_GetById_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _notasFiscaisServicoMock.Setup(c => c.BuscarPorId(id)).Returns(_notasFiscais.Object);
            // Action
            IHttpActionResult callback = _notasFiscaissControlador.BuscarPorId(id);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<NotaFiscal>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _notasFiscaisServicoMock.Verify(s => s.BuscarPorId(id), Times.Once);
        }

        #endregion

        #region POST

        [Test]
        public void NotaFiscal_Controller_Post_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _notasFiscaisServicoMock.Setup(c => c.Adicionar(_notasFiscaisAdicionarCmd.Object)).Returns(id);
            // Action
            IHttpActionResult callback = _notasFiscaissControlador.Add(_notasFiscaisAdicionarCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(id);
            _notasFiscaisServicoMock.Verify(s => s.Adicionar(_notasFiscaisAdicionarCmd.Object), Times.Once);
        }

        [Test]
        public void NotaFiscal_Controller_Post_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _notasFiscaissControlador.Add(_notasFiscaisAdicionarCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _notasFiscaisAdicionarCmd.Verify(cmd => cmd.RealizarValidacaoDoComando(), Times.Once);
            _notasFiscaisAdicionarCmd.VerifyNoOtherCalls();
        }

        #endregion

        #region PUT

        [Test]
        public void NotaFiscal_Controller_Put_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _notasFiscaisServicoMock.Setup(c => c.Atualizar(_notasFiscaisAtualizarCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _notasFiscaissControlador.Atualizar(_notasFiscaisAtualizarCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _notasFiscaisServicoMock.Verify(s => s.Atualizar(_notasFiscaisAtualizarCmd.Object), Times.Once);
        }

        [Test]
        public void NotaFiscal_Controller_Put_ShouldHandleNotFoundexception()
        {
            // Arrange
            _notasFiscaisServicoMock.Setup(c => c.Atualizar(_notasFiscaisAtualizarCmd.Object)).Throws<ExcecaoNaoEncontrado>();
            // Action
            IHttpActionResult callback = _notasFiscaissControlador.Atualizar(_notasFiscaisAtualizarCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigosErros.NotFound);
            _notasFiscaisServicoMock.Verify(s => s.Atualizar(_notasFiscaisAtualizarCmd.Object), Times.Once);
        }

        [Test]
        public void NotaFiscal_Controller_Update_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _notasFiscaissControlador.Atualizar(_notasFiscaisAtualizarCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _notasFiscaisAtualizarCmd.Verify(cmd => cmd.RealizarValidacaoDoComando(), Times.Once);
            _notasFiscaisAtualizarCmd.VerifyNoOtherCalls();
        }
        #endregion

        #region DELETE

        [Test]
        public void NotaFiscal_Controller_Delete_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _notasFiscaisServicoMock.Setup(c => c.Excluir(_notasFiscaisRemoverCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _notasFiscaissControlador.Excluir(_notasFiscaisRemoverCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _notasFiscaisServicoMock.Verify(s => s.Excluir(_notasFiscaisRemoverCmd.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        [Test]
        public void NotaFiscal_Controller_Delete_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _notasFiscaissControlador.Excluir(_notasFiscaisRemoverCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _notasFiscaisRemoverCmd.Verify(cmd => cmd.RealizarValidacaoDoComando(), Times.Once);
            _notasFiscaisRemoverCmd.VerifyNoOtherCalls();
        }

        #endregion
    }
}
