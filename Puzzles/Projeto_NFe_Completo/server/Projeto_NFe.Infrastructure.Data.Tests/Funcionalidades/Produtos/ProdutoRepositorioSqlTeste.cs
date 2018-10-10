using Effort;
using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Produtos;
using Projeto_NFe.Infrastructure.Data.Tests.Context;
using Projeto_NFe.Infrastructure.Data.Tests.Inicializador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Tests.Funcionalidades.Produtos
{
    [TestFixture]
    public class ProdutoRepositorioSqlTeste : EffortTestBase
    {
        private FakeDbContext _fakeDbContext;
        private IProdutoRepositorio _repositorio;

        [SetUp]
        public void IniciarCenario()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _fakeDbContext = new FakeDbContext(connection);
            _fakeDbContext.Database.Initialize(true);
            _repositorio = new ProdutoRepositorioSql(_fakeDbContext);

            SementeBaseSQL semeador = new SementeBaseSQL(_fakeDbContext);
            semeador.Semear();
        }

        [Test]
        public void Produto_InfraData_Adicionar_Sucesso()
        {
            Produto produto = ObjectMother.ObterProdutoValido();

            _repositorio.Adicionar(produto);

            produto.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Produto_InfraData_Atualizar_Sucesso()
        {
            long idDoProdutoDaBaseSql = 1;

            Produto produtoResultadoDoBuscarParaAtualizar = _repositorio.BuscarPorId(idDoProdutoDaBaseSql);

            produtoResultadoDoBuscarParaAtualizar.Descricao = "Atualizado";

            _repositorio.Atualizar(produtoResultadoDoBuscarParaAtualizar);

            Produto resultado = _repositorio.BuscarPorId(produtoResultadoDoBuscarParaAtualizar.Id);

            resultado.Descricao.Should().Be(produtoResultadoDoBuscarParaAtualizar.Descricao);
            resultado.Codigo.Should().Be(produtoResultadoDoBuscarParaAtualizar.Codigo);
        }

        [Test]
        public void Produto_InfraData_Excluir_Sucesso()
        {
            long idDoProdutoDaBaseSql = 1;

            Produto produtoResultadoDoBuscar = _repositorio.BuscarPorId(idDoProdutoDaBaseSql);

            _repositorio.Excluir(produtoResultadoDoBuscar);

            Produto produtoQueDeveSerNullo = _repositorio.BuscarPorId(produtoResultadoDoBuscar.Id);

            produtoQueDeveSerNullo.Should().BeNull();
        }

        [Test]
        public void Produto_InfraData_BuscarPorId_Sucesso()
        {
            long idDoProdutoDaBaseSql = 1;

            Produto produtoDaBaseSql = _repositorio.BuscarPorId(idDoProdutoDaBaseSql);

            produtoDaBaseSql.Should().NotBeNull();
        }

        [Test]
        public void Produto_InfraData_BuscarTodos_Sucesso()
        {
            int numeroDeProdutosPreCadastrados = 2;

            Produto produtoValido = ObjectMother.ObterProdutoValido();

            //Adicionando varios produtos vinculados ao mesmo endereco (Só para teste)
            long idProdutoAdicionado1 = _repositorio.Adicionar(produtoValido);
            long idProdutoAdicionado2 = _repositorio.Adicionar(produtoValido);
            long idProdutoAdicionado3 = _repositorio.Adicionar(produtoValido);
            long idProdutoAdicionado4 = _repositorio.Adicionar(produtoValido);

            int numeroDeProdutosCadastradosNesteTeste = 4;

            IEnumerable<Produto> produtosResultadoDoBuscarTodos = _repositorio.BuscarTodos();

            produtosResultadoDoBuscarTodos.Count().Should().Be(numeroDeProdutosCadastradosNesteTeste + numeroDeProdutosPreCadastrados);

        }
    }
}
