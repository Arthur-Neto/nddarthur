using Effort;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Destinatarios;
using Projeto_NFe.Infrastructure.Data.Tests.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Tests.Funcionalidades.Destinatarios
{
    //[TestFixture]
    //public class DestinatarioRepositorioSqlTeste
    //{
    //    private FakeDbContext _fakeDbContext;
    //    private IDestinatarioRepositorio _repositorio;
    //    private Endereco _endereco;


    //    [SetUp]
    //    public void IniciarCenario()
    //    {
    //        var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
    //        _fakeDbContext = new FakeDbContext(connection);
    //        _repositorio = new DestinatarioRepositorioSql(_fakeDbContext);

    //        _endereco = new Endereco();

    //        System.Data.Entity.Database.SetInitializer(new BaseSqlTeste());
    //    }

    //    [Test]
    //    public void Destinatario_InfraData_Adicionar_ComCPF_Sucesso()
    //    {
    //        //long idDoEnderecoDaBaseSql = 2;

    //        Destinatario destinatarioValido = ObjectMother.PegarDestinatarioValidoComCPF();

    //        //destinatarioValido.Id = 0;
    //        //destinatarioValido.Endereco.Id = idDoEnderecoDaBaseSql;

    //        Destinatario destinatarioAdicionado = _repositorio.Adicionar(destinatarioValido);

    //        destinatarioAdicionado.Id.Should().BeGreaterThan(0);

    //        Destinatario destinatarioResultadoDoGet = _repositorio.BuscarPorId(destinatarioAdicionado.Id);

    //        destinatarioResultadoDoGet.NomeRazaoSocial.Should().Be(destinatarioAdicionado.NomeRazaoSocial);
    //        destinatarioResultadoDoGet.Endereco.Pais.Should().Be(destinatarioAdicionado.Endereco.Pais);
    //    }

    //    [Test]
    //    public void Destinatario_InfraData_Adicionar_ComCNPJ_Sucesso()
    //    {
    //        long idDoEnderecoDaBaseSql = 2;

    //        Destinatario destinatarioValido = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();

    //        destinatarioValido.Id = 0;
    //        destinatarioValido.Endereco.Id = idDoEnderecoDaBaseSql;

    //        Destinatario destinatarioAdicionado = _repositorio.Adicionar(destinatarioValido);

    //        destinatarioAdicionado.Id.Should().BeGreaterThan(0);
    //    }

    //    [Test]
    //    public void Destinatario_InfraData_BuscarPorId_Sucesso()
    //    {

    //        Destinatario destinatario = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();
    //        destinatario.Id = 1;           

    //        destinatario = _repositorio.Adicionar(destinatario);

    //        Destinatario destinatarioResultadoDoBuscar = _repositorio.BuscarPorId(destinatario.Id);

    //        destinatarioResultadoDoBuscar.Should().NotBeNull();
            
    //    }

    //    [Test]
    //    public void Destinatario_InfraData_BuscarPorId_DestinatarioDaBaseSql_Sucesso()
    //    {
    //        long idDoDestinatarioDaBaseSql = 1;

    //        Destinatario destinatarioDaBaseSql = _repositorio.BuscarPorId(idDoDestinatarioDaBaseSql);

    //        destinatarioDaBaseSql.Should().NotBeNull();
    //        destinatarioDaBaseSql.Documento.Tipo.Should().Be(TipoDocumento.CNPJ);
    //    }

    //    [Test]
    //    public void Destinatario_InfraData_BuscarTodos_Sucesso()
    //    {
    //        long idDoEnderecoDaBaseSql = 2;

    //        Destinatario destinatarioValido = ObjectMother.PegarDestinatarioValidoComCPF();

    //        destinatarioValido.Endereco.Id = idDoEnderecoDaBaseSql;

    //        //Adicionando varios destinatarios vinculados ao mesmo endereco (Só para teste)
    //        Destinatario destinatarioAdicionado1 = _repositorio.Adicionar(destinatarioValido);
    //        Destinatario destinatarioAdicionado2 = _repositorio.Adicionar(destinatarioValido);
    //        Destinatario destinatarioAdicionado3 = _repositorio.Adicionar(destinatarioValido);
    //        Destinatario destinatarioAdicionado4 = _repositorio.Adicionar(destinatarioValido);

    //        IEnumerable<Destinatario> destinatariosResultadoDoBuscarTodos = _repositorio.BuscarTodos();

    //        destinatariosResultadoDoBuscarTodos.Count().Should().Be(5);
            
    //    }

    //    [Test]
    //    public void Destinatario_InfraData_Atualizar_Sucesso()
    //    {
    //        long idDoDestinatarioDaBaseSql = 1;

    //        Destinatario destinatarioResultadoDoBuscarParaAtualizar = _repositorio.BuscarPorId(idDoDestinatarioDaBaseSql);

    //        destinatarioResultadoDoBuscarParaAtualizar.Documento = new Documento("085.544.678-00", TipoDocumento.CPF);

    //        destinatarioResultadoDoBuscarParaAtualizar.NomeRazaoSocial = "Alterado";
    //        destinatarioResultadoDoBuscarParaAtualizar.InscricaoEstadual = null;
           

    //        _repositorio.Atualizar(destinatarioResultadoDoBuscarParaAtualizar);

    //        Destinatario resultado = _repositorio.BuscarPorId(destinatarioResultadoDoBuscarParaAtualizar.Id);

    //        resultado.InscricaoEstadual.Should().Be(destinatarioResultadoDoBuscarParaAtualizar.InscricaoEstadual);
    //        resultado.NomeRazaoSocial.Should().Be(destinatarioResultadoDoBuscarParaAtualizar.NomeRazaoSocial);
    //        resultado.Documento.Tipo.Should().Be(destinatarioResultadoDoBuscarParaAtualizar.Documento.Tipo);
    //    }

    //    [Test]
    //    public void Destinatario_InfraData_Excluir_Sucesso()
    //    {
    //        long idDoDestinatarioDaBaseSql = 1;

    //        Destinatario destinatarioResultadoDoBuscar  = _repositorio.BuscarPorId(idDoDestinatarioDaBaseSql);

    //        _repositorio.Excluir(destinatarioResultadoDoBuscar);

    //        Destinatario destinatarioQueDeveSerNullo = _repositorio.BuscarPorId(destinatarioResultadoDoBuscar.Id);

    //        destinatarioQueDeveSerNullo.Should().BeNull();
    //    }

    //}
}
