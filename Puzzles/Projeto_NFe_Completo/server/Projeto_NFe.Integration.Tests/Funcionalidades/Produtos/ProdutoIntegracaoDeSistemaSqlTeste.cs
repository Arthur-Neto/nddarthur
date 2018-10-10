using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Produtos;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Infrastructure.Data.Base;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integration.Tests.Funcionalidades.Produtos
{
    [TestFixture]
    public class ProdutoIntegracaoDeSistemaSqlTeste
    {
        //    ProjetoNFeContexto _projetoNFeContexto;
        //    IProdutoServico _servicoProduto;
        //    IProdutoRepositorio _repositorioSqlProduto;

        //    [SetUp]
        //    public void IniciarCenario()
        //    {
        //        _projetoNFeContexto = new ProjetoNFeContexto();
        //        _repositorioSqlProduto = new ProdutoRepositorioSql(_projetoNFeContexto);
        //        _servicoProduto = new ProdutoServico(_repositorioSqlProduto);
        //    }

        //    [Test]
        //    public void Produto_IntegracaoDeSistema_Sql_Adicionar_Sucesso()
        //    {
        //        Produto produto = ObjectMother.ObterProdutoValido();

        //        Produto produtoAdicionado = _servicoProduto.Adicionar(produto);

        //        produtoAdicionado.Id.Should().BeGreaterOrEqualTo(1);
        //    }

        //    [Test]
        //    public void Produto_IntegracaoDeSistema_Sql_Atualizar_Sucesso()
        //    {
        //        Produto produto = ObjectMother.ObterProdutoValido();
        //        produto.Id = 1;

        //        _servicoProduto.Atualizar(produto);

        //        Produto produtoAtualizado = _servicoProduto.BuscarPorId(produto.Id);

        //        produtoAtualizado.Should().NotBeNull();
        //        produtoAtualizado.Descricao.Should().Be(produto.Descricao);
        //    }

        //    [Test]
        //    public void Produto_IntegracaoDeSistema_Sql_Atualizar_ExcecaoIdentificadorIndefinido_Falha()
        //    {
        //        Produto produto = ObjectMother.ObterProdutoValido();
        //        produto.Id = 0;

        //        Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoProduto.Atualizar(produto);

        //        acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoNaoEncontrado>();
        //    }

        //    [Test]
        //    public void Produto_IntegracaoDeSistema_Sql_BuscarPorId_Sucesso()
        //    {
        //        Produto produtoParaAdicionar = ObjectMother.ObterProdutoValido();

        //        Produto produtoAdicionado = _servicoProduto.Adicionar(produtoParaAdicionar);

        //        Produto produtoBuscado = _servicoProduto.BuscarPorId(produtoAdicionado.Id);

        //        produtoBuscado.Descricao.Should().Be(produtoAdicionado.Descricao);
        //        produtoBuscado.Codigo.Should().Be(produtoAdicionado.Codigo);
        //        produtoBuscado.Valor.Should().Be(produtoAdicionado.Valor);

        //    }

        //    [Test]
        //    public void Produto_IntegracaoDeSistema_Sql_BuscarPorId_ExcecaoIdentificadorIndefinido_Falha()
        //    {
        //        Produto produtoParaBuscar = ObjectMother.ObterProdutoValido();
        //        produtoParaBuscar.Id = 0;

        //        Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoProduto.BuscarPorId(produtoParaBuscar.Id);

        //        acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoNaoEncontrado>();
        //    }

        //    [Test]
        //    public void Produto_IntegracaoDeSistema_Sql_BuscarTodos_Sucesso()
        //    {
        //        int quantidadeDeProdutosAdicionadosPeloBaseSql = 1;

        //        Produto produtoParaAdicionar = ObjectMother.ObterProdutoValido();

        //        _servicoProduto.Adicionar(produtoParaAdicionar);

        //        IEnumerable<Produto> listaDeProdutos = _servicoProduto.BuscarTodos();

        //        listaDeProdutos.Should().HaveCountGreaterOrEqualTo(1 + quantidadeDeProdutosAdicionadosPeloBaseSql);
        //    }

        //    [Test]
        //    public void Produto_IntegracaoDeSistema_Sql_Excluir_Sucesso()
        //    {
        //        Produto produtoParaAdicionar = ObjectMother.ObterProdutoValido();

        //        Produto produtoAdicionado = _servicoProduto.Adicionar(produtoParaAdicionar);

        //        _servicoProduto.Excluir(produtoAdicionado);

        //        Produto produtoBuscadoAposExclusao = _servicoProduto.BuscarPorId(produtoAdicionado.Id);

        //        produtoBuscadoAposExclusao.Should().BeNull();

        //    }

        //    [Test]
        //    public void Produto_IntegracaoDeSistema_Sql_Excluir_ExcecaoIdentificadorIndefinido_Falha()
        //    {
        //        Produto produtoParaAdicionar = ObjectMother.ObterProdutoValido();

        //        Produto produtoAdicionado = _servicoProduto.Adicionar(produtoParaAdicionar);
        //        produtoAdicionado.Id = 0;

        //        Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoProduto.Excluir(produtoAdicionado);

        //        acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoNaoEncontrado>();
        //    }

    }
}
