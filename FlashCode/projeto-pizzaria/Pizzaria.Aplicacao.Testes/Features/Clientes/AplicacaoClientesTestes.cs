using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pizzaria.Aplicacao.Features.Clientes;
using Pizzaria.Dominio.Exceptions;
using Pizzaria.Dominio.Features.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizzaria.Aplicacao.Testes.Features.Clientes
{
    [TestFixture]
    public class AplicacaoClientesTestes
    {
        Mock<Cliente> _mockCliente;
        Mock<IClienteRepositorio> _mockRepositorio;
        ClienteServico _servico;

        [SetUp]
        public void SetUp()
        {
            _mockCliente = new Mock<Cliente>();
            _mockRepositorio = new Mock<IClienteRepositorio>();
            _servico = new ClienteServico(_mockRepositorio.Object);
        }

        [Test]
        public void Cliente_Aplicacao_Adicionar_Deve_Ser_Sucesso()
        {
            //cenario
            int id = 1;
            _mockRepositorio.Setup(r => r.Salvar(_mockCliente.Object)).Returns(new Cliente { Id = id });

            //acao
            var pedido = _servico.Adicionar(_mockCliente.Object);

            //verificar
            _mockCliente.Verify(p => p.Validar());
            _mockRepositorio.Verify(r => r.Salvar(_mockCliente.Object));
            pedido.Should().NotBeNull();
            pedido.Id.Should().Be(id);
        }

        [Test]
        public void Cliente_Aplicacao_Atualizar_Deve_Ser_Sucesso()
        {
            //cenario
            int id = 1;
            _mockCliente.Setup(p => p.Id).Returns(id);
            _mockRepositorio.Setup(r => r.Atualizar(_mockCliente.Object)).Returns(new Cliente { Id = id });

            //acao
            var pedido = _servico.Atualizar(_mockCliente.Object);

            //verificar
            _mockCliente.Verify(p => p.Validar());
            _mockRepositorio.Verify(r => r.Atualizar(_mockCliente.Object));
            pedido.Should().NotBeNull();
            pedido.Id.Should().Be(id);
        }

        [Test]
        public void Cliente_Aplicacao_Deletar_Deve_Ser_Sucesso()
        {
            //cenario
            int id = 1;
            _mockCliente.Setup(p => p.Id).Returns(id);

            //acao
            Action action = () => _servico.Excluir(_mockCliente.Object);

            //verificar
            action.Should().NotThrow();
            _mockRepositorio.Verify(r => r.Deletar(_mockCliente.Object));
        }

        [Test]
        public void Cliente_Aplicacao_ObterPorId_Deve_Ser_Sucesso()
        {
            //cenario
            int id = 1;
            _mockCliente.Setup(p => p.Id).Returns(id);
            _mockRepositorio.Setup(r => r.ObterPorId(id)).Returns(_mockCliente.Object);

            //acao
            var pedido = _servico.ObterPorId(id);

            //verificar
            _mockRepositorio.Verify(r => r.ObterPorId(id));
            pedido.Should().NotBeNull();
            pedido.Id.Should().Be(id);
        }

        [Test]
        public void Cliente_Aplicacao_ObterPorTelefone_Deve_Ser_Sucesso()
        {
            //cenario
            string telefone = "12345678";
            _mockCliente.Setup(p => p.Telefone).Returns(telefone);
            _mockRepositorio.Setup(r => r.BuscarPorTelefone(telefone)).Returns(new List<Cliente>() { new Cliente() { Telefone = telefone } });

            //acao
            var clientes = _servico.BuscarPorTelefone(telefone);

            //verificar
            _mockRepositorio.Verify(r => r.BuscarPorTelefone(telefone));
            clientes.Should().NotBeNull();
            clientes.First().Telefone.Should().Be(telefone);
        }

        [Test]
        public void Cliente_Aplicacao_ObterTodos_Deve_Ser_Sucesso()
        {
            //cenario
            int id = 1;
            int quantidadePedidos = 1;
            var pedidos = new List<Cliente>();
            _mockCliente.Setup(p => p.Id).Returns(id);
            pedidos.Add(_mockCliente.Object);

            _mockRepositorio.Setup(r => r.ObterTodos()).Returns(pedidos);

            //acao
            var clientesObtidos = _servico.ObterTodos();

            //verificar
            _mockRepositorio.Verify(r => r.ObterTodos());
            clientesObtidos.Should().NotBeNullOrEmpty();
            clientesObtidos.Count().Should().Be(quantidadePedidos);
            clientesObtidos.First().Id.Should().Be(id);
        }

        [Test]
        public void Cliente_Aplicacao_Atualizar_IDInvalido_Deve_Retornar_Excecao()
        {

            //cenário
            _mockCliente.Setup(x => x.Id).Returns(0);

            //Ação
            Action action = () => _servico.Atualizar(_mockCliente.Object);

            //Verificação
            action.Should().Throw<IdentificadorInvalidoExcecao>();
        }

        [Test]
        public void Cliente_Aplicacao_Deletar_IDInvalido_Deve_Retornar_Excecao()
        {

            //cenário
            _mockCliente.Setup(x => x.Id).Returns(0);

            //Ação
            Action action = () => _servico.Excluir(_mockCliente.Object);

            //Verificação
            action.Should().Throw<IdentificadorInvalidoExcecao>();
        }

        [Test]
        public void Cliente_Aplicacao_ObterPorId_IDInvalido_Deve_Retornar_Excecao()
        {

            //cenário
            _mockCliente.Setup(x => x.Id).Returns(0);

            //Ação
            Action action = () => _servico.ObterPorId(_mockCliente.Object.Id);

            //Verificação
            action.Should().Throw<IdentificadorInvalidoExcecao>();
        }
    }
}
