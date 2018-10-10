using AutoMapper;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Moq;
using NUnit.Framework;
using Projeto_NFe.API.Controladores.Produtos;
using Projeto_NFe.API.Excecoes;
using Projeto_NFe.Application.Funcionalidades.Produtos;
using Projeto_NFe.Application.Funcionalidades.Produtos.Comandos;
using Projeto_NFe.Application.Funcionalidades.Produtos.Modelos;
using Projeto_NFe.Application.Mapeador;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Controller.Tests.Initializer;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Projeto_NFe.Controller.Tests.Features.Produtos
{
    [TestFixture]
    public class ProdutoControladorTests : TestControllerBase
    {
        private ProdutoController _produtosControlador;
        private Mock<IProdutoServico> _produtoServicoMock;
        private Mock<Produto> _produto;
        private Mock<ProdutoAdicionarComando> _produtoAdicionarCmd;
        private Mock<ProdutoEditarComando> _produtoAtualizarCmd;
        private Mock<ProdutoRemoverComando> _produtoRemoverCmd;
        private Mock<ValidationResult> _validador;

        [SetUp]
        public void Initialize()
        {
            InicializadorAutoMapper.Resetar();
            InicializadorAutoMapper.Inicializar();
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _produtoServicoMock = new Mock<IProdutoServico>();
            _produtosControlador = new ProdutoController(_produtoServicoMock.Object)
            {
                Request = request,
            };
            _produto = new Mock<Produto>();
            _validador = new Mock<ValidationResult>();
            _produtoAdicionarCmd = new Mock<ProdutoAdicionarComando>();
            _produtoAdicionarCmd.Setup(cmd => cmd.RealizarValidacaoDoComando()).Returns(_validador.Object);
            _produtoAtualizarCmd = new Mock<ProdutoEditarComando>();
            _produtoAtualizarCmd.Setup(cmd => cmd.RealizarValidacaoDoComando()).Returns(_validador.Object);
            _produtoRemoverCmd = new Mock<ProdutoRemoverComando>();
            _produtoRemoverCmd.Setup(cmd => cmd.RealizarValidacaoDoComando()).Returns(_validador.Object);
            var isValid = true;
            _validador.Setup(v => v.IsValid).Returns(isValid);
        }

        #region GET

        [Test]
        public void Produtos_Controller_Get_ShouldOk()
        {
            // Arrange
            var produto = ObjectMother.ObterProdutoValido();
            var response = new List<Produto>() { produto }.AsQueryable();
            _produtoServicoMock.Setup(s => s.BuscarTodos()).Returns(response);
            var odataOptions = GetOdataQueryOptions<Produto>(_produtosControlador);
            // Action
            var callback = _produtosControlador.BuscarTodos(odataOptions);
            //Assert
            _produtoServicoMock.Verify(s => s.BuscarTodos(), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<PageResult<ProdutoModelo>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void Produtos_Controller_GetById_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _produtoServicoMock.Setup(c => c.BuscarPorId(id)).Returns(_produto.Object);
            // Action
            IHttpActionResult callback = _produtosControlador.BuscarPorId(id);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<Produto>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _produtoServicoMock.Verify(s => s.BuscarPorId(id), Times.Once);
        }

        #endregion

        #region POST

        [Test]
        public void Produtos_Controller_Post_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _produtoServicoMock.Setup(c => c.Adicionar(_produtoAdicionarCmd.Object)).Returns(id);
            // Action
            IHttpActionResult callback = _produtosControlador.Add(_produtoAdicionarCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(id);
            _produtoServicoMock.Verify(s => s.Adicionar(_produtoAdicionarCmd.Object), Times.Once);
        }

        [Test]
        public void Produtos_Controller_Post_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _produtosControlador.Add(_produtoAdicionarCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _produtoAdicionarCmd.Verify(cmd => cmd.RealizarValidacaoDoComando(), Times.Once);
            _produtoAdicionarCmd.VerifyNoOtherCalls();
        }

        #endregion

        #region PUT

        [Test]
        public void Produtos_Controller_Put_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _produtoServicoMock.Setup(c => c.Atualizar(_produtoAtualizarCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _produtosControlador.Atualizar(_produtoAtualizarCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _produtoServicoMock.Verify(s => s.Atualizar(_produtoAtualizarCmd.Object), Times.Once);
        }

        [Test]
        public void Produtos_Controller_Put_ShouldHandleNotFoundexception()
        {
            // Arrange
            _produtoServicoMock.Setup(c => c.Atualizar(_produtoAtualizarCmd.Object)).Throws<ExcecaoNaoEncontrado>();
            // Action
            IHttpActionResult callback = _produtosControlador.Atualizar(_produtoAtualizarCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.Content.CodigoErro.Should().Be((int)CodigosErros.NotFound);
            _produtoServicoMock.Verify(s => s.Atualizar(_produtoAtualizarCmd.Object), Times.Once);
        }

        [Test]
        public void Produtos_Controller_Update_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _produtosControlador.Atualizar(_produtoAtualizarCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _produtoAtualizarCmd.Verify(cmd => cmd.RealizarValidacaoDoComando(), Times.Once);
            _produtoAtualizarCmd.VerifyNoOtherCalls();
        }
        #endregion

        #region DELETE

        [Test]
        public void Produtos_Controller_Delete_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _produtoServicoMock.Setup(c => c.Excluir(_produtoRemoverCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _produtosControlador.Excluir(_produtoRemoverCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _produtoServicoMock.Verify(s => s.Excluir(_produtoRemoverCmd.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        [Test]
        public void Produtos_Controller_Delete_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _produtosControlador.Excluir(_produtoRemoverCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _produtoRemoverCmd.Verify(cmd => cmd.RealizarValidacaoDoComando(), Times.Once);
            _produtoRemoverCmd.VerifyNoOtherCalls();
        }

        #endregion
    }
}
