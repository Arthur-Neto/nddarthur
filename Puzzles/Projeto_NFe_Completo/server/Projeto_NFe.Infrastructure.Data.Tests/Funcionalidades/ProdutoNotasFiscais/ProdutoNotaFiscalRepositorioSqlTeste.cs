using Effort;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Infrastructure.Data.Tests.Context;
using Projeto_NFe.Infrastructure.Data.Tests.Inicializador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Tests.Funcionalidades.ProdutoNotasFiscais
{
    [TestFixture]
    public class ProdutoNotaFiscalRepositorioSqlTeste : EffortTestBase
    {
        private FakeDbContext _fakeDbContext;
        private IProdutoNotaFiscalRepositorio _repositorio;

        [SetUp]
        public void IniciarCenario()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _fakeDbContext = new FakeDbContext(connection);
            _fakeDbContext.Database.Initialize(true);
            _repositorio = new ProdutoNotaFiscalRepositorioSql(_fakeDbContext);

            SementeBaseSQL semeador = new SementeBaseSQL(_fakeDbContext);
            semeador.Semear();
        }

        [Test]
        public void ProdutoNotaFiscal_InfraData_Adicionar_Sucesso()
        {
            long idDaNotaFiscalPreCadastrada = 1;

            NotaFiscalRepositorioSql repositorioNF = new NotaFiscalRepositorioSql(_fakeDbContext);
            NotaFiscal nf = repositorioNF.BuscarPorId(idDaNotaFiscalPreCadastrada);
            ProdutoNotaFiscal produtoDaNF = nf.Produtos.First();
            Produto produto = produtoDaNF.Produto;
            
            ProdutoNotaFiscal produtoNotaFiscalValido = ObjectMother.PegarProdutoNotaFiscalValido(produto, nf);

            _repositorio.Adicionar(produtoNotaFiscalValido);

            produtoNotaFiscalValido.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void ProdutoNotaFiscal_InfraData_BuscarPorId_Sucesso()
        {
            long idDaNotaFiscalPreCadastrada = 1;

            ProdutoNotaFiscal produtoNotaFiscalBuscado = _repositorio.BuscarPorId(idDaNotaFiscalPreCadastrada);

            produtoNotaFiscalBuscado.Should().NotBeNull();
        }

        [Test]
        public void ProdutoNotaFiscal_InfraData_BuscarTodos_Sucesso()
        {
            IEnumerable<ProdutoNotaFiscal> listaProdutoNotaFiscal = _repositorio.BuscarTodos();

            listaProdutoNotaFiscal.Should().NotBeNull();
            listaProdutoNotaFiscal.Count().Should().Be(1);

        }

        [Test]
        public void ProdutoNotaFiscal_InfraData_Atualizar_Sucesso()
        {
            long idDoProdutoNotaFiscalDaBaseSql = 1;

            ProdutoNotaFiscal produtoNotaFiscalResultadoDoBuscarParaAtualizar = _repositorio.BuscarPorId(idDoProdutoNotaFiscalDaBaseSql);

            produtoNotaFiscalResultadoDoBuscarParaAtualizar.Quantidade += 1;

            _repositorio.Atualizar(produtoNotaFiscalResultadoDoBuscarParaAtualizar);

            ProdutoNotaFiscal produtoNotaFiscalResultadoAposAtualizacao = _repositorio.BuscarPorId(produtoNotaFiscalResultadoDoBuscarParaAtualizar.Id);

            produtoNotaFiscalResultadoAposAtualizacao.Quantidade.Should().Be(produtoNotaFiscalResultadoDoBuscarParaAtualizar.Quantidade);
        }

        [Test]
        public void ProdutoNotaFiscal_InfraData_Excluir_Sucesso()
        {
            long idDaNotaFiscalPreCadastrada = 1;

            ProdutoNotaFiscal produtoNotaFiscalBuscado = _repositorio.BuscarPorId(idDaNotaFiscalPreCadastrada);

            _repositorio.Excluir(produtoNotaFiscalBuscado);

            ProdutoNotaFiscal produtoNotaFiscalQueDeveSerNulo = _repositorio.BuscarPorId(idDaNotaFiscalPreCadastrada);

            produtoNotaFiscalQueDeveSerNulo.Should().BeNull();
        }
    }
}
