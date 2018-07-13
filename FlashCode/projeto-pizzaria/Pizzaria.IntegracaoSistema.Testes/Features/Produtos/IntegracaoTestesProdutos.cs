using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Aplicacao.Features.Produtos;
using Pizzaria.Common.Testes.Base;
using Pizzaria.Common.Testes.Features;
using Pizzaria.Dominio.Features.Produtos;
using Pizzaria.Dominio.Features.Produtos.Excecoes;
using Pizzaria.Infra.Data.Base;
using Pizzaria.Infra.Data.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.IntegracaoSistema.Testes.Features.Produtos
{
    [TestFixture]
    public class IntegracaoTestesProdutos
    {
        IProdutoRepositorio _produtoRepositorio;
        IProdutoServico _produtoServico;
        Produto _produto;
        PizzariaContext _context;
        TamanhoEnum _tamanho;
        [SetUp]
        public void SetUp()
        {
            _tamanho = TamanhoEnum.GRANDE;
            _produto = ObjetoMae.ObterBebida();
            _context = new PizzariaContext();
            _produtoRepositorio = new ProdutoRepositorio(_context);
            _produtoServico = new ProdutoServico(_produtoRepositorio);
            Database.SetInitializer(new BaseSqlTestes());
            _context.Database.Initialize(true);
        }

        [Test]
        public void Produto_Integracao_Adicionar_Deve_Adicionar()
        {
            //Cenário

            //Ação
            var produto = _produtoServico.Adicionar(_produto);

            //Verificação
            var pedidoBuscado = _produtoServico.ObterPorId(produto.Id);
            produto.Id.Should().Be(pedidoBuscado.Id);
            produto.Tamanho.Should().Be(pedidoBuscado.Tamanho);
            produto.Tamanho.Should().Be(_produto.Tamanho);
        }

        [Test]
        public void Produto_Integracao_ObterTodos_Deve_obter()
        {
            //Cenário
            var id = 1;

            //Ação
            var produtos = _produtoServico.ObterTodos();

            //Verificação
            produtos.First().Id.Should().Be(id);
            produtos.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Produto_Integracao_ObterPorID_Deve_Obter()
        {
            //Cenário
            var id = 1;

            //Ação
            var produto = _produtoServico.ObterPorId(id);

            //Verificação
            produto.Id.Should().Be(id);
            produto.Should().NotBeNull();
        }

        [Test]
        public void Produto_Integracao_ObterAdicionais_Deve_Obter()
        {
            //Cenário
            var produto = _produtoServico.Adicionar(ObjetoMae.ObterAdicional(_tamanho));

            //Ação
            var produtos = _produtoServico.ObterAdicionais(produto.Tamanho);

            //Verificação
            produtos.First().Tamanho.Should().Be(_tamanho);
            produtos.Count().Should().BeGreaterThan(0);
        }
        [Test]
        public void Produto_Integracao_ObterPizzas_Deve_Obter()
        {
            //Cenário
            var produto = _produtoServico.Adicionar(ObjetoMae.ObterPizza(_tamanho));

            //Ação
            var produtos = _produtoServico.ObterPizzas(produto.Tamanho);

            //Verificação
            produtos.First().Tamanho.Should().Be(_tamanho);
            produtos.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Produto_Integracao_ObterCalzones_Deve_Obter()
        {
            //Cenário
            _tamanho = TamanhoEnum.PADRAO;

            var produto = _produtoServico.Adicionar(ObjetoMae.ObterCalzone(_tamanho));
            //Ação
            var produtos = _produtoServico.ObterCalzones(_tamanho);

            //Verificação
            produtos.First().Tamanho.Should().Be(_tamanho);
            produtos.Count().Should().BeGreaterThan(0);
        }
        [Test]
        public void Produto_Integracao_ObterBebidas_Deve_Obter()
        {
            //Cenário
            _tamanho = TamanhoEnum.PADRAO;

            var produto = _produtoServico.Adicionar(ObjetoMae.ObterBebida());
            //Ação
            var produtos = _produtoServico.ObterBebidas();

            //Verificação
            produtos.First().Tamanho.Should().Be(_tamanho);
            produtos.Count().Should().BeGreaterThan(0);
        }
        [Test]
        public void Produto_Integracao_AdicionarItens_Deve_Adicionar()
        {
            //Cenário
            var quantidade = 1;
            var lista = new List<Produto>();
            lista.Add(_produto);

            //Ação
            var listaAdicionada = _produtoServico.AdicionarItens(lista);

            //Verificação
            listaAdicionada.Count.Should().Be(quantidade);
        }

        [Test]
        public void Produto_Integracao_Atualizar_DeveAtualizar()
        {
            //Cenário
            var produto = _produtoServico.Adicionar(_produto);
            produto.Tamanho = TamanhoEnum.GRANDE;

            //Ação
            var produtoEditado = _produtoServico.Atualizar(produto);

            //Verificação
            var pedidoBuscado = _produtoServico.ObterPorId(produtoEditado.Id);
            pedidoBuscado.Id.Should().Be(produtoEditado.Id);
            produtoEditado.Should().NotBeNull();
            produtoEditado.Tamanho.Should().Be(produto.Tamanho);
        }
        [Test]
        public void Produto_Integracao_Excluir_Deve_Excluir()
        {
            //Cenário
            var produto = _produtoServico.Adicionar(_produto);

            //Ação
            _produtoServico.Excluir(produto);

            //Verificação
            var pedidoBuscado = _produtoServico.ObterPorId(produto.Id);
            pedidoBuscado.Should().BeNull();
        }

        [Test]
        public void Produto_Integracao_Adicionar_TamanhoInvalido_Deve_Lancar_Excecao()
        {
            //Cenário
            _produto.Tamanho = 0;

            //Ação
            Action action = () => _produtoServico.Adicionar(_produto);

            //Verificação
            action.Should().Throw<TamanhoInvalidoExcecao>();

        }
    }
}
