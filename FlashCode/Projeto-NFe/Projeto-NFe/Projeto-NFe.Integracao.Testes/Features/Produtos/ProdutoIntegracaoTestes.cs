using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Aplicacao.Features.Produtos;
using Projeto_NFe.Comuns.Testes.Features.Base;
using Projeto_NFe.Comuns.Testes.Features.Produtos;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Produtos;
using Projeto_NFe.Dominio.Features.Produtos.Excecoes;
using Projeto_NFe.Infra.Data.Features.Produtos;
using System;
using System.Linq;

namespace Projeto_NFe.Integracao.Testes.Features.Produtos
{
    [TestFixture]
    class ProdutoIntegracaoTestes
    {
        private IProdutoRepositorio _produtoRepositorio;
        private IProdutoServico _produtoServico;
        private Produto _produto;

        [SetUp]
        public void SetUp()
        {
            _produto = new Produto();
            _produtoRepositorio = new ProdutoRepositorioSql();
            _produtoServico = new ProdutoServico(_produtoRepositorio);
            BaseSqlTeste.SemearBancoParaProduto();
        }

        [Test]
        public void Produto_Integracao_Inserir_EsperadoOK()
        {
            _produto = ProdutoObjetoMae.ObterValido();

            _produto = _produtoServico.Inserir(_produto);

            var inserido = _produtoServico.ObterPorId(_produto.ID);

            inserido.ID.Should().Be(_produto.ID);
        }

        [Test]
        public void Produto_Integracao_Inserir_CodigoNulo_EsperadoFalha()
        {
            _produto.CodigoProduto = String.Empty;

            Action action = () => _produtoServico.Inserir(_produto);

            action.Should().Throw<ExcecaoCodigoProdutoInvalido>();
        }

        [Test]
        public void Produto_Integracao_Inserir_DescricaoNula_EsperadoFalha()
        {
            _produto = ProdutoObjetoMae.ObterValido();
            _produto.Descricao = String.Empty;

            Action action = () => _produtoServico.Inserir(_produto);

            action.Should().Throw<ExcecaoDescricaoInvalida>();
        }

        [Test]
        public void Produto_Integracao_Inserir_ValorUnitarioInvalido_EsperadoFalha()
        {
            _produto = ProdutoObjetoMae.ObterValido();
            _produto.ValorUnitario = 0;

            Action action = () => _produtoServico.Inserir(_produto);

            action.Should().Throw<ExcecaoValorUnitarioInvalido>();
        }

        [Test]
        public void Produto_Integracao_ObterPorId_EsperadoOK()
        {
            _produto.ID = 1;

            var produto = _produtoServico.ObterPorId(_produto.ID);

            produto.ID.Should().Be(_produto.ID);
        }

        [Test]
        public void Produto_Integracao_ObterPorId_IdInvalido_EsperadoFalha()
        {
            _produto = ProdutoObjetoMae.ObterValidoComIdZero();

            Action action = () => _produtoServico.ObterPorId(_produto.ID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Produto_Integracao_ObterTodos_EsperadoOk()
        {
            var id = 1;
            var produtos = _produtoServico.ObterTodos();

            produtos.Should().NotBeNull();
            produtos.First().ID.Should().Be(id);
        }

        [Test]
        public void Produto_Integracao_Deletar_EsperadoOk()
        {
            _produto = ProdutoObjetoMae.ObterValido();

            _produto = _produtoServico.Inserir(_produto);
            var resultado = _produtoServico.Deletar(_produto.ID);
            var produtoDeletado = _produtoServico.ObterPorId(_produto.ID);

            produtoDeletado.Should().BeNull();
            resultado.Should().BeTrue();
        }

        [Test]
        public void Produto_Integracao_Deletar_EsperadoFalha()
        {
            _produto.ID = 0;

            Action action = () => _produtoServico.Deletar(_produto.ID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Produto_Integracao_Deletar_EsperadoFalso()
        {
            _produto.ID = 12345;

            var resultado  = _produtoServico.Deletar(_produto.ID);

            resultado.Should().BeFalse();
        }

        [Test]
        public void Produto_Integracao_Atualizar_EsperadoOK()
        {
            _produto = ProdutoObjetoMae.ObterValido();

            _produto = _produtoServico.Atualizar(_produto);

            var inserido = _produtoServico.ObterPorId(_produto.ID);

            inserido.ID.Should().Be(_produto.ID);
        }

        [Test]
        public void Produto_Integracao_Atualizar_CodigoNulo_EsperadoFalha()
        {
            _produto = ProdutoObjetoMae.ObterValido();
            _produto.CodigoProduto = String.Empty;

            Action action = () => _produtoServico.Atualizar(_produto);

            action.Should().Throw<ExcecaoCodigoProdutoInvalido>();
        }

        [Test]
        public void Produto_Integracao_Atualizar_DescricaoNula_EsperadoFalha()
        {
            _produto = ProdutoObjetoMae.ObterValido();
            _produto.Descricao = String.Empty;

            Action action = () => _produtoServico.Atualizar(_produto);

            action.Should().Throw<ExcecaoDescricaoInvalida>();
        }

        [Test]
        public void Produto_Integracao_Atualizar_ValorUnitarioInvalido_EsperadoFalha()
        {
            _produto = ProdutoObjetoMae.ObterValido();
            _produto.ValorUnitario = 0;

            Action action = () => _produtoServico.Atualizar(_produto);

            action.Should().Throw<ExcecaoValorUnitarioInvalido>();
        }
    }
}
