using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Testes.Base;
using Pizzaria.Common.Testes.Features;
using Pizzaria.Dominio.Features.Produtos;
using Pizzaria.Infra.Data.Base;
using Pizzaria.Infra.Data.Features.Produtos;
using System.Data.Entity;
using System.Linq;

namespace Pizzaria.Infra.Data.Testes.Features.Produtos
{
    [TestFixture]
    public class ProdutoRepositorioTestes
    {
        PizzariaContext contexto;
        ProdutoRepositorio repositorio;
        Produto produto;

        [SetUp]
        public void SetUp()
        {
            contexto = new PizzariaContext();
            repositorio = new ProdutoRepositorio(contexto);
            produto = ObjetoMae.ObterPizza(TamanhoEnum.GRANDE);
            Database.SetInitializer(new BaseSqlTestes());
            contexto.Database.Initialize(true);
        }

        [Test]
        public void Produto_InfraData_Salvar_Deve_Inserir_Produto_Qualquer()
        {
            produto = repositorio.Salvar(produto);

            produto.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Produto_InfraData_ObterPorId_Deve_Obter_Produto()
        {
            produto.Id = 1;

            var novoProduto = repositorio.ObterPorId(produto.Id);

            novoProduto.Id.Should().Be(produto.Id);
        }

        [Test]
        public void Produto_InfraData_ObterTodos_Deve_Obter_Todos_Produtos()
        {
            produto.Id = 1;

            var produtos = repositorio.ObterTodos();

            produtos.First().Id.Should().Be(produto.Id);
            produtos.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Produto_InfraData_Deletar_Deve_Deletar_Produto()
        {
            produto = repositorio.Salvar(produto);

            repositorio.Deletar(produto);

            var deletado = repositorio.ObterPorId(produto.Id);

            deletado.Should().BeNull();
        }

        [Test]
        public void Produto_InfraData_Atualizar_Deve_Atualizar_Produto()
        {
            produto = repositorio.Salvar(produto);
            produto.Sabor = "calabresa";

            var atualizado = repositorio.Atualizar(produto);

            atualizado.Sabor.Should().Be(produto.Sabor);
        }

        [Test]
        public void Produto_InfraData_ObterAdicionais_Deve_Obter_Adicionais()
        {
            produto = ObjetoMae.ObterAdicional(TamanhoEnum.GRANDE);

            produto = repositorio.Salvar(produto);

            var adicionais = repositorio.ObterAdicionais(produto.Tamanho);

            adicionais.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Produto_InfraData_ObterBebidas_Deve_Obter_Adicionais()
        {
            produto = ObjetoMae.ObterBebida();

            produto = repositorio.Salvar(produto);

            var bebidas = repositorio.ObterBebidas();

            bebidas.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Produto_InfraData_ObterCalzones_Deve_Obter_Calzones()
        {
            produto = ObjetoMae.ObterCalzone(TamanhoEnum.GRANDE);

            produto = repositorio.Salvar(produto);

            var calzones = repositorio.ObterCalzones(produto.Tamanho);

            calzones.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Produto_InfraData_ObterPizzas_Deve_Obter_Pizzas()
        {
            produto = ObjetoMae.ObterPizza(TamanhoEnum.GRANDE);

            produto = repositorio.Salvar(produto);

            var pizzas = repositorio.ObterPizzas(produto.Tamanho);

            pizzas.Count().Should().BeGreaterThan(0);
        }
    }
}
