using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Testes.Features;
using Pizzaria.Dominio.Features.Produtos;
using Pizzaria.Dominio.Features.Produtos.Excecoes;
using System;

namespace Pizzaria.Dominio.Testes.Features.Produtos
{
    [TestFixture]
    public class DominioProdutoTestes
    {
        Produto _produto;

        [SetUp]
        public void SetUp()
        {
            _produto = ObjetoMae.ObterCalzone(TamanhoEnum.MEDIA);
        }

        [Test]
        public void Produto_Dominio_Validar_Deve_Nao_Lancar_Excecao()
        {
            //Cenário

            //acao
            Action action = () => _produto.Validar();

            //verificar
            action.Should().NotThrow();
        }

        [Test]
        public void Produto_Dominio_Validar_Deve_Lancar_ExcecaoSaborInvalido()
        {
            //Cenário
            _produto.Sabor = string.Empty;

            //acao
            Action action = () => _produto.Validar();

            //verificar
            action.Should().Throw<SaborInvalidoExcecao>();
        }

        [Test]
        public void Produto_Dominio_Validar_Deve_Lancar_ExcecaoValorInvalido()
        {
            //Cenário
            _produto.Valor = 0;

            //acao
            Action action = () => _produto.Validar();

            //verificar
            action.Should().Throw<ValorInvalidoExcecao>();
        }

        [Test]
        public void Produto_Dominio_Validar_Deve_Lancar_ExcecaoTamanhoInvalido()
        {
            //Cenário
            _produto.Tamanho = 0;

            //acao
            Action action = () => _produto.Validar();

            //verificar
            action.Should().Throw<TamanhoInvalidoExcecao>();
        }
    }
}
