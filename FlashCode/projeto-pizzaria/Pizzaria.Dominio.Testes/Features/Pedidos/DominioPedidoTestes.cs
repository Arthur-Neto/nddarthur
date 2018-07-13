using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Testes.Features;
using Pizzaria.Dominio.Features.ItensPedidos;
using Pizzaria.Dominio.Features.Pedidos;
using Pizzaria.Dominio.Features.Pedidos.Excecoes;
using Pizzaria.Dominio.Features.Produtos;
using Pizzaria.Dominio.Features.Produtos.Adicionais;
using Pizzaria.Dominio.Features.Produtos.Bebidas;
using Pizzaria.Dominio.Features.Produtos.Calzones;
using Pizzaria.Dominio.Features.Produtos.Pizzas;
using System;

namespace Pizzaria.Dominio.Testes.Features.Pedidos
{
    [TestFixture]
    public class DominioPedidoTestes
    {
        Pizza _pizzaMuzarella;
        Pizza _pizzaCalabresa;
        Calzone _calzone;
        Bebida _refrigerante;
        Adicional _adicional;
        Pedido _pedido;

        [SetUp]
        public void SetUp()
        {
            _pizzaMuzarella = new Pizza();
            _pizzaCalabresa = new Pizza();
            _calzone = new Calzone();
            _refrigerante = new Bebida();
            _adicional = new Adicional();
            _pedido = new Pedido();
        }

        [Test]
        public void Pedido_Teste_Adicionar_Uma_Pizza_Com_Dois_sabores()
        {
            //Cenário
            int quantidadeItems = 1;
            double valorMenor = 10;
            double valorMaior = 15;

            _pizzaMuzarella = ObjetoMae.ObterPizza(TamanhoEnum.PEQUENA);
            _pizzaMuzarella.Valor = valorMenor;

            _pizzaMuzarella = ObjetoMae.ObterPizza(TamanhoEnum.PEQUENA);
            _pizzaMuzarella.Valor = valorMaior;

            var itemPedido = new ItemPedido();
            itemPedido.Adicionar(_pizzaMuzarella, _pizzaCalabresa);
            itemPedido.CalcularValorParcial();

            //Ação
            _pedido.AdicionarItems(itemPedido);

            //Verificação
            _pedido.Itens.Should().NotBeNullOrEmpty();
            _pedido.Itens.Count.Should().Be(quantidadeItems);
            _pedido.ValorTotal.Should().Be(_pizzaMuzarella.Valor);
            itemPedido.ValorParcial.Should().Be(valorMaior);
        }
        [Test]
        public void Pedido_Teste_Adicionar_Um_Item_Valido_E_Um_Nulo()
        {
            //Cenário
            int quantidadeItems = 1;
            double valor = 15;

            _pizzaMuzarella = ObjetoMae.ObterPizza(TamanhoEnum.PEQUENA);
            _pizzaMuzarella.Valor = valor;

            _pizzaCalabresa = null;

             var itemPedido = new ItemPedido();
            itemPedido.Adicionar(_pizzaMuzarella, _pizzaCalabresa);
            itemPedido.CalcularValorParcial();

            //Ação
            _pedido.AdicionarItems(itemPedido);

            //Verificação
            _pedido.Itens.Should().NotBeNullOrEmpty();
            _pedido.Itens.Count.Should().Be(quantidadeItems);
            _pedido.ValorTotal.Should().Be(valor);
        }

        [Test]
        public void Pedido_Dominio_CalcularTotal_Pizza_Media_Um_Sabor()
        {
            //Cenário
            int quantidadeItems = 1;
            var itemPedido = new ItemPedido();

            _pizzaMuzarella = ObjetoMae.ObterPizza(TamanhoEnum.MEDIA);
            itemPedido.Adicionar(_pizzaMuzarella);
            itemPedido.CalcularValorParcial();

            //Ação
            _pedido.AdicionarItems(itemPedido);

            //Verificação
            _pedido.Itens.Should().NotBeNullOrEmpty();
            _pedido.Itens.Count.Should().Be(quantidadeItems);
            _pedido.ValorTotal.Should().Be(_pizzaMuzarella.Valor);
        }

        [Test]
        public void Pedido_Dominio_CalcularTotal_Pizza_Grande_Um_Sabor()
        {
            //Cenário
            int quantidadeItems = 1;
            var itemPedido = new ItemPedido();

            _pizzaMuzarella = ObjetoMae.ObterPizza(TamanhoEnum.GRANDE);
            itemPedido.Adicionar(_pizzaMuzarella);
            itemPedido.CalcularValorParcial();

            //Ação
            _pedido.AdicionarItems(itemPedido);

            //Verificação
            _pedido.Itens.Should().NotBeNullOrEmpty();
            _pedido.Itens.Count.Should().Be(quantidadeItems);
            _pedido.ValorTotal.Should().Be(_pizzaMuzarella.Valor);

        }

        [Test]
        public void Pedido_Dominio_CalcularTotal_Pizza_Pequena_Um_Sabor_Com_Borda_Catupiry()
        {
            //Cenário
            int quantidadeItems = 1;
            var itemPedido = new ItemPedido();

            _pizzaMuzarella = ObjetoMae.ObterPizza(TamanhoEnum.PEQUENA);

            _adicional = ObjetoMae.ObterAdicional(TamanhoEnum.PEQUENA);

            itemPedido.Adicionar(_pizzaMuzarella, _adicional);
            itemPedido.CalcularValorParcial();

            //Ação
            _pedido.AdicionarItems(itemPedido);

            //Verificação
            _pedido.Itens.Should().NotBeNullOrEmpty();
            _pedido.Itens.Count.Should().Be(quantidadeItems);
            _pedido.ValorTotal.Should().Be(_pizzaMuzarella.Valor + _adicional.Valor);
        }

        [Test]
        public void Pedido_Dominio_CalcularTotal_Pizza_Media_Dois_Sabor_Com_Borda_Borda_Catupiry()
        {
            //Cenário
            int quantidadeItems = 1;
            double valorMenor = 15;
            double valorMaior = 20;
            double valorAdicional = 2.50;
            var itemPedido = new ItemPedido();

            _pizzaMuzarella = ObjetoMae.ObterPizza(TamanhoEnum.MEDIA);
            _pizzaMuzarella.Valor = valorMaior;

            _pizzaCalabresa = ObjetoMae.ObterPizza(TamanhoEnum.MEDIA);
            _pizzaCalabresa.Valor = valorMenor;

            _adicional = ObjetoMae.ObterAdicional(TamanhoEnum.MEDIA);
            _adicional.Valor = valorAdicional;

            itemPedido.Adicionar(_pizzaMuzarella, _pizzaCalabresa, _adicional);

            //Ação
            itemPedido.CalcularValorParcial();
            _pedido.AdicionarItems(itemPedido);

            //Verificação
            _pedido.Itens.Should().NotBeNullOrEmpty();
            _pedido.Itens.Count.Should().Be(quantidadeItems);
            itemPedido.ValorParcial.Should().Be(valorMaior + _adicional.Valor);
            _pedido.ValorTotal.Should().Be(valorMaior + _adicional.Valor);
        }

        [Test]
        public void Pedido_Dominio_CalcularTotal_Calzone()
        {
            //Cenário
            int quantidadeItems = 1;
            double valor = 15;
            var itemPedido = new ItemPedido();

            _calzone = ObjetoMae.ObterCalzone(TamanhoEnum.MEDIA);
            _calzone.Valor = valor;
            itemPedido.Adicionar(_calzone);

            //Ação
            itemPedido.CalcularValorParcial();
            _pedido.AdicionarItems(itemPedido);

            //Verificação
            _pedido.Itens.Should().NotBeNullOrEmpty();
            _pedido.Itens.Count.Should().Be(quantidadeItems);
            itemPedido.ValorParcial.Should().Be(valor);
            _pedido.ValorTotal.Should().Be(valor);
        }

        [Test]
        public void Pedido_Dominio_CalcularTotal_uma_Pizza_um_Calzone_um_Refrigerante()
        {
            //Cenário
            int quantidadeItems = 3;
            double valorPizza = 15;
            double valorCalzone = 20;
            double valorRefri = 2.50;
            var itemPedidoPizzaMuzarela = new ItemPedido();

            _pizzaMuzarella = ObjetoMae.ObterPizza(TamanhoEnum.MEDIA);
            _pizzaMuzarella.Valor = valorPizza;

            _calzone = ObjetoMae.ObterCalzone(TamanhoEnum.MEDIA);
            _calzone.Valor = valorCalzone;

            _refrigerante = ObjetoMae.ObterBebida();
            _refrigerante.Valor = valorRefri;

            itemPedidoPizzaMuzarela.Adicionar(_pizzaMuzarella);

            var itemPedidoCalzone = new ItemPedido();
            itemPedidoCalzone.Adicionar(_calzone);

            var itemPedidoRefri = new ItemPedido();
            itemPedidoRefri.Adicionar(_refrigerante);

            //Ação
            itemPedidoRefri.CalcularValorParcial();
            itemPedidoPizzaMuzarela.CalcularValorParcial();
            itemPedidoCalzone.CalcularValorParcial();
            _pedido.AdicionarItems(itemPedidoPizzaMuzarela, itemPedidoCalzone, itemPedidoRefri);

            //Verificação
            _pedido.Itens.Should().NotBeNullOrEmpty();
            _pedido.Itens.Count.Should().Be(quantidadeItems);
            itemPedidoPizzaMuzarela.ValorParcial.Should().Be(valorPizza);
            itemPedidoCalzone.ValorParcial.Should().Be(valorCalzone);
            itemPedidoRefri.ValorParcial.Should().Be(valorRefri);
            _pedido.ValorTotal.Should().Be(valorPizza + valorCalzone + valorRefri);
        }

        [Test]
        public void Pedido_Dominio_Remover_Item_na_Lista_de_Itens_Deve_Diminuir_Valor()
        {
            //Cenário
            int quantidadeItems = 2;
            double valorPizza = 15;
            double valorCalzone = 20;
            double valorRefri = 2.50;
            var itemPedidoPizzaMuzarela = new ItemPedido();

            _pizzaMuzarella = ObjetoMae.ObterPizza(TamanhoEnum.MEDIA);
            _pizzaMuzarella.Valor = valorPizza;

            _calzone = ObjetoMae.ObterCalzone(TamanhoEnum.MEDIA);
            _calzone.Valor = valorCalzone;

            _refrigerante = ObjetoMae.ObterBebida();
            _refrigerante.Valor = valorRefri;

            itemPedidoPizzaMuzarela.Adicionar(_pizzaMuzarella);
            itemPedidoPizzaMuzarela.CalcularValorParcial();

            var itemPedidoCalzone = new ItemPedido();
            itemPedidoCalzone.Adicionar(_calzone);
            itemPedidoCalzone.CalcularValorParcial();

            var itemPedidoRefri = new ItemPedido();
            itemPedidoRefri.Adicionar(_refrigerante);
            itemPedidoRefri.CalcularValorParcial();
            _pedido.AdicionarItems(itemPedidoPizzaMuzarela, itemPedidoCalzone, itemPedidoRefri);

            //Ação
            _pedido.RemoverItem(itemPedidoRefri);

            //Verificação
            _pedido.Itens.Should().NotBeNullOrEmpty();
            _pedido.Itens.Count.Should().Be(quantidadeItems);
            _pedido.ValorTotal.Should().Be(valorPizza + valorCalzone);
        }


        [Test]
        public void Pedido_Dominio_Remover_Item_na_Lista_Com_Um_Item_Nulo()
        {
            //Cenário
            int quantidadeItems = 1;
            double valorPizza = 15;
            double valorCalzone = 20;
            var itemPedidoPizzaMuzarela = new ItemPedido();

            _pizzaMuzarella = ObjetoMae.ObterPizza(TamanhoEnum.MEDIA);
            _pizzaMuzarella.Valor = valorPizza;

            _calzone = ObjetoMae.ObterCalzone(TamanhoEnum.MEDIA);
            _calzone.Valor = valorCalzone;

            _refrigerante = null;

            itemPedidoPizzaMuzarela.Adicionar(_pizzaMuzarella);
            itemPedidoPizzaMuzarela.CalcularValorParcial();

            var itemPedidoCalzone = new ItemPedido();
            itemPedidoCalzone.Adicionar(_calzone);
            itemPedidoCalzone.CalcularValorParcial();

            var itemPedidoRefri = new ItemPedido();
            itemPedidoRefri.Adicionar(_refrigerante);
            _pedido.AdicionarItems(itemPedidoPizzaMuzarela, itemPedidoCalzone);

            //Ação
            _pedido.RemoverItem(itemPedidoCalzone);

            //Verificação
            _pedido.Itens.Should().NotBeNullOrEmpty();
            _pedido.Itens.Count.Should().Be(quantidadeItems);
            _pedido.ValorTotal.Should().Be(valorPizza);
        }

        [Test]
        public void Pedido_Dominio_Validar_Deve_Ser_Sucesso()
        {

            //Cenário
            int quantidadeItems = 1;
            double valor = 15;
            var itemPedido = new ItemPedido();
            _calzone = ObjetoMae.ObterCalzone(TamanhoEnum.MEDIA);
            _calzone.Valor = valor;
            itemPedido.Adicionar(_calzone);
            _pedido.AdicionarItems(itemPedido);
            _pedido.Cliente = ObjetoMae.ObterClienteValidoComCpf();
            _pedido.Data = DateTime.Now;
            _pedido.TipoPagamento = TipoPagamentoEnum.Dinheiro;

            //Ação
            Action action = () => _pedido.Validar();

            //Verificação
            action.Should().NotThrow();
            _pedido.Itens.Should().NotBeNullOrEmpty();
            _pedido.Itens.Count.Should().Be(quantidadeItems);
        }

        [Test]
        public void Pedido_Dominio_Validar__Cliente_Invalido_Deve_Retornar_Excecao()
        {

            //Cenário
            var itemPedido = new ItemPedido();
            _calzone = ObjetoMae.ObterCalzone(TamanhoEnum.MEDIA);

            itemPedido.Adicionar(_calzone);

            _pedido.AdicionarItems(itemPedido);
            _pedido.Cliente = null;
            _pedido.TipoPagamento = TipoPagamentoEnum.Dinheiro;
            _pedido.Data = DateTime.Now;
            //Ação
            Action action = () => _pedido.Validar();

            //Verificação
            action.Should().Throw<ClienteInvalidoExcecao>();
        }

        [Test]
        public void Pedido_Dominio_Validar_Data_Invalida_Deve_Retornar_Excecao()
        {

            //Cenário
            var itemPedido = new ItemPedido();
            _calzone = ObjetoMae.ObterCalzone(TamanhoEnum.MEDIA);

            itemPedido.Adicionar(_calzone);

            _pedido.AdicionarItems(itemPedido);
            _pedido.Cliente = null;
            _pedido.TipoPagamento = TipoPagamentoEnum.Dinheiro;
            _pedido.Data = DateTime.Now.AddDays(1);
            //Ação
            Action action = () => _pedido.Validar();

            //Verificação
            action.Should().Throw<DataInvalidaExcecao>();
        }

        [Test]
        public void Pedido_Dominio_Validar_TipoPagamento_Invalido_Deve_Retornar_Excecao()
        {

            //Cenário
            var itemPedido = new ItemPedido();
            _calzone = ObjetoMae.ObterCalzone(TamanhoEnum.MEDIA);

            itemPedido.Adicionar(_calzone);

            _pedido.AdicionarItems(itemPedido);
            _pedido.Cliente = null;
            _pedido.TipoPagamento = 0;
            _pedido.Cliente = ObjetoMae.ObterClienteValidoComCpf();
            _pedido.Data = DateTime.Now;
            //Ação
            Action action = () => _pedido.Validar();

            //Verificação
            action.Should().Throw<TipoPagamentoInvalidoExcecao>();
        }

        [Test]
        public void Pedido_Dominio_Validar_ListaItems_Invalida_Deve_Retornar_Excecao()
        {

            //Cenário
            _pedido.Cliente = null;
            _pedido.TipoPagamento = TipoPagamentoEnum.Dinheiro;
            _pedido.Data = DateTime.Now;
            _pedido.Cliente = ObjetoMae.ObterClienteValidoComCpf();
            //Ação
            Action action = () => _pedido.Validar();

            //Verificação
            action.Should().Throw<ListaDeProdutosVaziaExcecao>();
        }
    }
}
