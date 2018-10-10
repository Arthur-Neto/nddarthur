using Effort;
using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Common.Tests.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
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
    //[TestFixture]
    //public class NotaFiscalRepositorioSqlTeste : EffortTestBase
    //{
    //    private FakeDbContext _fakeDbContext;
    //    private INotaFiscalRepositorio _repositorio;

    //    private NotaFiscal _notaFiscalValida;

    //    [SetUp]
    //    public void IniciarCenario()
    //    {
    //        var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
    //        _fakeDbContext = new FakeDbContext(connection);
    //        _repositorio = new NotaFiscalRepositorioSql(_fakeDbContext);


    //        long idEmitenteCadastradoPorBaseSql = 1;
    //        long idDestinatarioCadastradoPorBaseSql = 1;
    //        long idTransportadorCadastradoPorBaseSql = 1;

    //        _notaFiscalValida = ObjectMother.PegarNotaFiscalValidaComIdDasDependencias(idEmitenteCadastradoPorBaseSql, idDestinatarioCadastradoPorBaseSql, idTransportadorCadastradoPorBaseSql);
    //    }

    //    [Test]
    //    public void NotaFiscal_InfraData_Adicionar_Sucesso()
    //    {
    //        NotaFiscal notaFiscalAdicionada = _repositorio.Adicionar(_notaFiscalValida);

    //        notaFiscalAdicionada.Id.Should().BeGreaterThan(0);
    //    }

    //    [Test]
    //    public void NotaFiscal_InfraData_Atualizar_Sucesso()
    //    {
    //        NotaFiscal notaFiscalParaAtualizar = _notaFiscalValida;
    //        notaFiscalParaAtualizar.Id = 1;

    //        string naturezaOperacaoSobrescrita = notaFiscalParaAtualizar.NaturezaOperacao;

    //        notaFiscalParaAtualizar.NaturezaOperacao = "Atualizada";

    //        _repositorio.Atualizar(notaFiscalParaAtualizar);

    //        NotaFiscal notaFiscalBuscada = _repositorio.BuscarPorId(notaFiscalParaAtualizar.Id);

    //        notaFiscalBuscada.NaturezaOperacao.Should().Be(notaFiscalParaAtualizar.NaturezaOperacao);
    //        notaFiscalBuscada.NaturezaOperacao.Should().NotBe(naturezaOperacaoSobrescrita);

    //        notaFiscalBuscada.DataEntrada.Minute.Should().Be(notaFiscalParaAtualizar.DataEntrada.Minute);
    //    }

    //    [Test]
    //    public void NotaFiscal_InfraData_BuscarPorId_EntidadesComCNPJ_Sucesso()
    //    {
    //        NotaFiscal notaFiscalParaAdicionar = _notaFiscalValida;

    //        NotaFiscal notaFiscalAdicionada = _repositorio.Adicionar(notaFiscalParaAdicionar);

    //        NotaFiscal notaFiscalParaBuscar = _repositorio.BuscarPorId(notaFiscalAdicionada.Id);

    //        notaFiscalParaBuscar.Should().NotBeNull();
    //        notaFiscalParaBuscar.NaturezaOperacao.Should().Be(notaFiscalAdicionada.NaturezaOperacao);
    //        notaFiscalParaBuscar.DataEntrada.Minute.Should().Be(notaFiscalAdicionada.DataEntrada.Minute);
    //        notaFiscalParaBuscar.Destinatario.Id.Should().Be(notaFiscalAdicionada.Destinatario.Id);
    //        notaFiscalParaBuscar.Emitente.Id.Should().Be(notaFiscalAdicionada.Emitente.Id);
    //        notaFiscalParaBuscar.Transportador.Id.Should().Be(notaFiscalAdicionada.Transportador.Id);
    //    }

    //    [Test]
    //    public void NotaFiscal_InfraData_BuscarPorId_EntidadesComCPF_Sucesso()
    //    {
    //        long idEmitenteCadastradoPorBaseSql = 2;
    //        long idDestinatarioCadastradoPorBaseSql = 2;
    //        long idTransportadorCadastradoPorBaseSql = 2;
    //        _notaFiscalValida = ObjectMother.PegarNotaFiscalValidaComIdDasDependencias(idEmitenteCadastradoPorBaseSql, idDestinatarioCadastradoPorBaseSql, idTransportadorCadastradoPorBaseSql);

    //        NotaFiscal notaFiscalParaAdicionar = _notaFiscalValida;

    //        NotaFiscal notaFiscalAdicionada = _repositorio.Adicionar(notaFiscalParaAdicionar);

    //        NotaFiscal notaFiscalParaBuscar = _repositorio.BuscarPorId(notaFiscalAdicionada.Id);

    //        notaFiscalParaBuscar.Should().NotBeNull();
    //        notaFiscalParaBuscar.NaturezaOperacao.Should().Be(notaFiscalAdicionada.NaturezaOperacao);
    //        notaFiscalParaBuscar.DataEntrada.Minute.Should().Be(notaFiscalAdicionada.DataEntrada.Minute);
    //        notaFiscalParaBuscar.Destinatario.Id.Should().Be(notaFiscalAdicionada.Destinatario.Id);
    //        notaFiscalParaBuscar.Emitente.Id.Should().Be(notaFiscalAdicionada.Emitente.Id);
    //        notaFiscalParaBuscar.Transportador.Id.Should().Be(notaFiscalAdicionada.Transportador.Id);
    //    }

    //    [Test]
    //    public void NotaFiscal_InfraData_BuscarTodos_Sucesso()
    //    {
    //        IEnumerable<NotaFiscal> notasFiscaisBuscadas = _repositorio.BuscarTodos();

    //        notasFiscaisBuscadas.Should().NotBeNull();
    //        notasFiscaisBuscadas.Should().HaveCountGreaterOrEqualTo(1);
    //    }

    //    [Test]
    //    public void NotaFiscal_InfraData_Excluir_Sucesso()
    //    {
    //        NotaFiscal notaFiscalParaAdicionar = _notaFiscalValida;

    //        NotaFiscal notaFiscalAdicionada = _repositorio.Adicionar(notaFiscalParaAdicionar);

    //        NotaFiscal notaFiscalParaDeletar = notaFiscalAdicionada;

    //        _repositorio.Excluir(notaFiscalParaDeletar);

    //        NotaFiscal notaFiscalParaBuscar = _repositorio.BuscarPorId(notaFiscalParaDeletar.Id);

    //        notaFiscalParaBuscar.Should().BeNull();
    //    }
    //}
}
