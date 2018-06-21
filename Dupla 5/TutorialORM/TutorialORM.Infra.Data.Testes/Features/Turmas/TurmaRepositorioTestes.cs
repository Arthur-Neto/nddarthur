using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TutorialORM.Common.Testes.Base;
using TutorialORM.Common.Testes.Features;
using TutorialORM.Dominio.Features.Turmas;
using TutorialORM.Infra.Data.Base;
using TutorialORM.Infra.Data.Features.Turmas;

namespace TutorialORM.Infra.Data.Testes.Features.Turmas
{
    [TestFixture]
    public class TurmaRepositorioTestes
    {
        EscolaContext escolaContext = new EscolaContext();
        ITurmaRepositorio repositorio;
        Turma turma;

        [SetUp]
        public void SetUp()
        {
            repositorio = new TurmaRepositorio();
            BaseSqlTestes.SeedDatabase(escolaContext);
        }

        [Test]
        public void Turma_InfraData_Salvar_DeveInserirOk()
        {
            turma = ObjectMother.ObterTurmaValida();

            turma = repositorio.Salvar(turma);

            turma.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Turma_InfraData_Deletar_DeveRemoverOk()
        {
            turma = ObjectMother.ObterTurmaValida();
            turma = repositorio.Salvar(turma);

            repositorio.Deletar(turma);

            turma = repositorio.PegarPorId(turma.Id);
            turma.Should().BeNull();
        }

        [Test]
        public void Turma_InfraData_PegarPorId_DevePegarTurmaOk()
        {
            turma = ObjectMother.ObterTurmaValida();
            turma = repositorio.Salvar(turma);

            var resultado = repositorio.PegarPorId(turma.Id);

            resultado.Should().NotBeNull();
            resultado.Id.Should().Equals(turma.Id);
        }

        [Test]
        public void Turma_InfraData_PegarTodos_DevePegarTodosOk()
        {
            IEnumerable<Turma> turmas;
            turma = ObjectMother.ObterTurmaValida();
            turma = repositorio.Salvar(turma);

            turmas = repositorio.PegarTodos();

            turmas.Count().Should().BeGreaterThan(0);
            turmas.First().Id.Should().Equals(turma.Id);
        }

        [Test]
        public void Turma_InfraData_Atualizar_DeveAtualizarOk()
        {
            turma = ObjectMother.ObterTurmaValida();
            turma = repositorio.Salvar(turma);
            turma.Descricao = "Atualizado";

            var turmaAtualizada = repositorio.Atualizar(turma);
            
            turma.Descricao.Should().Be(turma.Descricao);
        }
    }
}
