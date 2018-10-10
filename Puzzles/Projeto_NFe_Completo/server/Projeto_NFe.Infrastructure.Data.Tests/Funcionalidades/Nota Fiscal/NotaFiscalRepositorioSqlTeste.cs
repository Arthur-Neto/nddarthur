using Effort;
using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Common.Tests.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Infrastructure.Data.Tests.Context;
using Projeto_NFe.Infrastructure.Data.Tests.Inicializador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Tests.Funcionalidades.Nota_Fiscal
{
    [TestFixture]
    public class NotaFiscalRepositorioSqlTeste : EffortTestBase
    {
        private FakeDbContext _fakeDbContext;
        private INotaFiscalRepositorio _repositorio;

        [SetUp]
        public void IniciarCenario()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _fakeDbContext = new FakeDbContext(connection);
            _repositorio = new NotaFiscalRepositorioSql(_fakeDbContext);

            SementeBaseSQL semeador = new SementeBaseSQL(_fakeDbContext);
            semeador.Semear();
        }

        [Test]
        public void NotaFiscal_InfraData_Adicionar_Sucesso()
        {
            Destinatario destinatario = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();
            Emitente emitente = ObjectMother.PegarEmitenteValidoSemDependencias();
            Transportador transportador = ObjectMother.PegarTransportadorValidoSemDependencias();

            NotaFiscal notaFiscal = ObjectMother.PegarNotaFiscalValida(emitente, destinatario, transportador);

           _repositorio.Adicionar(notaFiscal);

            notaFiscal.Id.Should().BeGreaterThan(0);

            NotaFiscal notaFiscalResultadoDoGet = _repositorio.BuscarPorId(notaFiscal.Id);

            notaFiscalResultadoDoGet.NaturezaOperacao.Should().Be(notaFiscal.NaturezaOperacao);

        }

        [Test]
        public void NotaFiscal_InfraData_Atualizar_Sucesso()
        {
            long idDaNotaFiscalDaBaseSql = 1;

            NotaFiscal notaFiscalResultadoDoBuscarParaAtualizar = _repositorio.BuscarPorId(idDaNotaFiscalDaBaseSql);

            notaFiscalResultadoDoBuscarParaAtualizar.NaturezaOperacao = "Alterado";

            _repositorio.Atualizar(notaFiscalResultadoDoBuscarParaAtualizar);

            NotaFiscal resultado = _repositorio.BuscarPorId(notaFiscalResultadoDoBuscarParaAtualizar.Id);

            resultado.NaturezaOperacao.Should().Be(notaFiscalResultadoDoBuscarParaAtualizar.NaturezaOperacao);

        }

        [Test]
        public void NotaFiscal_InfraData_BuscarPorId_Sucesso()
        {

            long idDaNotaFiscalDaBaseSql = 1;

            NotaFiscal notaFiscalDaBaseSql = _repositorio.BuscarPorId(idDaNotaFiscalDaBaseSql);

            notaFiscalDaBaseSql.Should().NotBeNull();
        }

        [Test]
        public void NotaFiscal_InfraData_BuscarTodos_Sucesso()
        {
            IEnumerable<NotaFiscal> notasFiscaisBuscadas = _repositorio.BuscarTodos();

            notasFiscaisBuscadas.Should().NotBeNull();
            notasFiscaisBuscadas.Should().HaveCountGreaterOrEqualTo(1);
        }

        [Test]
        public void NotaFiscal_InfraData_Excluir_Sucesso()
        {
            long idDaNotaFiscalDaBaseSql = 1;

            NotaFiscal notaFiscalBuscadaParaDeletar = _repositorio.BuscarPorId(idDaNotaFiscalDaBaseSql);

            _repositorio.Excluir(notaFiscalBuscadaParaDeletar);

            NotaFiscal notaFiscalParaBuscar = _repositorio.BuscarPorId(notaFiscalBuscadaParaDeletar.Id);

            notaFiscalParaBuscar.Should().BeNull();
        }
    }
}
