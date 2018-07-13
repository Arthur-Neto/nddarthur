using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pizzaria.Aplicacao.Features.Pedidos;
using Pizzaria.Dominio.Exceptions;
using Pizzaria.Dominio.Features.Pedidos;
using Pizzaria.Dominio.Features.Pedidos.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizzaria.Aplicacao.Testes.Features.Pedidos
{
    [TestFixture]
    public class AplicacaoPedidoTestes
    {
        Mock<Pedido> _mockPedido;
        Mock<IPedidoRepositorio> _mockRepositorio;
        PedidoServico _servico;

        [SetUp]
        public void SetUp()
        {
            _mockPedido = new Mock<Pedido>();
            _mockRepositorio = new Mock<IPedidoRepositorio>();
            _servico = new PedidoServico(_mockRepositorio.Object);
        }

        [Test]
        public void Pedido_Aplicacao_Adicionar_Deve_Ser_Sucesso()
        {
            //cenario
            int id = 1;
            _mockRepositorio.Setup(r => r.Salvar(_mockPedido.Object)).Returns(new Pedido { Id = id });

            //acao
            var pedido = _servico.Adicionar(_mockPedido.Object);

            //verificar
            _mockPedido.Verify(p => p.Validar());
            _mockRepositorio.Verify(r => r.Salvar(_mockPedido.Object));
            pedido.Should().NotBeNull();
            pedido.Id.Should().Be(id);
        }

        [Test]
        public void Pedido_Aplicacao_Atualizar_Deve_Ser_Sucesso()
        {
            //cenario
            int id = 1;
            _mockPedido.Setup(p => p.Id).Returns(id);
            _mockRepositorio.Setup(r => r.Atualizar(_mockPedido.Object)).Returns(new Pedido { Id = id });

            //acao
            var pedido = _servico.Atualizar(_mockPedido.Object);

            //verificar
            _mockPedido.Verify(p => p.Validar());
            _mockRepositorio.Verify(r => r.Atualizar(_mockPedido.Object));
            pedido.Should().NotBeNull();
            pedido.Id.Should().Be(id);
        }

        [Test]
        public void Pedido_Aplicacao_Deletar_Deve_Ser_Sucesso()
        {
            //cenario
            int id = 1;
            _mockPedido.Setup(p => p.Id).Returns(id);

            //acao
            Action action = () => _servico.Excluir(_mockPedido.Object);

            //verificar
            action.Should().NotThrow();
            _mockRepositorio.Verify(r => r.Deletar(_mockPedido.Object));
        }

        [Test]
        public void Pedido_Aplicacao_ObterPorId_Deve_Ser_Sucesso()
        {
            //cenario
            int id = 1;
            _mockPedido.Setup(p => p.Id).Returns(id);
            _mockRepositorio.Setup(r => r.ObterPorId(id)).Returns(_mockPedido.Object);

            //acao
            var pedido = _servico.ObterPorId(id);

            //verificar
            _mockRepositorio.Verify(r => r.ObterPorId(id));
            pedido.Should().NotBeNull();
            pedido.Id.Should().Be(id);
        }

        [Test]
        public void Pedido_Aplicacao_ObterTodos_Deve_Ser_Sucesso()
        {
            //cenario
            int id = 1;
            int quantidadePedidos = 1;
            var pedidos = new List<Pedido>();
            _mockPedido.Setup(p => p.Id).Returns(id);
            pedidos.Add(_mockPedido.Object);

            _mockRepositorio.Setup(r => r.ObterTodos()).Returns(pedidos);

            //acao
            var pedidosObtidos = _servico.ObterTodos();

            //verificar
            _mockRepositorio.Verify(r => r.ObterTodos());
            pedidosObtidos.Should().NotBeNullOrEmpty();
            pedidosObtidos.Count().Should().Be(quantidadePedidos);
            pedidosObtidos.First().Id.Should().Be(id);
        }

        [Test]
        public void Pedido_Aplicacao_Salvar_ClienteInvalido_Deve_Retornar_Excecao()
        {

            //cenário
            _mockPedido.Setup(c => c.Validar()).Throws<ClienteInvalidoExcecao>();

            //Ação
            Action action = () => _servico.Adicionar(_mockPedido.Object);

            //Verificação
            action.Should().Throw<ClienteInvalidoExcecao>();
        }

        [Test]
        public void Pedido_Aplicacao_Atualizar_ClienteInvalido_Deve_Retornar_Excecao()
        {

            //cenário
            _mockPedido.Setup(x => x.Id).Returns(1);

            _mockPedido.Setup(c => c.Validar()).Throws<ClienteInvalidoExcecao>();

            //Ação
            Action action = () => _servico.Atualizar(_mockPedido.Object);

            //Verificação
            action.Should().Throw<ClienteInvalidoExcecao>();
        }

        [Test]
        public void Pedido_Aplicacao_Atualizar_IDInvalido_Deve_Retornar_Excecao()
        {

            //cenário
            _mockPedido.Setup(x => x.Id).Returns(0);

            //Ação
            Action action = () => _servico.Atualizar(_mockPedido.Object);

            //Verificação
            action.Should().Throw<IdentificadorInvalidoExcecao>();
        }

        [Test]
        public void Pedido_Aplicacao_Deletar_IDInvalido_Deve_Retornar_Excecao()
        {

            //cenário
            _mockPedido.Setup(x => x.Id).Returns(0);

            //Ação
            Action action = () => _servico.Excluir(_mockPedido.Object);

            //Verificação
            action.Should().Throw<IdentificadorInvalidoExcecao>();
        }

        [Test]
        public void Pedido_Aplicacao_ObterPorId_IDInvalido_Deve_Retornar_Excecao()
        {

            //cenário
            _mockPedido.Setup(x => x.Id).Returns(0);

            //Ação
            Action action = () => _servico.ObterPorId(_mockPedido.Object.Id);

            //Verificação
            action.Should().Throw<IdentificadorInvalidoExcecao>();
        }
    }
}
