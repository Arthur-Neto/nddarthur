using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Aplicacao.Features.Produtos;
using Projeto_NFe.Comuns.Testes.Features.Produtos;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Produtos;
using Projeto_NFe.Dominio.Features.Produtos.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Aplicacao.Testes.Features.Produtos
{
    [TestFixture]
    public class ProdutoAplicacaoTestes
    {
        private IProdutoServico _produtoServico;
        private Mock<IProdutoRepositorio> _mockRepositorio;
        Produto _produto;

        [SetUp]
        public void SetUp()
        {
            _produto = new Produto();
            _mockRepositorio = new Mock<IProdutoRepositorio>();
            _produtoServico = new ProdutoServico(_mockRepositorio.Object);
        }
        [Test]
        public void Produto_Aplicacao_Inserir_EsperadoOK()
        {
            //cenario
            _produto = ProdutoObjetoMae.ObterValido();
            _mockRepositorio
                .Setup(er => er.Inserir(_produto))
                .Returns(new Produto { ID = 1 });

            //acao
            var novoProduto = _produtoServico.Inserir(_produto);


            //verificação
            _mockRepositorio.Verify(er => er.Inserir(_produto));
            novoProduto.ID.Should().BeGreaterThan(0);
        }
        [Test]
        public void Produto_Aplicacao_Atualizar_EsperadoOK()
        {
            //cenario
            _produto = ProdutoObjetoMae.ObterValido();
            _produto.ValorUnitario = 6;
            _mockRepositorio
                .Setup(er => er.Atualizar(_produto))
                .Returns(_produto);

            //acao
            var novoProduto = _produtoServico.Atualizar(_produto);

            //verificar
            _mockRepositorio.Verify(er => er.Atualizar(_produto));
            novoProduto.ValorUnitario.Should().Be(_produto.ValorUnitario);
        }

        [Test]
        public void Produto_Aplicacao_Obter_EsperadoOK()
        {
            //cenario
            int id = 1;
            _mockRepositorio
                .Setup(er => er.ObterPorId(id))
                .Returns(new Produto { ID = id });

            //acao
            _produto = _produtoServico.ObterPorId(id);

            //verificar
            _mockRepositorio.Verify(er => er.ObterPorId(id));
            _produto.ID.Should().BeGreaterThan(0);
        }
        [Test]
        public void Produto_Aplicacao_ObterTodos_EsperadoOK()
        {
            //cenario
            _mockRepositorio
                .Setup(er => er.ObterTodos())
                .Returns(new List<Produto> { new Produto { ID = 1 }, new Produto { ID = 2 } });

            //acao
            IList<Produto> produtos = _produtoServico.ObterTodos();


            //verificar
            _mockRepositorio.Verify(er => er.ObterTodos());
            produtos.Count.Should().Be(2);
            produtos.First().ID.Should().Be(1);
        }
        [Test]
        public void Produto_Aplicacao_ObterTodos_ComId_EsperadoOK()
        {
            //cenario
            _mockRepositorio
                .Setup(er => er.ObterTodos())
                .Returns(new List<Produto> { new Produto { ID = 1 } });

            //acao
            IList<Produto> produtos = _produtoServico.ObterTodos();


            //verificar
            _mockRepositorio.Verify(er => er.ObterTodos());
            produtos.Should().NotBeEmpty();
            produtos.Count.Should().Be(1);
            produtos.First().ID.Should().Be(1);
        }
        [Test]
        public void Produto_Aplicacao_Deletar_EsperadoOK()
        {
            //cenario
            _produto = ProdutoObjetoMae.ObterValido();
            _mockRepositorio
                .Setup(er => er.Deletar(_produto.ID))
                .Returns(true);

            //acao
            var resultado = _produtoServico.Deletar(_produto.ID);

            //cenario
            _mockRepositorio.Verify(er => er.Deletar(_produto.ID));
            resultado.Should().BeTrue();
        }
        [Test]
        public void Produto_Aplicacao_Deletar_EsperadoFalso()
        {
            //cenario
            _produto = ProdutoObjetoMae.ObterValido();
            _produto.ID = 12;
            _mockRepositorio
                .Setup(er => er.Deletar(_produto.ID))
                .Returns(false);

            //acao
            var resultado = _produtoServico.Deletar(_produto.ID);

            //cenario
            _mockRepositorio.Verify(er => er.Deletar(_produto.ID));
            resultado.Should().BeFalse();
        }
        [Test]
        public void Produto_Aplicacao_Deletar_EsperadoFalha()
        {
            //cenario
            _produto = ProdutoObjetoMae.ObterValido();
            _produto.ID = 0;
            _mockRepositorio
                .Setup(er => er.Deletar(_produto.ID))
                .Returns(false);

            //acao
            Action action = () => _produtoServico.Deletar(_produto.ID);

            //cenario
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
            _mockRepositorio.VerifyNoOtherCalls();
        }
        [Test]
        public void Produto_Aplicacao_Atualizar_EsperadoFalha()
        {
            //cenario
            _produto = ProdutoObjetoMae.ObterValidoComIdZero();

            //acao
            Action action = () => _produtoServico.Atualizar(_produto);

            //verificar
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
            _mockRepositorio.VerifyNoOtherCalls();
        }
        [Test]
        public void Produto_Aplicacao_ObterPorId_EsperadoFalha()
        {
            //cenario
            _produto = ProdutoObjetoMae.ObterValidoComIdZero();

            //acao
            Action action = () => _produtoServico.ObterPorId(_produto.ID);

            //verificar
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Produto_Aplicacao_Inserir_Validar_CodigoProduto_EsperadoFalha()
        {
            //cenário
            _produto = ProdutoObjetoMae.ObterCodigoProdutoInvalido();

            //Ação
            Action action = () => _produtoServico.Inserir(_produto);

            //Verificação
            action.Should().Throw<ExcecaoCodigoProdutoInvalido>();
        }
        [Test]
        public void Produto_Aplicacao_Inserir_Validar_Descricao_EsperadoFalha()
        {
            //cenário
            _produto = ProdutoObjetoMae.ObterDescricaoInvalida();

            //Ação
            Action action = () => _produtoServico.Inserir(_produto);

            //Verificação
            action.Should().Throw<ExcecaoDescricaoInvalida>();
        }
        [Test]
        public void Produto_Aplicacao_Inserir_Validar_ValorUnitario_EsperadoFalha()
        {
            //cenário
            _produto = ProdutoObjetoMae.ObterValorUnitarioInvalido();

            //Ação
            Action action = () => _produtoServico.Inserir(_produto);

            //Verificação
            action.Should().Throw<ExcecaoValorUnitarioInvalido>();
        }

        [Test]
        public void Produto_Aplicacao_Atualizar_Validar_CodigoProduto_EsperadoFalha()
        {
            //cenário
            _produto = ProdutoObjetoMae.ObterCodigoProdutoInvalido();

            //Ação
            Action action = () => _produtoServico.Atualizar(_produto);

            //Verificação
            action.Should().Throw<ExcecaoCodigoProdutoInvalido>();
        }
        [Test]
        public void Produto_Aplicacao_Atualizar_Validar_Descricao_EsperadoFalha()
        {
            //cenário
            _produto = ProdutoObjetoMae.ObterDescricaoInvalida();

            //Ação
            Action action = () => _produtoServico.Atualizar(_produto);

            //Verificação
            action.Should().Throw<ExcecaoDescricaoInvalida>();
        }
        [Test]
        public void Produto_Aplicacao_Atualizar_Validar_ValorUnitario_EsperadoFalha()
        {
            //cenário
            _produto = ProdutoObjetoMae.ObterValorUnitarioInvalido();

            //Ação
            Action action = () => _produtoServico.Atualizar(_produto);

            //Verificação
            action.Should().Throw<ExcecaoValorUnitarioInvalido>();
        }
    }
}
