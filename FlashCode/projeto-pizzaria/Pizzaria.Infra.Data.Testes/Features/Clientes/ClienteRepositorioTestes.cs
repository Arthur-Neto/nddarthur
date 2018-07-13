using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Testes.Base;
using Pizzaria.Common.Testes.Features;
using Pizzaria.Dominio.Features.Clientes;
using Pizzaria.Infra.Data.Base;
using Pizzaria.Infra.Data.Features.Clientes;
using System.Data.Entity;
using System.Linq;

namespace Pizzaria.Infra.Data.Testes.Features.Clientes
{
    [TestFixture]
    public class ClienteRepositorioTestes
    {
        PizzariaContext contexto;
        ClienteRepositorio repositorio;
        Cliente cliente;

        [SetUp]
        public void SetUp()
        {
            contexto = new PizzariaContext();
            repositorio = new ClienteRepositorio(contexto);
            cliente = ObjetoMae.ObterClienteValidoComCpf();
            Database.SetInitializer(new BaseSqlTestes());
            contexto.Database.Initialize(true);
        }

        [Test]
        public void Cliente_InfraData_Salvar_Deve_Inserir_Cliente_Qualquer()
        {
            cliente = repositorio.Salvar(cliente);

            cliente.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Cliente_InfraData_ObterPorId_Deve_Obter_Cliente()
        {
            cliente.Id = 1;

            var novoCliente = repositorio.ObterPorId(cliente.Id);

            novoCliente.Nome.Should().Be(cliente.Nome);
        }

        [Test]
        public void Cliente_InfraData_ObterTodos_Deve_Obter_Todos_Clientes()
        {
            cliente.Id = 1;

            var clientes = repositorio.ObterTodos();

            clientes.First().Id.Should().Be(cliente.Id);
            clientes.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Cliente_InfraData_Deletar_Deve_Deletar_Cliente()
        {
            cliente = repositorio.Salvar(cliente);

            repositorio.Deletar(cliente);

            var deletado = repositorio.ObterPorId(cliente.Id);

            deletado.Should().BeNull();
        }

        [Test]
        public void Cliente_InfraData_Atualizar_Deve_Atualizar_Cliente()
        {
            cliente = repositorio.Salvar(cliente);
            cliente.Nome = "Tabaldi";

            var atualizado = repositorio.Atualizar(cliente);

            atualizado.Nome.Should().Be(cliente.Nome);
        }

        [Test]
        public void Cliente_InfraData_BuscarPorTelefone_Deve_Obter_Cliente()
        {
            cliente = repositorio.Salvar(cliente);

            var clientes = repositorio.BuscarPorTelefone(cliente.Telefone);

            clientes.First().Telefone.Should().Be(cliente.Telefone);
            clientes.Count().Should().BeGreaterThan(0);
        }
    }
}
