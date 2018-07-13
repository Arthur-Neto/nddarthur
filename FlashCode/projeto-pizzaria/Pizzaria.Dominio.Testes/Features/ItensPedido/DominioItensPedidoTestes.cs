using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Testes.Features;
using Pizzaria.Dominio.Features.ItensPedidos;
using Pizzaria.Dominio.Features.ItensPedidos.Excecoes;
using Pizzaria.Dominio.Features.Pedidos;
using Pizzaria.Dominio.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizzaria.Dominio.Testes.Features.ItensPedido
{
    [TestFixture]
    public class DominioItensPedidoTestes
    {
        ItemPedido _itemPedido;
        Pedido _pedido;
        Produto _produto;

        [SetUp]
        public void SetUp()
        {
            _pedido = ObjetoMae.ObterPedidoValido();
            _itemPedido = ObjetoMae.ObterItemComUmaPizza(_pedido);
            _produto = ObjetoMae.ObterPizza(TamanhoEnum.GRANDE);
        }

        [Test]
        public void ItemPedido_Dominio_Adicionar_Deve_Adicionar()
        {
            //cenario
            var novoItemPedido = new ItemPedido();

            //ação
            novoItemPedido.Adicionar(_produto);

            //verificação
            novoItemPedido.Produtos.Count.Should().Be(1);
        }

        [Test]
        public void ItemPedido_Dominio_Calcular_ValorParcial_Deve_Calcular()
        {
            //cenario
            var novoItemPedido = new ItemPedido();

            _produto.Valor = 10;

            novoItemPedido.Adicionar(_produto);
            
            //ação
            novoItemPedido.CalcularValorParcial();

            //verificação
            novoItemPedido.ValorParcial.Should().Be(_produto.Valor);
        }

        [Test]
        public void ItemPedido_Dominio_Criar_ItemPedido_Deve_Lancar_Excecao_PedidoNulo()
        {
            //cenario
            _itemPedido.Pedido = null;
            _itemPedido.CalcularValorParcial();

            //ação
            Action action = () => _itemPedido.Validar();

            //verificação
            action.Should().Throw<PedidoNuloExcecao>();
        }

        [Test]
        public void ItemPedido_Dominio_Criar_ItemPedido_Deve_Lancar_Excecao_ValorParcialInvalido()
        {
            //cenario
            _itemPedido.ValorParcial = 0;

            //ação
            Action action = () => _itemPedido.Validar();

            //verificação
            action.Should().Throw<ValorParcialInvalidoExcecao>();
        }

        [Test]
        public void ItemPedido_Dominio_Criar_ItemPedido_Deve_Lancar_Excecao_ListaProdutosVazia()
        {
            //cenario
            _itemPedido.Produtos = new List<Produto>();

            //ação
            Action action = () => _itemPedido.Validar();

            //verificação
            action.Should().Throw<ListaProdutosVaziaExcecao>();
        }

        [Test]
        public void ItemPedido_Dominio_Criar_ItemPedido_Nao_Deve_Lancar_Excecao()
        {
            //cenario
            _itemPedido.CalcularValorParcial();

            //ação
            Action action = () => _itemPedido.Validar();

            //verificação
            action.Should().NotThrow();
        }
    }
}
