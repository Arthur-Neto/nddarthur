using Effort;
using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Data.Tests.Context;
using Projeto_NFe.Infrastructure.Data.Tests.Inicializador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Tests.Funcionalidades.Transportadoras
{
    [TestFixture]
    public class TransportadorRepositorioSqlTeste : EffortTestBase
    {
        private FakeDbContext _fakeDbContext;
        private ITransportadorRepositorio _transportadorRepositorio;
        private Documento _cnpj;
        private Documento _cpf;
        private Endereco _endereco;

        [SetUp]
        public void IniciarCenario()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _fakeDbContext = new FakeDbContext(connection);
            _transportadorRepositorio = new TransportadorRepositorioSql(_fakeDbContext);
            _endereco = new Endereco();
            _cpf = new Documento("619.648.783-30", TipoDocumento.CPF);
            _cnpj = new Documento("37.311.068/0001-00", TipoDocumento.CNPJ);

            SementeBaseSQL semeador = new SementeBaseSQL(_fakeDbContext);
            semeador.Semear();

        }

        [Test]
        public void Transportador_InfraData_Adicionar_Sucesso()
        {
            Transportador transportador = ObjectMother.PegarTransportadorValidoSemDependencias();

            _transportadorRepositorio.Adicionar(transportador);

            transportador.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Transportador_InfraData_Atualizar_Sucesso()
        {
            long idDoTransportadorDaBaseSql = 1;

            Transportador transportadorResultadoDoBuscarParaAtualizar = _transportadorRepositorio.BuscarPorId(idDoTransportadorDaBaseSql);

            transportadorResultadoDoBuscarParaAtualizar.NomeRazaoSocial = "Atualizado";

            _transportadorRepositorio.Atualizar(transportadorResultadoDoBuscarParaAtualizar);

            Transportador resultado = _transportadorRepositorio.BuscarPorId(transportadorResultadoDoBuscarParaAtualizar.Id);

            resultado.NomeRazaoSocial.Should().Be(transportadorResultadoDoBuscarParaAtualizar.NomeRazaoSocial);
            resultado.InscricaoEstadual.Should().Be(transportadorResultadoDoBuscarParaAtualizar.InscricaoEstadual);
        }

        [Test]
        public void Transportador_InfraData_BuscarTodos_Sucesso()
        {
            int numeroDeTransportadoresPreCadastrados = 2;

            Transportador transportadorValido = ObjectMother.PegarTransportadorValidoSemDependencias();

            //Adicionando varios transportadores vinculados ao mesmo endereco (Só para teste)
            long idTransportadorAdicionado1 = _transportadorRepositorio.Adicionar(transportadorValido);
            long idTransportadorAdicionado2 = _transportadorRepositorio.Adicionar(transportadorValido);
            long idTransportadorAdicionado3 = _transportadorRepositorio.Adicionar(transportadorValido);
            long idTransportadorAdicionado4 = _transportadorRepositorio.Adicionar(transportadorValido);

            int numeroDeTransportadoresCadastradosNesteTeste = 4;

            IEnumerable<Transportador> transportadoresResultadoDoBuscarTodos = _transportadorRepositorio.BuscarTodos();

            transportadoresResultadoDoBuscarTodos.Count().Should().Be(numeroDeTransportadoresCadastradosNesteTeste + numeroDeTransportadoresPreCadastrados);
        }

        [Test]
        public void Transportador_InfraData_BuscarPorId_Sucesso()
        {
            long idDoTransportadorDaBaseSql = 1;

            Transportador transportadorDaBaseSql = _transportadorRepositorio.BuscarPorId(idDoTransportadorDaBaseSql);

            transportadorDaBaseSql.Should().NotBeNull();
        }

        [Test]
        public void Transportador_InfraData_Excluir_Sucesso()
        {
            long idDoTransportadorDaBaseSql = 1;

            Transportador transportadorResultadoDoBuscar = _transportadorRepositorio.BuscarPorId(idDoTransportadorDaBaseSql);

            _transportadorRepositorio.Excluir(transportadorResultadoDoBuscar);

            Transportador transportadorQueDeveSerNullo = _transportadorRepositorio.BuscarPorId(transportadorResultadoDoBuscar.Id);

            transportadorQueDeveSerNullo.Should().BeNull();
        }
    }
}
