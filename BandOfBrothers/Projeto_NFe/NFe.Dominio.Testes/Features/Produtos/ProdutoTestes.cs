using FluentAssertions;
using NFe.Common.Testes.Features;
using NFe.Dominio.Features.Produtos;
using NUnit.Framework;
using System;

namespace NFe.Dominio.Testes.Features.Produtos
{
    [TestFixture]
    public class ProdutoTestes
    {
        Produto produto;

        [SetUp]
        public void SetUp()
        {
            produto = new Produto();
        }

        [Test]
        public void Produto_Dominio_Validar_ValidarProdutoOK()
        {
            produto = ObjectMother.ObtemProdutoValido();

            Action action = () => produto.Validar();

            action.Should().NotThrow();
        }

        [Test]
        public void Produto_Dominio_Validar_DeveRetornarExcessaoCodigoProdutoMenorZero()
        {
            produto = ObjectMother.ObtemCodigoProdutoIgualAZero();

            Action action = () => produto.Validar();

            action.Should().Throw<ProdutoCodigoProdutoException>();
        }

        [Test]
        public void Produto_Dominio_Validar_DeveRetornarExcessaoDescricaoVazio()
        {
            produto = ObjectMother.ObtemProdutoDescricaoVazio();

            Action action = () => produto.Validar();

            action.Should().Throw<ProdutoEmptyDescricaoException>();
        }

        [Test]
        public void Produto_Dominio_Validar_DeveRetornarExcessaoQuantidadeMenorZero()
        {
            produto = ObjectMother.ObtemProdutoQuantidadeIgualAZero();

            Action action = () => produto.Validar();

            action.Should().Throw<ProdutoQuantidadeException>();
        }

        [Test]
        public void Produto_Dominio_Validar_DeveRetornarExcessaoValorUnitarioZerado()
        {
            produto = ObjectMother.ObtemProdutoValorUnitarioZerado();

            Action action = () => produto.Validar();

            action.Should().Throw<ProdutoValorUnitarioException>();
        }

        [Test]
        public void Produto_Dominio_DeveCalcularValorTotal()
        {
            produto = ObjectMother.ObtemProdutoValido();
            var valorEsperado = 30.0m;
            produto.Quantidade = 2;

            produto.CalcularValorTotal();

            produto.ValorProduto.Total.Should().Be(valorEsperado);
        }
    }
}
