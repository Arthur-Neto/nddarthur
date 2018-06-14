using FluentAssertions;
using NFe.Aplicacao.Features.Produtos;
using NFe.Common.Testes.Base;
using NFe.Common.Testes.Features;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Produtos;
using NFe.Infra.Data.Features.Produtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFe.Intregacao.Sistema.Testes.Features.Produtos
{
    [TestFixture]
    public class ProdutoIntegracaoSistemaTeste
    {
        ProdutoServico produtoServico;
        IProdutoRepositorio repositorio;

        [SetUp]
        public void InitializeObjects()
        {
            repositorio = new ProdutoRepositorio();

            produtoServico = new ProdutoServico(repositorio);

            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void Produto_IntegracaoSistema_Salvar_DeveFuncionar()
        {
            Produto produto = ObjectMother.ObtemProdutoValido();
            produto.Id = 0;

            Produto result = produtoServico.Salvar(produto);

            result.Id.Should().BeGreaterThan(0);
            IList<Produto> ProdutoList = produtoServico.PegarTodos().ToList();
            ProdutoList.Contains(result).Should().BeTrue();
            ProdutoList.Last().CodigoProduto.Should().Be(12345);
        }

        [Test]
        public void Produto_IntegracaoSistema_BuscaTodos_DeveFuncionar()
        {
            Produto produto = ObjectMother.ObtemProdutoValido();
            produto.Id = 0;

            Produto result = produtoServico.Salvar(produto);

            result.Id.Should().BeGreaterThan(0);

            IList<Produto> ProdutoList = produtoServico.PegarTodos().ToList();
            ProdutoList.Contains(result).Should().BeTrue();
            ProdutoList.Count.Should().Be(2);
        }

        [Test]
        public void Produto_IntegracaoSistema_BuscaPorId_DeveFuncionar()
        {
            Produto produto = ObjectMother.ObtemProdutoValido();
            produto.Id = 0;

            produto = produtoServico.Salvar(produto);

            Produto resultadoBuscaBanco = produtoServico.PegarPorId(produto.Id);

            produto.Should().NotBeNull();
            resultadoBuscaBanco.Id.Should().Be(2);
        }

        [Test]
        public void Produto_IntegracaoSistema_Deletar_DeveFuncionar()
        {
            Produto produto = ObjectMother.ObtemProdutoValido();
            produto.Id = 0;

            produto = produtoServico.Salvar(produto);

            produtoServico.Deletar(produto);

            Produto result = produtoServico.PegarPorId(produto.Id);

            result.Should().BeNull();
        }

        [Test]
        public void Produto_IntegracaoSistema_Atualizar_DeveFuncionar()
        {
            Produto produto = ObjectMother.ObtemProdutoValido();
            produto.Id = 0;

            produto = produtoServico.Salvar(produto);

            produto.CodigoProduto = 111;

            Produto result = produtoServico.Atualizar(produto);

            result.CodigoProduto.Should().Be(111);
        }

        [Test]
        public void Produto_IntegracaoSistema_Atualizar_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Produto produto = ObjectMother.ObtemProdutoValido();
            produto.Id = 0;

            Action act = () => { produtoServico.Atualizar(produto); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Produto_IntegracaoSistema_BuscaPorIdProduto_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Produto produto = ObjectMother.ObtemProdutoQuantidadeIgualAZero();

            produto.Id = 0;

            Action act = () => { produtoServico.PegarPorId(produto.Id); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Produto_IntegracaoSistema_Deletar_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Produto produto = ObjectMother.ObtemProdutoValorUnitarioZerado();

            produto.Id = 0;

            Action act = () => { produtoServico.Deletar(produto); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Produto_IntegracaoSistema_Salvar_DeveJogarExcecaoDescricaoVazio()
        {
            Produto produto = ObjectMother.ObtemProdutoDescricaoVazio();

            Action act = () => { produtoServico.Salvar(produto); };

            act.Should().Throw<ProdutoEmptyDescricaoException>();
        }

        [Test]
        public void Produto_IntegracaoSistema_Salvar_DeveJogarExcecaoQuantidadeMenorQueZero()
        {
            Produto produto = ObjectMother.ObtemProdutoQuantidadeIgualAZero();

            Action act = () => { produtoServico.Salvar(produto); };

            act.Should().Throw<ProdutoQuantidadeException>();
        }

        [Test]
        public void Produto_IntegracaoSistema_Salvar_DeveJogarExcecaoValorUnitarioNegativo()
        {
            Produto produto = ObjectMother.ObtemProdutoValorUnitarioZerado();

            Action act = () => { produtoServico.Salvar(produto); };

            act.Should().Throw<ProdutoValorUnitarioException>();
        }
    }
}
