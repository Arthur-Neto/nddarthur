using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Aplicacao.Features.Clientes;
using Pizzaria.Common.Testes.Base;
using Pizzaria.Common.Testes.Features;
using Pizzaria.Dominio.Features.Clientes;
using Pizzaria.Dominio.Features.Clientes.Excecoes;
using Pizzaria.Infra.Data.Base;
using Pizzaria.Infra.Data.Features.Clientes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.IntegracaoSistema.Testes.Features.Clientes
{
    [TestFixture]
    public class IntegracaoTestesClientes
    {
        IClienteRepositorio _clienteRepositorio;
        IClienteServico _clienteServico;
        Cliente _cliente;
        PizzariaContext _context;
        [SetUp]
        public void SetUp()
        {
            _cliente = ObjetoMae.ObterClienteValidoComCpf();
            _context = new PizzariaContext();
            _clienteRepositorio = new ClienteRepositorio(_context);
            _clienteServico = new ClienteServico(_clienteRepositorio);
            Database.SetInitializer(new BaseSqlTestes());
            _context.Database.Initialize(true);
        }

        [Test]
        public void Cliente_Integracao_Adicionar_Deve_Adicionar()
        {
            //Cenário

            //Ação
            var cliente = _clienteServico.Adicionar(_cliente);

            //Verificação
            var pedidoBuscado = _clienteServico.ObterPorId(cliente.Id);
            cliente.Id.Should().Be(pedidoBuscado.Id);
            cliente.Telefone.Should().Be(pedidoBuscado.Telefone);
            cliente.Telefone.Should().Be(_cliente.Telefone);
        }

        [Test]
        public void Cliente_Integracao_ObterTodos_Deve_obter()
        {
            //Cenário
            var id = 1;

            //Ação
            var clientes = _clienteServico.ObterTodos();

            //Verificação
            clientes.First().Id.Should().Be(id);
            clientes.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Cliente_Integracao_ObterPorID_Deve_Obter()
        {
            //Cenário
            var id = 1;

            //Ação
            var cliente = _clienteServico.ObterPorId(id);

            //Verificação
            cliente.Id.Should().Be(id);
            cliente.Should().NotBeNull();
        }

        [Test]
        public void Cliente_Integracao_Atualizar_DeveAtualizar()
        {
            //Cenário
            var cliente = _clienteServico.Adicionar(_cliente);
            cliente.Telefone = "1234567890";

            //Ação
            var clienteEditado = _clienteServico.Atualizar(cliente);

            //Verificação
            var pedidoBuscado = _clienteServico.ObterPorId(clienteEditado.Id);
            pedidoBuscado.Id.Should().Be(clienteEditado.Id);
            clienteEditado.Should().NotBeNull();
            clienteEditado.Telefone.Should().Be(cliente.Telefone);
        }
        [Test]
        public void Cliente_Integracao_Excluir_Deve_Excluir()
        {
            //Cenário
            var cliente = _clienteServico.Adicionar(_cliente);

            //Ação
            _clienteServico.Excluir(cliente);

            //Verificação
            var pedidoBuscado = _clienteServico.ObterPorId(cliente.Id);
            pedidoBuscado.Should().BeNull();
        }

        [Test]
        public void Cliente_Integracao_Adicionar_TelefoneInvalido_Deve_Lancar_Excecao()
        {
            //Cenário
            _cliente.Telefone = string.Empty;

            //Ação
            Action action = () => _clienteServico.Adicionar(_cliente);

            //Verificação
            action.Should().Throw<TelefoneInvalidoExcecao>();

        }

    }
}
