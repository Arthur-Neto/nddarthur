using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Moq;
using NUnit.Framework;
using Projeto_NFe.API.Controladores.Transportadors;
using Projeto_NFe.API.Excecoes;
using Projeto_NFe.Application.Funcionalidades.Transportadoras;
using Projeto_NFe.Application.Funcionalidades.Transportadoras.Comandos;
using Projeto_NFe.Application.Funcionalidades.Transportadoras.Modelos;
using Projeto_NFe.Application.Mapeador;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Controller.Tests.Initializer;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Documentos.CPFs;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Projeto_NFe.Controller.Tests.Features.Transportadors
{
    [TestFixture]
    public class TransportadorControladorTests : TestControllerBase
    {
        private TransportadorController _transportadorsControlador;
        private Mock<ITransportadorServico> _transportadorServicoMock;
        private Mock<Transportador> _transportador;
        private Mock<TransportadorAdicionarComando> _transportadorAdicionarCmd;
        private Mock<TransportadorEditarComando> _transportadorAtualizarCmd;
        private Mock<TransportadorRemoverComando> _transportadorRemoverCmd;
        private Mock<ValidationResult> _validador;

        [SetUp]
        public void Initialize()
        {
            InicializadorAutoMapper.Resetar();
            InicializadorAutoMapper.Inicializar();
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _transportadorServicoMock = new Mock<ITransportadorServico>();
            _transportadorsControlador = new TransportadorController(_transportadorServicoMock.Object)
            {
                Request = request,
            };
            _transportador = new Mock<Transportador>();
            _validador = new Mock<ValidationResult>();
            _transportadorAdicionarCmd = new Mock<TransportadorAdicionarComando>();
            _transportadorAdicionarCmd.Setup(cmd => cmd.RealizarValidacaoDoComando()).Returns(_validador.Object);
            _transportadorAtualizarCmd = new Mock<TransportadorEditarComando>();
            _transportadorAtualizarCmd.Setup(cmd => cmd.RealizarValidacaoDoComando()).Returns(_validador.Object);
            _transportadorRemoverCmd = new Mock<TransportadorRemoverComando>();
            _transportadorRemoverCmd.Setup(cmd => cmd.RealizarValidacaoDoComando()).Returns(_validador.Object);
            bool isValid = true;
            _validador.Setup(v => v.IsValid).Returns(isValid);
        }

        #region GET

        [Test]
        public void Transportador_Controller_Get_ShouldOk()
        {
            // Arrange
            CPF cpf = new CPF() { numeroSemPontuacao = "24760862072" };
            Transportador transportador = ObjectMother.PegarTransportadorValidoComCPF(ObjectMother.PegarEnderecoValido(), cpf);
            IQueryable<Transportador> response = new List<Transportador>() { transportador }.AsQueryable();
            _transportadorServicoMock.Setup(s => s.BuscarTodos()).Returns(response);
            Microsoft.AspNet.OData.Query.ODataQueryOptions<Transportador> odataOptions = GetOdataQueryOptions<Transportador>(_transportadorsControlador);
            // Action
            IHttpActionResult callback = _transportadorsControlador.BuscarTodos(odataOptions);
            //Assert
            _transportadorServicoMock.Verify(s => s.BuscarTodos(), Times.Once);
            OkNegotiatedContentResult<PageResult<TransportadorModelo>> httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<PageResult<TransportadorModelo>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void Transportador_Controller_GetById_ShouldBeOk()
        {
            // Arrange
            int id = 1;
            _transportadorServicoMock.Setup(c => c.BuscarPorId(id)).Returns(_transportador.Object);
            // Action
            IHttpActionResult callback = _transportadorsControlador.BuscarPorId(id);
            // Assert
            OkNegotiatedContentResult<Transportador> httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<Transportador>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _transportadorServicoMock.Verify(s => s.BuscarPorId(id), Times.Once);
        }

        #endregion

        #region POST

        [Test]
        public void Transportador_Controller_Post_ShouldBeOk()
        {
            // Arrange
            int id = 1;
            _transportadorServicoMock.Setup(c => c.Adicionar(_transportadorAdicionarCmd.Object)).Returns(id);
            // Action
            IHttpActionResult callback = _transportadorsControlador.Add(_transportadorAdicionarCmd.Object);
            // Assert
            OkNegotiatedContentResult<long> httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(id);
            _transportadorServicoMock.Verify(s => s.Adicionar(_transportadorAdicionarCmd.Object), Times.Once);
        }

        [Test]
        public void Transportador_Controller_Post_ShouldBeHandleValidationErrors()
        {
            //Arrange
            bool isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            IHttpActionResult callback = _transportadorsControlador.Add(_transportadorAdicionarCmd.Object);
            //Assert
            NegotiatedContentResult<IList<ValidationFailure>> httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _transportadorAdicionarCmd.Verify(cmd => cmd.RealizarValidacaoDoComando(), Times.Once);
            _transportadorAdicionarCmd.VerifyNoOtherCalls();
        }

        #endregion

        #region PUT

        [Test]
        public void Transportador_Controller_Put_ShouldBeOk()
        {
            // Arrange
            bool isUpdated = true;
            _transportadorServicoMock.Setup(c => c.Atualizar(_transportadorAtualizarCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _transportadorsControlador.Atualizar(_transportadorAtualizarCmd.Object);
            // Assert
            OkNegotiatedContentResult<bool> httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _transportadorServicoMock.Verify(s => s.Atualizar(_transportadorAtualizarCmd.Object), Times.Once);
        }

        [Test]
        public void Transportador_Controller_Put_ShouldHandleNotFoundexception()
        {
            // Arrange
            _transportadorServicoMock.Setup(c => c.Atualizar(_transportadorAtualizarCmd.Object)).Throws<ExcecaoNaoEncontrado>();
            // Action
            IHttpActionResult callback = _transportadorsControlador.Atualizar(_transportadorAtualizarCmd.Object);
            // Assert
            NegotiatedContentResult<ExceptionPayload> httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigosErros.NotFound);
            _transportadorServicoMock.Verify(s => s.Atualizar(_transportadorAtualizarCmd.Object), Times.Once);
        }

        [Test]
        public void Transportador_Controller_Update_ShouldBeHandleValidationErrors()
        {
            //Arrange
            bool isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            IHttpActionResult callback = _transportadorsControlador.Atualizar(_transportadorAtualizarCmd.Object);
            //Assert
            NegotiatedContentResult<IList<ValidationFailure>> httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _transportadorAtualizarCmd.Verify(cmd => cmd.RealizarValidacaoDoComando(), Times.Once);
            _transportadorAtualizarCmd.VerifyNoOtherCalls();
        }
        #endregion

        #region DELETE

        [Test]
        public void Transportador_Controller_Delete_ShouldBeOk()
        {
            // Arrange
            bool isUpdated = true;
            _transportadorServicoMock.Setup(c => c.Excluir(_transportadorRemoverCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _transportadorsControlador.Excluir(_transportadorRemoverCmd.Object);
            // Assert
            OkNegotiatedContentResult<bool> httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _transportadorServicoMock.Verify(s => s.Excluir(_transportadorRemoverCmd.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        [Test]
        public void Transportador_Controller_Delete_ShouldBeHandleValidationErrors()
        {
            //Arrange
            bool isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            IHttpActionResult callback = _transportadorsControlador.Excluir(_transportadorRemoverCmd.Object);
            //Assert
            NegotiatedContentResult<IList<ValidationFailure>> httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _transportadorRemoverCmd.Verify(cmd => cmd.RealizarValidacaoDoComando(), Times.Once);
            _transportadorRemoverCmd.VerifyNoOtherCalls();
        }

        #endregion
    }
}
