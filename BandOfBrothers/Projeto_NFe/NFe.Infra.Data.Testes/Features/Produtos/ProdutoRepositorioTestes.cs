using FluentAssertions;
using NFe.Common.Testes.Base;
using NFe.Common.Testes.Features;
using NFe.Dominio.Features.Produtos;
using NFe.Infra.Data.Features.Produtos;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;


namespace NFe.Infra.Data.Testes.Features.Produtos
{
    [TestFixture]
    public class ProdutoRepositorioTestes
    {
        IProdutoRepositorio repositorio;
        Produto produto;

        [SetUp]
        public void SetUp()
        {
            BaseSqlTest.SeedDatabase();
            repositorio = new ProdutoRepositorio();
            produto = new Produto();
        }

        [Test]
        public void Produto_InfraData_Salvar_DeveInserirOK()
        {
            produto = ObjectMother.ObtemProdutoValido();
            var idEsperado = 2;

            Produto _produtoInserido = repositorio.Salvar(produto);

            _produtoInserido.Id.Should().Be(idEsperado);
        }

        [Test]
        public void Produto_InfraData_Atualizar_DeveAtualizarOk()
        {
            produto = ObjectMother.ObtemProdutoValido();
            produto = repositorio.Salvar(produto);
            var _novoNome = "Feijao";
            produto.Descricao = _novoNome;

            Produto _produtoAtualizado = repositorio.Atualizar(produto);

            _produtoAtualizado.Descricao.Should().Be(_novoNome);
        }

        [Test]
        public void Produto_InfraData_PegarTodos_DevePegarTodos()
        {
            produto = ObjectMother.ObtemProdutoValido();
            produto = repositorio.Salvar(produto);

            IEnumerable<Produto> produtos = repositorio.PegarTodos();

            produtos.Count().Should().BeGreaterThan(0);
            produtos.Last().Id.Should().Be(produto.Id);
        }

        [Test]
        public void Produto_InfraData_Salvar_DeveDeletar()
        {
            produto = ObjectMother.ObtemProdutoValido();
            produto = repositorio.Salvar(produto);

            repositorio.Deletar(produto);

            Produto _produtoEncontrado = repositorio.PegarPorId(produto.Id);
            _produtoEncontrado.Should().BeNull();
        }
    }
}
