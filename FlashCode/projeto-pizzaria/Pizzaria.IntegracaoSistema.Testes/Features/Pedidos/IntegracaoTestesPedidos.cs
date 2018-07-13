using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Aplicacao.Features.Pedidos;
using Pizzaria.Common.Testes.Base;
using Pizzaria.Common.Testes.Features;
using Pizzaria.Dominio.Features.Pedidos;
using Pizzaria.Dominio.Features.Pedidos.Excecoes;
using Pizzaria.Dominio.Features.Produtos;
using Pizzaria.Infra.Data.Base;
using Pizzaria.Infra.Data.Features.Pedidos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.IntegracaoSistema.Testes.Features.Pedidos
{
    [TestFixture]
    public class IntegracaoTestesPedidos
    {
        IPedidoRepositorio _pedidoRepositorio;
        IPedidoServico _pedidoServico;
        Pedido _pedido;
        PizzariaContext _context;
        [SetUp]
        public void SetUp()
        {
            _pedido = ObjetoMae.ObterPedidoValido();
            _context = new PizzariaContext();
            _pedidoRepositorio = new PedidoRepositorio(_context);
            _pedidoServico = new PedidoServico(_pedidoRepositorio);
            Database.SetInitializer(new BaseSqlTestes());
            _context.Database.Initialize(true);
        }

        [Test]
        public void Pedido_Integracao_Adicionar_Deve_Adicionar()
        {
            //Cenário

            //Ação
            var pedido = _pedidoServico.Adicionar(_pedido);

            //Verificação
            var pedidoBuscado = _pedidoServico.ObterPorId(pedido.Id);
            pedido.Id.Should().Be(pedidoBuscado.Id);
            pedido.Status.Should().Be(pedidoBuscado.Status);
            pedido.Status.Should().Be(_pedido.Status);
        }

        [Test]
        public void Pedido_Integracao_ObterTodos_Deve_obter()
        {
            //Cenário
            var id = 1;

            //Ação
            var pedidos = _pedidoServico.ObterTodos();

            //Verificação
            pedidos.First().Id.Should().Be(id);
            pedidos.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Pedido_Integracao_ObterPorID_Deve_Obter()
        {
            //Cenário
            var id = 1;

            //Ação
            var pedido = _pedidoServico.ObterPorId(id);

            //Verificação
            pedido.Id.Should().Be(id);
            pedido.Should().NotBeNull();
        }

        [Test]
        public void Pedido_Integracao_Atualizar_DeveAtualizar()
        {
            //Cenário
            var pedido = _pedidoServico.Adicionar(_pedido);
            pedido.TipoPagamento = TipoPagamentoEnum.Visa;

            //Ação
            var pedidoEditado = _pedidoServico.Atualizar(pedido);

            //Verificação
            var pedidoBuscado = _pedidoServico.ObterPorId(pedidoEditado.Id);
            pedidoBuscado.Id.Should().Be(pedidoEditado.Id);
            pedidoEditado.Should().NotBeNull();
            pedidoEditado.TipoPagamento.Should().Be(pedido.TipoPagamento);
        }
        [Test]
        public void Pedido_Integracao_Excluir_Deve_Excluir()
        {
            //Cenário
            var pedido = _pedidoServico.Adicionar(_pedido);

            //Ação
            _pedidoServico.Excluir(pedido);

            //Verificação
            var pedidoBuscado = _pedidoServico.ObterPorId(pedido.Id);
            pedidoBuscado.Should().BeNull();
        }

        [Test]
        public void Pedido_Integracao_Adicionar_PagamentoInvalido_Deve_Lancar_Excecao()
        {
            //Cenário
            _pedido.TipoPagamento = 0;

            //Ação
            Action action = () => _pedidoServico.Adicionar(_pedido);

            //Verificação
            action.Should().Throw<TipoPagamentoInvalidoExcecao>();

        }
    }
}
