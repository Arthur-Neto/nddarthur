using Effort;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Emitentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Infrastructure.Data.Tests.Context;
using Projeto_NFe.Infrastructure.Data.Tests.Inicializador;

namespace Projeto_NFe.Infrastructure.Data.Tests.Funcionalidades.Emitentes
{
    [TestFixture]
    public class EmitenteRepositorioSqlTeste : EffortTestBase
    {
        private FakeDbContext _fakeDbContext;
        private IEmitenteRepositorio _repositorio;
        private Endereco _endereco;
        private Documento _cnpj;

        [SetUp]
        public void IniciarCenario()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _fakeDbContext = new FakeDbContext(connection);
            _fakeDbContext.Database.Initialize(true);

            _repositorio = new EmitenteRepositorioSql(_fakeDbContext);

            SementeBaseSQL semeador = new SementeBaseSQL(_fakeDbContext);
            semeador.Semear();
        }

        [Test]
        public void Emitente_InfraData_Adicionar_Sucesso()
        {
            Emitente emitenteValido = ObjectMother.PegarEmitenteValidoSemDependencias();

            _repositorio.Adicionar(emitenteValido);

            emitenteValido.Id.Should().BeGreaterThan(0);

            Emitente emitenteResultadoDoGet = _repositorio.BuscarPorId(emitenteValido.Id);

            emitenteResultadoDoGet.CNPJ.Numero.Should().Be(emitenteValido.CNPJ.Numero);
            emitenteResultadoDoGet.Endereco.Pais.Should().Be(emitenteValido.Endereco.Pais);
        }

        [Test]
        public void Emitente_InfraData_Atualizar_Sucesso()
        {
            long idDoEmitenteDaBaseSql = 1;

            Emitente emitenteResultadoDoBuscarParaAtualizar = _repositorio.BuscarPorId(idDoEmitenteDaBaseSql);

            emitenteResultadoDoBuscarParaAtualizar.CNPJ = new Documento("085.544.678-00", TipoDocumento.CNPJ);
            emitenteResultadoDoBuscarParaAtualizar.NomeFantasia = "Alterado";

            _repositorio.Atualizar(emitenteResultadoDoBuscarParaAtualizar);

            Emitente resultado = _repositorio.BuscarPorId(emitenteResultadoDoBuscarParaAtualizar.Id);

            resultado.InscricaoEstadual.Should().Be(emitenteResultadoDoBuscarParaAtualizar.InscricaoEstadual);
            resultado.NomeFantasia.Should().Be(emitenteResultadoDoBuscarParaAtualizar.NomeFantasia);
            resultado.CNPJ.Tipo.Should().Be(emitenteResultadoDoBuscarParaAtualizar.CNPJ.Tipo);

        }

        [Test]
        public void Emitente_InfraData_Excluir_Sucesso()
        {
            long idDoEmitenteDaBaseSql = 1;

            Emitente emitenteResultadoDoBuscar = _repositorio.BuscarPorId(idDoEmitenteDaBaseSql);

            _repositorio.Excluir(emitenteResultadoDoBuscar);

            Emitente emitenteQueDeveSerNullo = _repositorio.BuscarPorId(emitenteResultadoDoBuscar.Id);

            emitenteQueDeveSerNullo.Should().BeNull();
        }

        [Test]
        public void Emitente_InfraData_BuscarPorId_Sucesso()
        {
            long idDoEmitenteDaBaseSql = 1;

            Emitente emitenteDaBaseSql = _repositorio.BuscarPorId(idDoEmitenteDaBaseSql);

            emitenteDaBaseSql.Should().NotBeNull();
            emitenteDaBaseSql.CNPJ.Tipo.Should().Be(TipoDocumento.CNPJ);
        }

        [Test]
        public void Emitente_InfraData_BuscarTodos_Sucesso()
        {
            int numeroDeEmitentesPreCadastrados = 2;

            Emitente emitenteValido = ObjectMother.PegarEmitenteValidoSemDependencias();

            //Adicionando varios emitentes vinculados ao mesmo endereco (Só para teste)
            long idEmitenteAdicionado1 = _repositorio.Adicionar(emitenteValido);
            long idEmitenteAdicionado2 = _repositorio.Adicionar(emitenteValido);
            long idEmitenteAdicionado3 = _repositorio.Adicionar(emitenteValido);
            long idEmitenteAdicionado4 = _repositorio.Adicionar(emitenteValido);

            int numeroDeEmitentesCadastradosNesteTeste = 4;

            IEnumerable<Emitente> emitentesResultadoDoBuscarTodos = _repositorio.BuscarTodos();

            emitentesResultadoDoBuscarTodos.Count().Should().Be(numeroDeEmitentesCadastradosNesteTeste + numeroDeEmitentesPreCadastrados);

        }
    }
}
