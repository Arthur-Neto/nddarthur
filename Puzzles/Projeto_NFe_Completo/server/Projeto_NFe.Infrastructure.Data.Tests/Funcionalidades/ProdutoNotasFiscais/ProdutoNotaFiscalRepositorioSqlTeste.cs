using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Infrastructure.Data.Tests.Inicializador;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_NFe.Infrastructure.Data.Tests.Funcionalidades.ProdutoNotasFiscais
{
    [TestFixture]
    public class ProdutoNotaFiscalRepositorioSqlTeste : EffortTestBase
    {

        //private IProdutoNotaFiscalRepositorio _repositorio;
        //Mock<Produto> _mockProduto;
        //Mock<NotaFiscal> _mockNotaFiscal;

        //[SetUp]
        //public void IniciarCenario()
        //{
        //    _repositorio = new ProdutoNotaFiscalRepositorioSql();

        //    _mockProduto = new Mock<Produto>();
        //    _mockNotaFiscal = new Mock<NotaFiscal>();
        //}

        //[Test]
        //public void ProdutoNotaFiscal_InfraData_Adicionar_Sucesso()
        //{
        //    ProdutoNotaFiscal produtoNotaFiscalValido = ObjectMother.PegarProdutoNotaFiscalValido(_mockProduto.Object, _mockNotaFiscal.Object);

        //    long idDeProdutoCadastrado = 1;
        //    long idDeNotaFiscalCadastrada = 1;

        //    _mockProduto.Setup(mp => mp.Id).Returns(idDeProdutoCadastrado);
        //    _mockNotaFiscal.Setup(mnf => mnf.Id).Returns(idDeNotaFiscalCadastrada);

        //    ProdutoNotaFiscal produtoNotaFiscalAdicionado = _repositorio.Adicionar(produtoNotaFiscalValido);

        //    produtoNotaFiscalAdicionado.Id.Should().BeGreaterThan(0);
        //}

        //[Test]
        //public void ProdutoNotaFiscal_InfraData_BuscarPorId_Sucesso()
        //{
        //    ProdutoNotaFiscal produtoNotaFiscalValido = ObjectMother.PegarProdutoNotaFiscalValido(_mockProduto.Object, _mockNotaFiscal.Object);

        //    long idDeProdutoCadastrado = 1;
        //    long idDeNotaFiscalCadastrada = 1;

        //    double valorDoProdutoDeId1NoBanco = 100;

        //    _mockProduto.Setup(mp => mp.Id).Returns(idDeProdutoCadastrado);
        //    _mockNotaFiscal.Setup(mnf => mnf.Id).Returns(idDeNotaFiscalCadastrada);



        //    ProdutoNotaFiscal produtoNotaFiscalAdicionado = _repositorio.Adicionar(produtoNotaFiscalValido);

        //    ProdutoNotaFiscal produtoNotaFiscalBuscado = _repositorio.BuscarPorId(produtoNotaFiscalAdicionado.Id);

        //    produtoNotaFiscalBuscado.Produto.Valor.Should().Be(valorDoProdutoDeId1NoBanco);
        //    produtoNotaFiscalBuscado.Quantidade.Should().Be(produtoNotaFiscalAdicionado.Quantidade);
        //}

        //[Test]
        //public void ProdutoNotaFiscal_InfraData_BuscarTodos_Sucesso()
        //{
        //    IEnumerable<ProdutoNotaFiscal> listaProdutoNotaFiscal = _repositorio.BuscarTodos();

        //    listaProdutoNotaFiscal.Should().NotBeNull();
        //    listaProdutoNotaFiscal.Count().Should().Be(1);

        //}

        //[Test]
        //public void ProdutoNotaFiscal_InfraData_Atualizar_Sucesso()
        //{
        //    long idDoProdutoNotaFiscalDaBaseSql = 1;

        //    ProdutoNotaFiscal produtoNotaFiscalResultadoDoBuscarParaAtualizar = _repositorio.BuscarPorId(idDoProdutoNotaFiscalDaBaseSql);

        //    produtoNotaFiscalResultadoDoBuscarParaAtualizar.Quantidade += 1;

        //    _repositorio.Atualizar(produtoNotaFiscalResultadoDoBuscarParaAtualizar);

        //    ProdutoNotaFiscal produtoNotaFiscalResultadoAposAtualizacao = _repositorio.BuscarPorId(produtoNotaFiscalResultadoDoBuscarParaAtualizar.Id);

        //    produtoNotaFiscalResultadoAposAtualizacao.Quantidade.Should().Be(produtoNotaFiscalResultadoDoBuscarParaAtualizar.Quantidade);
        //}

        //[Test]
        //public void ProdutoNotaFiscal_InfraData_Excluir_Sucesso()
        //{
        //    ProdutoNotaFiscal produtoNotaFiscalValido = ObjectMother.PegarProdutoNotaFiscalValido(_mockProduto.Object, _mockNotaFiscal.Object);

        //    long idDeProdutoCadastrado = 1;
        //    long idDeNotaFiscalCadastrada = 1;

        //    _mockProduto.Setup(mp => mp.Id).Returns(idDeProdutoCadastrado);
        //    _mockNotaFiscal.Setup(mnf => mnf.Id).Returns(idDeNotaFiscalCadastrada);

        //    ProdutoNotaFiscal produtoNotaFiscalAdicionado = _repositorio.Adicionar(produtoNotaFiscalValido);

        //    _repositorio.Excluir(produtoNotaFiscalAdicionado);

        //    ProdutoNotaFiscal produtoBuscado = _repositorio.BuscarPorId(produtoNotaFiscalAdicionado.Id);

        //    produtoBuscado.Should().BeNull();
        //}
    }
}
