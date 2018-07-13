using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pizzaria.Aplicacao.Features.Produtos;
using Pizzaria.Common.Testes.Features;
using Pizzaria.Dominio.Exceptions;
using Pizzaria.Dominio.Features.Produtos;
using Pizzaria.Dominio.Features.Produtos.Adicionais;
using Pizzaria.Dominio.Features.Produtos.Bebidas;
using Pizzaria.Dominio.Features.Produtos.Calzones;
using Pizzaria.Dominio.Features.Produtos.Excecoes;
using Pizzaria.Dominio.Features.Produtos.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizzaria.Aplicacao.Testes.Features.Produtos
{
    [TestFixture]
    public class AplicacaoProdutoTestes
    {
        Mock<Produto> _mockProduto;
        Mock<IProdutoRepositorio> _mockRepositorio;
        IProdutoServico _servico;
        TamanhoEnum _tamanho;

        [SetUp]
        public void SetUp()
        {
            _mockProduto = new Mock<Produto>();
            _mockRepositorio = new Mock<IProdutoRepositorio>();
            _servico = new ProdutoServico(_mockRepositorio.Object);
            _tamanho = TamanhoEnum.GRANDE;
        }

        [Test]
        public void Produto_Aplicacao_Adicionar_Deve_Ser_Sucesso()
        {
            //cenario
            int id = 1;
            _mockRepositorio.Setup(r => r.Salvar(_mockProduto.Object)).Returns(new Pizza { Id = id });

            //acao
            var produto = _servico.Adicionar(_mockProduto.Object);

            //verificar
            _mockProduto.Verify(p => p.Validar());
            _mockRepositorio.Verify(r => r.Salvar(_mockProduto.Object));
            produto.Should().NotBeNull();
            produto.Id.Should().Be(id);
        }

        [Test]
        public void Produto_Aplicacao_Atualizar_Deve_Ser_Sucesso()
        {
            //cenario
            int id = 1;
            _mockProduto.Setup(p => p.Id).Returns(id);
            _mockRepositorio.Setup(r => r.Atualizar(_mockProduto.Object)).Returns(new Pizza { Id = id });

            //acao
            var produto = _servico.Atualizar(_mockProduto.Object);

            //verificar
            _mockProduto.Verify(p => p.Validar());
            _mockRepositorio.Verify(r => r.Atualizar(_mockProduto.Object));
            produto.Should().NotBeNull();
            produto.Id.Should().Be(id);
        }

        [Test]
        public void Produto_Aplicacao_Deletar_Deve_Ser_Sucesso()
        {
            //cenario
            int id = 1;
            _mockProduto.Setup(p => p.Id).Returns(id);

            //acao
            Action action = () => _servico.Excluir(_mockProduto.Object);

            //verificar
            action.Should().NotThrow();
            _mockRepositorio.Verify(r => r.Deletar(_mockProduto.Object));
        }

        [Test]
        public void Produto_Aplicacao_ObterPorId_Deve_Ser_Sucesso()
        {
            //cenario
            int id = 1;
            _mockProduto.Setup(p => p.Id).Returns(id);
            _mockRepositorio.Setup(r => r.ObterPorId(id)).Returns(_mockProduto.Object);

            //acao
            var produto = _servico.ObterPorId(id);

            //verificar
            _mockRepositorio.Verify(r => r.ObterPorId(id));
            produto.Should().NotBeNull();
            produto.Id.Should().Be(id);
        }

        [Test]
        public void Produto_Aplicacao_ObterTodos_Deve_Ser_Sucesso()
        {
            //cenario
            int id = 1;
            int quantidadePedidos = 1;
            var pedidos = new List<Produto>();
            _mockProduto.Setup(p => p.Id).Returns(id);
            pedidos.Add(_mockProduto.Object);

            _mockRepositorio.Setup(r => r.ObterTodos()).Returns(pedidos);

            //acao
            var produtos = _servico.ObterTodos();

            //verificar
            _mockRepositorio.Verify(r => r.ObterTodos());
            produtos.Should().NotBeNullOrEmpty();
            produtos.Count().Should().Be(quantidadePedidos);
            produtos.First().Id.Should().Be(id);
        }

        [Test]
        public void Produto_Aplicacao_Salvar_ValorInvalido_Deve_Retornar_Excecao()
        {

            //cenário
            _mockProduto.Setup(c => c.Validar()).Throws<ValorInvalidoExcecao>();

            //Ação
            Action action = () => _servico.Adicionar(_mockProduto.Object);

            //Verificação
            action.Should().Throw<ValorInvalidoExcecao>();
        }

        [Test]
        public void Produto_Aplicacao_Atualizar_ValorInvalido_Deve_Retornar_Excecao()
        {

            //cenário
            _mockProduto.Setup(x => x.Id).Returns(1);

            _mockProduto.Setup(c => c.Validar()).Throws<ValorInvalidoExcecao>();

            //Ação
            Action action = () => _servico.Atualizar(_mockProduto.Object);

            //Verificação
            action.Should().Throw<ValorInvalidoExcecao>();
        }

        [Test]
        public void Produto_Aplicacao_Atualizar_IDInvalido_Deve_Retornar_Excecao()
        {

            //cenário
            _mockProduto.Setup(x => x.Id).Returns(0);

            //Ação
            Action action = () => _servico.Atualizar(_mockProduto.Object);

            //Verificação
            action.Should().Throw<IdentificadorInvalidoExcecao>();
        }

        [Test]
        public void Produto_Aplicacao_Deletar_IDInvalido_Deve_Retornar_Excecao()
        {

            //cenário
            _mockProduto.Setup(x => x.Id).Returns(0);

            //Ação
            Action action = () => _servico.Excluir(_mockProduto.Object);

            //Verificação
            action.Should().Throw<IdentificadorInvalidoExcecao>();
        }

        [Test]
        public void Produto_Aplicacao_ObterPorId_IDInvalido_Deve_Retornar_Excecao()
        {

            //cenário
            _mockProduto.Setup(x => x.Id).Returns(0);

            //Ação
            Action action = () => _servico.ObterPorId(_mockProduto.Object.Id);

            //Verificação
            action.Should().Throw<IdentificadorInvalidoExcecao>();
        }

        [Test]
        public void Produto_Aplicacao_ObterPizza_Deve_Obter()
        {
            //cenário
            var quantidade = 1;

            _mockProduto.Setup(x => x.Tamanho).Returns(_tamanho);

            _mockRepositorio.Setup(r => r.ObterPizzas(_tamanho)).Returns(new List<Pizza> { new Pizza { Id = 1, Tamanho = _tamanho } });

            //Ação
            var produtos = _servico.ObterPizzas(_mockProduto.Object.Tamanho);

            //Verificação
            _mockRepositorio.Verify(r => r.ObterPizzas(_tamanho));
            produtos.Should().NotBeNull();
            produtos.First().Tamanho.Should().Be(_tamanho);
            produtos.Count().Should().Be(quantidade);
        }

        [Test]
        public void Produto_Aplicacao_ObterCalzone_Deve_Obter()
        {
            //cenário
            var quantidade = 1;

            _mockProduto.Setup(x => x.Tamanho).Returns(_tamanho);

            _mockRepositorio.Setup(r => r.ObterCalzones(_tamanho)).Returns(new List<Calzone> { new Calzone { Id = 1 } });

            //Ação
            var produtos = _servico.ObterCalzones(_mockProduto.Object.Tamanho);

            //Verificação
            _mockRepositorio.Verify(r => r.ObterCalzones(_tamanho));
            produtos.Should().NotBeNull();
            produtos.Count().Should().Be(quantidade);
        }

        [Test]
        public void Produto_Aplicacao_ObterAdicional_Deve_Obter()
        {
            //cenário
            var quantidade = 1;

            _mockProduto.Setup(x => x.Tamanho).Returns(_tamanho);

            _mockRepositorio.Setup(r => r.ObterAdicionais(_tamanho)).Returns(new List<Adicional> { new Adicional { Id = 1, Tamanho = _tamanho } });

            //Ação
            var produtos = _servico.ObterAdicionais(_mockProduto.Object.Tamanho);

            //Verificação
            _mockRepositorio.Verify(r => r.ObterAdicionais(_tamanho));
            produtos.Should().NotBeNull();
            produtos.First().Tamanho.Should().Be(_tamanho);
            produtos.Count().Should().Be(quantidade);
        }

        [Test]
        public void Produto_Aplicacao_ObterBebida_Deve_Obter()
        {
            //cenário
            _tamanho = TamanhoEnum.PADRAO;

            var quantidade = 1;

            _mockProduto.Setup(x => x.Tamanho).Returns(_tamanho);

            _mockRepositorio.Setup(r => r.ObterBebidas()).Returns(new List<Bebida> { new Bebida { Id = 1, Tamanho = _tamanho } });

            //Ação
            var produtos = _servico.ObterBebidas();

            //Verificação
            _mockRepositorio.Verify(r => r.ObterBebidas());
            produtos.Should().NotBeNull();
            produtos.First().Tamanho.Should().Be(_tamanho);
            produtos.Count().Should().Be(quantidade);
        }

        [Test]
        public void Produto_Aplicacao_AdicionarItens_Deve_Adicionar()
        {
            //cenário
            List<Produto> produtos = new List<Produto>();

            produtos.Add(ObjetoMae.ObterBebida());

            _mockRepositorio.Setup(r => r.Salvar(produtos.First())).Returns(produtos.First());

            //Ação
            var adicionados = _servico.AdicionarItens(produtos);

            //Verificação
            _mockRepositorio.Verify(r => r.Salvar(produtos.First()));
            adicionados.Count.Should().Be(produtos.Count);
        }
    }
}
