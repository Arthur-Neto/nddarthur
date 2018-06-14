using FluentAssertions;
using Moq;
using NFe.Common.Testes.Base;
using NFe.Common.Testes.Features;
using NFe.Dominio.Features.Emitentes;
using NFe.Dominio.Features.Enderecos;
using NFe.Infra.Data.Features.Emitentes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NFe.Infra.Data.Testes.Features.Emitentes
{
    [TestFixture]
    public class EmitenteRepositorioTestes
    {
        IEmitenteRepositorio repositorio;
        Emitente emitente;

        [SetUp]
        public void SetUp()
        {
            BaseSqlTest.SeedDatabase();
            repositorio = new EmitenteRepositorio();
            emitente = new Emitente();
        }

        [Test]
        public void Emitente_InfraData_Salvar_DeveInserirOK()
        {
            var idEsperado = 3;
            emitente = ObjectMother.ObterEmitenteValido();

            Emitente _emitenteInserido = repositorio.Salvar(emitente);

            _emitenteInserido.Id.Should().Be(idEsperado);
        }

        [Test]
        public void Emitente_InfraData_Salvar_DeveInserirEmitenteSemEnderecoSalvo()
        {
            var idEsperado = 3;
            emitente = ObjectMother.ObterEmitenteValido();

            Emitente emitenteInserido = repositorio.Salvar(emitente);

            emitenteInserido.Id.Should().Be(idEsperado);
        }

        [Test]
        public void Emitente_InfraData_Atualizar_DeveAtualizarOk()
        {
            emitente = ObjectMother.ObterEmitenteValido();
            emitente = repositorio.Salvar(emitente);
            var _novoNome = "Cia João";
            emitente.Nome = _novoNome;

            Emitente _emitenteAtualizado = repositorio.Atualizar(emitente);

            _emitenteAtualizado.Nome.Should().Be(_novoNome);
        }

        [Test]
        public void Emitente_InfraData_PegarTodos_DevePegarTodos()
        {
            emitente = ObjectMother.ObterEmitenteValido();
            emitente = repositorio.Salvar(emitente);

            IEnumerable<Emitente> emitentes = repositorio.PegarTodos();

            emitentes.Count().Should().BeGreaterThan(0);
            emitentes.Last().Id.Should().Be(emitente.Id);
        }

        [Test]
        public void Emitente_InfraData_PegarPorId_DevePegarPorIdOk()
        {
            emitente = ObjectMother.ObterEmitenteValido();
            emitente = repositorio.Salvar(emitente);

            Emitente emitentePego = repositorio.PegarPorId(emitente.Id);

            emitentePego.Should().NotBeNull();
        }

        [Test]
        public void Emitente_InfraData_Deletar_DeveDeletar()
        {
            emitente = ObjectMother.ObterEmitenteValido();
            emitente = repositorio.Salvar(emitente);

            repositorio.Deletar(emitente);

            Emitente _emitenteEncontrado = repositorio.PegarPorId(emitente.Id);
            _emitenteEncontrado.Should().BeNull();
        }
    }
}
