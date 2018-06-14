using FluentAssertions;
using Moq;
using NFe.Aplicacao.Features.Produtos;
using NFe.Common.Testes.Features;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Produtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFe.Aplicacao.Testes.Features.Produtos
{
    [TestFixture]
    public class ProdutoAplicacaoTeste
    {
        ProdutoServico produtoServico;
        Mock<IProdutoRepositorio> mockRepositorio;

        [SetUp]
        public void InitializeObjects()
        {
            mockRepositorio = new Mock<IProdutoRepositorio>();

            produtoServico = new ProdutoServico(mockRepositorio.Object);
        }

        [Test]
        public void Produto_Aplicacao_Salvar_DeveFuncionar()
        {
            Produto produto = ObjectMother.ObtemProdutoValido();
            produto.Id = 0;
            mockRepositorio.Setup(m => m.Salvar(produto)).Returns(new Produto { Id = 1 });

            Produto result = produtoServico.Salvar(produto);

            result.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.Salvar(produto));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Produto_Aplicacao_BuscaTodos_DeveFuncionar()
        {
            IList<Produto> ListaProduto = new List<Produto>();
            Produto produto = ObjectMother.ObtemProdutoValido();
            ListaProduto.Add(produto);
            mockRepositorio.Setup(m => m.PegarTodos()).Returns(ListaProduto);

            IList<Produto> Result = produtoServico.PegarTodos().ToList();

            Result.First().Id.Should().Be(1);
            Result.Count().Should().Be(1);
            mockRepositorio.Verify(m => m.PegarTodos());
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Produto_Aplicacao_BuscaPorId_DeveFuncionar()
        {
            Produto produto = ObjectMother.ObtemProdutoValido();
            mockRepositorio.Setup(m => m.PegarPorId(produto.Id)).Returns(produto);

            Produto result = produtoServico.PegarPorId(produto.Id);

            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            mockRepositorio.Verify(m => m.PegarPorId(produto.Id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Produto_Aplicacao_Deletar_DeveFuncionar()
        {
            Produto produto = ObjectMother.ObtemProdutoValido();

            mockRepositorio.Setup(m => m.Deletar(produto));

            produtoServico.Deletar(produto);
            mockRepositorio.Verify(m => m.Deletar(produto));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Produto_Aplicacao_Atualizar_DeveFuncionar()
        {
            var codigoProduto = 111;
            Produto produto = ObjectMother.ObtemProdutoValido();
            produto.CodigoProduto = 111;
            mockRepositorio.Setup(m => m.Atualizar(produto)).Returns(produto);
            mockRepositorio.Setup(m => m.PegarPorId(produto.Id)).Returns(produto);

            Produto result = produtoServico.Atualizar(produto);

            result.CodigoProduto.Should().Be(codigoProduto);
            mockRepositorio.Verify(m => m.Atualizar(produto));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Produto_Aplicacao_Atualizar_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Produto produto = ObjectMother.ObtemProdutoValido();
            produto.Id = 0;

            Action act = () => { produtoServico.Atualizar(produto); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Produto_Aplicacao_BuscaPorId_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Produto produto = ObjectMother.ObtemProdutoValido();

            produto.Id = 0;

            Action act = () => { produtoServico.PegarPorId(produto.Id); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Produto_Aplicacao_Deletar_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Produto produto = ObjectMother.ObtemProdutoValido();

            produto.Id = 0;

            Action act = () => { produtoServico.Deletar(produto); };

            act.Should().Throw<IdentifierUndefinedException>();

        }

        [Test]
        public void Produto_Aplicacao_Salvar_DeveJogarExcecaoCodigoProdutoInvalido()
        {
            Produto produto = ObjectMother.ObtemCodigoProdutoIgualAZero();

            Action act = () => { produtoServico.Salvar(produto); };

            act.Should().Throw<ProdutoCodigoProdutoException>();

        }

        [Test]
        public void Produto_Aplicacao_Salvar_DeveJogarExcecaoDescricaoVazia()
        {
            Produto produto = ObjectMother.ObtemProdutoDescricaoVazio();

            Action act = () => { produtoServico.Salvar(produto); };

            act.Should().Throw<ProdutoEmptyDescricaoException>();

        }

        [Test]
        public void Produto_Aplicacao_Salvar_DeveJogarExcecaoQuantidadeMenorQueZero()
        {
            Produto produto = ObjectMother.ObtemProdutoQuantidadeIgualAZero();

            Action act = () => { produtoServico.Salvar(produto); };

            act.Should().Throw<ProdutoQuantidadeException>();

        }

        [Test]
        public void Produto_Aplicacao_Salvar_DeveJogarExcecaoValorUnitarioNegativo()
        {
            Produto produto = ObjectMother.ObtemProdutoValorUnitarioZerado();

            Action act = () => { produtoServico.Salvar(produto); };

            act.Should().Throw<ProdutoValorUnitarioException>();

        }
    }
}