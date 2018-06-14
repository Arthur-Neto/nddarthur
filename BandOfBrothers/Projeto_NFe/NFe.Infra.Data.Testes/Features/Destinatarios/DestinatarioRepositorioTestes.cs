using FluentAssertions;
using NFe.Common.Testes.Base;
using NFe.Common.Testes.Features;
using NFe.Dominio.Features.Destinatarios;
using NFe.Infra.Data.Features.Destinatarios;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NFe.Infra.Data.Testes.Features.Destinatarios
{
    [TestFixture]
    public class DestinatarioRepositorioTestes
    {
        IDestinatarioRepositorio repositorio;
        Destinatario destinatario;

        [SetUp]
        public void SetUp()
        {
            BaseSqlTest.SeedDatabase();
            repositorio = new DestinatarioRepositorio();
            destinatario = new Destinatario();
        }

        [Test]
        public void Destinario_InfraData_Salvar_DeveInserirOK()
        {
            var idEsperado = 3;
            destinatario = ObjectMother.ObtemDestinatarioValido();

            Destinatario destinatarioInserido = repositorio.Salvar(destinatario);

            destinatarioInserido.Id.Should().Be(idEsperado);
        }

        [Test]
        public void Destinario_InfraData_Salvar_DeveInserirDestinatarioSemEnderecoSalvo()
        {
            var idEsperado = 3;
            destinatario = ObjectMother.ObtemDestinatarioValido();

            Destinatario destinatarioInserido = repositorio.Salvar(destinatario);

            destinatarioInserido.Id.Should().Be(idEsperado);
        }

        [Test]
        public void Destinario_InfraData_Atualizar_DeveAtualizarOk()
        {
            var _novoNome = "Cia João";
            destinatario = ObjectMother.ObtemDestinatarioValido();
            destinatario = repositorio.Salvar(destinatario);
            destinatario.Nome = _novoNome;

            Destinatario destinatarioAtualizado = repositorio.Atualizar(destinatario);

            destinatarioAtualizado.Nome.Should().Be(_novoNome);
        }

        [Test]
        public void Destinario_InfraData_PegarTodos_DevePegarTodos()
        {
            destinatario = ObjectMother.ObtemDestinatarioValido();
            destinatario = repositorio.Salvar(destinatario);

            IEnumerable<Destinatario> emitentes = repositorio.PegarTodos();

            emitentes.Count().Should().BeGreaterThan(0);
            emitentes.Last().Id.Should().Be(destinatario.Id);
        }

        [Test]
        public void Destinario_InfraData_Deletar_DeveDeletarOk()
        {
            destinatario = ObjectMother.ObtemDestinatarioValido();
            destinatario = repositorio.Salvar(destinatario);

            repositorio.Deletar(destinatario);

            Destinatario destinatarioEncontrado = repositorio.PegarPorId(destinatario.Id);
            destinatarioEncontrado.Should().BeNull();
        }
    }
}
