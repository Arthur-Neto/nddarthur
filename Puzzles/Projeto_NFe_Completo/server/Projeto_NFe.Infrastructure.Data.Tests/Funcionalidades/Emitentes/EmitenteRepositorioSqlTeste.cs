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
//    [TestFixture]
//    public class EmitenteRepositorioSqlTeste : EffortTestBase
//    {
//        private FakeDbContext _fakeDbContext;
//        private IEmitenteRepositorio _repositorio;
//        private Endereco _endereco;
//        private Documento _cnpj;

//        [SetUp]
//        public void IniciarCenario()
//        {
//            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
//            _fakeDbContext = new FakeDbContext(connection);
//            _repositorio = new EmitenteRepositorioSql(_fakeDbContext);
//            _endereco = new Endereco();
//            _repositorio = new EmitenteRepositorioSql(_fakeDbContext);
//            _endereco = new Endereco();
//            _cnpj = new Documento("99.327.235/0001-50", TipoDocumento.CNPJ);

//            System.Data.Entity.Database.SetInitializer(new BaseSqlTeste());
//        }

//        [Test]
//        public void Emitente_InfraData_Adicionar_Sucesso()
//        {
//            _endereco.Id = 1;
//            Emitente emitente = ObjectMother.PegarEmitenteValido(_endereco, _cnpj);

//            Emitente resultado = _repositorio.Adicionar(emitente);

//            resultado.Id.Should().BeGreaterThan(0);
//        }

//        [Test]
//        public void Emitente_InfraData_Atualizar_Sucesso()
//        {

//            Emitente emitente = ObjectMother.PegarEmitenteValidoSemDependencias();
//            emitente.Id = 1;

//            emitente = _repositorio.Adicionar(emitente);

//            _repositorio.Atualizar(emitente);

//            Emitente resultado = _repositorio.BuscarPorId(emitente.Id);

//            resultado.NomeFantasia.Should().Be(emitente.NomeFantasia);
//            resultado.RazaoSocial.Should().Be(emitente.RazaoSocial);
//            resultado.InscricaoEstadual.Should().Be(emitente.InscricaoEstadual);
//            resultado.InscricaoMunicipal.Should().Be(emitente.InscricaoMunicipal);
//        }

//        [Test]
//        public void Emitente_InfraData_Excluir_Sucesso()
//        {
//            Emitente emitente = ObjectMother.PegarEmitenteValidoSemDependencias();
//            emitente.Id = 1;

//            emitente = _repositorio.Adicionar(emitente);

//            _repositorio.Excluir(emitente);

//            Emitente emitenteParaBuscar = _repositorio.BuscarPorId(emitente.Id);

//            emitenteParaBuscar.Should().BeNull(); 
//        }

//        [Test]
//        public void Emitente_InfraData_Buscar_Sucesso()
//        {
//            Emitente emitente = ObjectMother.PegarEmitenteValidoSemDependencias();
//            emitente.Id = 1;

//            emitente = _repositorio.Adicionar(emitente);

//            Emitente buscarEmitente =_repositorio.BuscarPorId(emitente.Id);

//            buscarEmitente.Should().NotBeNull();
//            buscarEmitente.NomeFantasia.Should().Be(emitente.NomeFantasia);
//            buscarEmitente.RazaoSocial.Should().Be(emitente.RazaoSocial);
//            buscarEmitente.InscricaoEstadual.Should().Be(emitente.InscricaoEstadual);
//            buscarEmitente.InscricaoMunicipal.Should().Be(emitente.InscricaoMunicipal);
//            buscarEmitente.CNPJ.Numero.Should().Be(emitente.CNPJ.Numero);
//            buscarEmitente.Endereco.Id.Should().Be(emitente.Endereco.Id);
//        }

//        [Test]
//        public void Emitente_InfraData_BuscarTodos_Sucesso()
//        {
//            Emitente emitente = ObjectMother.PegarEmitenteValidoSemDependencias();

//            emitente = _repositorio.Adicionar(emitente);

//            IEnumerable<Emitente> listaEmitente;

//            listaEmitente = _repositorio.BuscarTodos();

//            listaEmitente.Should().NotBeNull();
//            listaEmitente.Count().Should().Be(1);
//        }
//    }
}
