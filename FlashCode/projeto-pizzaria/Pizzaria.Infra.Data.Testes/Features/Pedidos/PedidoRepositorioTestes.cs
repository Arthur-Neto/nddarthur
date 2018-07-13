using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Testes.Base;
using Pizzaria.Common.Testes.Features;
using Pizzaria.Dominio.Features.Pedidos;
using Pizzaria.Infra.Data.Base;
using Pizzaria.Infra.Data.Features.Pedidos;
using System.Data.Entity;
using System.Linq;

namespace Pizzaria.Infra.Data.Testes.Features.Pedidos
{
    [TestFixture]
    public class PedidoRepositorioTestes
    {
        PizzariaContext contexto;
        PedidoRepositorio repositorio;
        Pedido pedido;

        [SetUp]
        public void SetUp()
        {
            contexto = new PizzariaContext();
            repositorio = new PedidoRepositorio(contexto);
            pedido = ObjetoMae.ObterPedidoValido();
            Database.SetInitializer(new BaseSqlTestes());
            contexto.Database.Initialize(true);
        }

        [Test]
        public void Pedido_InfraData_Salvar_Deve_Inserir_Pedido_Qualquer()
        {
            pedido = repositorio.Salvar(pedido);

            pedido.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Pedido_InfraData_ObterPorId_Deve_Obter_Pedido()
        {
            int numItemsEsperado = 2;
            pedido.Id = 1;

            var novoPedido = repositorio.ObterPorId(pedido.Id);

            novoPedido.Id.Should().Be(pedido.Id);
            novoPedido.Itens.Count.Should().Be(numItemsEsperado);
        }

        [Test]
        public void Pedido_InfraData_ObterPorId_Deve_Obter_Pedido_Com_Item_Dois_sabores_Mais_Borda()
        {
            int quantidadeProdutos = 3;

            pedido = ObjetoMae.ObterPedidoValidoComPizzaDoisSaboresMaisBorda();

            pedido = repositorio.Salvar(pedido);

            var novoPedido = repositorio.ObterPorId(pedido.Id);

            novoPedido.Id.Should().Be(pedido.Id);
            novoPedido.Itens.First().Produtos.Count.Should().Be(quantidadeProdutos);
        }

        [Test]
        public void Pedido_InfraData_ObterTodos_Deve_Obter_Todos_Pedidos()
        {
            pedido.Id = 1;

            var pedidos = repositorio.ObterTodos();

            pedidos.First().Id.Should().Be(pedido.Id);
            pedidos.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Pedido_InfraData_Deletar_Deve_Deletar_Pedido()
        {
            pedido = repositorio.ObterPorId(1);

            repositorio.Deletar(pedido);

            var deletado = repositorio.ObterPorId(pedido.Id);

            deletado.Should().BeNull();
        }

        [Test]
        public void Pedido_InfraData_Atualizar_Deve_Atualizar_Pedido()
        {
            pedido = repositorio.Salvar(pedido);
            pedido.Cliente.Nome = "Tabaldi";

            var atualizado = repositorio.Atualizar(pedido);

            atualizado.Cliente.Nome.Should().Be(pedido.Cliente.Nome);
        }
    }
}
