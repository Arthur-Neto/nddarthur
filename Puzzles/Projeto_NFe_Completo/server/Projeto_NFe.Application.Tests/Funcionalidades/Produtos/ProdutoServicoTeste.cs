using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Produtos;
using Projeto_NFe.Application.Funcionalidades.Produtos.Comandos;
using Projeto_NFe.Application.Mapeador;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Tests.Funcionalidades.Produtos
{
    [TestFixture]
    public class ProdutoServicoTeste
    {

        Mock<IProdutoRepositorio> _mockRepositorioProduto;
        Mock<Produto> _mockProduto;
        IProdutoServico _produtoServico;
        [SetUp]
        public void Inicializar()
        {
            InicializadorAutoMapper.Resetar();
            InicializadorAutoMapper.Inicializar();
            _mockRepositorioProduto = new Mock<IProdutoRepositorio>();
            _mockProduto = new Mock<Produto>();
            _produtoServico = new ProdutoServico(_mockRepositorioProduto.Object);
        }

        [Test]
        public void Produto_Aplicacao_Adicionar_Sucesso()
        {
            long idProduto = 1;
            Mock<ProdutoAdicionarComando> _mockProdutoAdicionarComando = new Mock<ProdutoAdicionarComando>();
            _mockRepositorioProduto.Setup(mrp => mrp.Adicionar(It.IsAny<Produto>())).Returns(idProduto);

            long idProdutoAdicionado =_produtoServico.Adicionar(_mockProdutoAdicionarComando.Object);

            idProdutoAdicionado.Should().Be(idProduto);
            _mockRepositorioProduto.Verify(mrp => mrp.Adicionar(It.IsAny<Produto>()));
            _mockRepositorioProduto.VerifyNoOtherCalls();
        }

        [Test]
        public void Produto_Aplicacao_Atualizar_Sucesso()
        {
            bool retornoAtualizacao = true;
            Mock<ProdutoEditarComando> _mockProdutoAtualizarComando = new Mock<ProdutoEditarComando>();
            _mockRepositorioProduto.Setup(mrp => mrp.BuscarPorId(_mockProdutoAtualizarComando.Object.Id)).Returns(_mockProduto.Object);
            _mockRepositorioProduto.Setup(mrp => mrp.Atualizar(_mockProduto.Object)).Returns(retornoAtualizacao);

           bool resultadoAtualizar = _produtoServico.Atualizar(_mockProdutoAtualizarComando.Object);

            resultadoAtualizar.Should().Be(retornoAtualizacao);
            _mockRepositorioProduto.Verify(mrp => mrp.BuscarPorId(_mockProdutoAtualizarComando.Object.Id), Times.Once);
            _mockRepositorioProduto.Verify(mrp => mrp.Atualizar(_mockProduto.Object), Times.Once);
            _mockRepositorioProduto.VerifyNoOtherCalls();
        }

        [Test]
        public void Produto_Aplicacao_Atualizar_ExcecaoNaoEncontrado_Falha()
        {
            Produto produtoNulo = null;
            Mock<ProdutoEditarComando> _mockProdutoAtualizarComando = new Mock<ProdutoEditarComando>();
            _mockRepositorioProduto.Setup(mrp => mrp.BuscarPorId(_mockProdutoAtualizarComando.Object.Id)).Returns(produtoNulo);

            Action acaoQueDeveRetornarExcecaoNaoEncontrado = () => _produtoServico.Atualizar(_mockProdutoAtualizarComando.Object);

            acaoQueDeveRetornarExcecaoNaoEncontrado.Should().Throw<ExcecaoNaoEncontrado>();

            _mockRepositorioProduto.Verify(mrp => mrp.BuscarPorId(_mockProdutoAtualizarComando.Object.Id));
            _mockRepositorioProduto.VerifyNoOtherCalls();
        }

        [Test]
        public void Produto_Aplicacao_BuscarPorId_Sucesso()
        {
            long idValido = 1;

            _mockRepositorioProduto.Setup(mrp => mrp.BuscarPorId(idValido)).Returns(_mockProduto.Object);

            Produto produtoEncontrado = _produtoServico.BuscarPorId(idValido);

            produtoEncontrado.Should().NotBeNull();
            _mockRepositorioProduto.Verify(mrp => mrp.BuscarPorId(idValido));
            _mockRepositorioProduto.VerifyNoOtherCalls();
        }

        [Test]
        public void Produto_Aplicacao_BuscarPorId_ExcecaoIdentificadorIndefinido_Falha()
        {
            long idInvalido = 0;
            Produto produtoNulo = null;
            _mockRepositorioProduto.Setup(mrp => mrp.BuscarPorId(idInvalido)).Returns(produtoNulo);

            Action acaoQueDeveRetornarExcecaoNaoEncontrado = () => _produtoServico.BuscarPorId(idInvalido);

            acaoQueDeveRetornarExcecaoNaoEncontrado.Should().Throw<ExcecaoNaoEncontrado>();

            _mockRepositorioProduto.Verify(mrp => mrp.BuscarPorId(idInvalido));
            _mockRepositorioProduto.VerifyNoOtherCalls();
        }

        [Test]
        public void Produto_Aplicacao_BuscarTodos_Sucesso()
        {
            List<Produto> produtos = new List<Produto>()
            {
                _mockProduto.Object
            };
            _mockRepositorioProduto.Setup(mrp => mrp.BuscarTodos()).Returns(produtos.AsQueryable());

            IQueryable<Produto> produtosEncontrados = _produtoServico.BuscarTodos();

            produtosEncontrados.Should().NotBeNullOrEmpty();
            _mockRepositorioProduto.Verify(mrp => mrp.BuscarTodos());
            _mockRepositorioProduto.VerifyNoOtherCalls();
        }

        [Test]
        public void Produto_Aplicacao_Excluir_Sucesso()
        {
            long idValido = 1;
            bool resultadoRemocao = true;
            Produto produtoNulo = null;
            Mock<ProdutoRemoverComando> _mockProdutoRemoverComando = new Mock<ProdutoRemoverComando>();
            _mockProdutoRemoverComando.Setup(mrc => mrc.Id).Returns(idValido);
            _mockRepositorioProduto.SetupSequence(mrp => mrp.BuscarPorId(It.IsAny<long>()))
                .Returns(_mockProduto.Object)
                .Returns(produtoNulo);
            _mockRepositorioProduto.Setup(mrp => mrp.Excluir(_mockProduto.Object)).Returns(resultadoRemocao);

            bool resultadoExclusao =_produtoServico.Excluir(_mockProdutoRemoverComando.Object);

            resultadoExclusao.Should().Be(resultadoRemocao);
            _mockRepositorioProduto.Verify(mrp => mrp.BuscarPorId(It.IsAny<long>()));
            _mockRepositorioProduto.Verify(mrp => mrp.Excluir(_mockProduto.Object));
            _mockRepositorioProduto.VerifyNoOtherCalls();
        }


        [Test]
        public void Produto_Aplicacao_Excluir_RetornarFalso()
        {
            long idValido = 1;
            bool resultadoRemocao = false;
            Mock<ProdutoRemoverComando> _mockProdutoRemoverComando = new Mock<ProdutoRemoverComando>();
            _mockProdutoRemoverComando.Setup(mrc => mrc.Id).Returns(idValido);
            _mockRepositorioProduto.Setup(mrp => mrp.BuscarPorId(It.IsAny<long>())).Returns(_mockProduto.Object);
            _mockRepositorioProduto.Setup(mrp => mrp.Excluir(_mockProduto.Object)).Returns(resultadoRemocao);

            bool resultadoExclusao = _produtoServico.Excluir(_mockProdutoRemoverComando.Object);

            resultadoExclusao.Should().Be(resultadoRemocao);
            _mockRepositorioProduto.Verify(mrp => mrp.BuscarPorId(It.IsAny<long>()));
            _mockRepositorioProduto.Verify(mrp => mrp.Excluir(_mockProduto.Object));
            _mockRepositorioProduto.VerifyNoOtherCalls();
        }

        [Test]
        public void Produto_Aplicacao_Excluir_ExcecaoIdentificadorIndefinido_Falha()
        {
            long idInvalido = 0;
            Produto produtoNulo = null;
            Mock<ProdutoRemoverComando> _mockProdutoRemoverComando = new Mock<ProdutoRemoverComando>();
            _mockProdutoRemoverComando.Setup(mrc => mrc.Id).Returns(idInvalido);
            _mockRepositorioProduto.Setup(mrp => mrp.BuscarPorId(_mockProdutoRemoverComando.Object.Id)).Returns(produtoNulo);

            Action acaoQueDeveRetornarExcecaoNaoEncontrado = () => _produtoServico.Excluir(_mockProdutoRemoverComando.Object);

            acaoQueDeveRetornarExcecaoNaoEncontrado.Should().Throw<ExcecaoNaoEncontrado>();

            _mockRepositorioProduto.Verify(mrp => mrp.BuscarPorId(_mockProdutoRemoverComando.Object.Id));
            _mockRepositorioProduto.VerifyNoOtherCalls();
        }


    }

}
