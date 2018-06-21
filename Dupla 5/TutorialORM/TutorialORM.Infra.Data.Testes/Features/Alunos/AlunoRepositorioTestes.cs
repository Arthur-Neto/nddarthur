using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TutorialORM.Common.Testes.Base;
using TutorialORM.Common.Testes.Features;
using TutorialORM.Dominio.Features.Alunos;
using TutorialORM.Infra.Data.Base;
using TutorialORM.Infra.Data.Features.Alunos;

namespace TutorialORM.Infra.Data.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoRepositorioTestes
    {
        EscolaContext escolaContext = new EscolaContext();
        IAlunoRepositorio repositorio;
        Aluno aluno;

        [SetUp]
        public void SetUp()
        {
            repositorio = new AlunoRepositorio();
            BaseSqlTestes.SeedDatabase(escolaContext);
        }

        [Test]
        public void Aluno_InfraData_Salvar_DeveInserirOk()
        {
            aluno = ObjectMother.ObterAlunoValido();

            aluno = repositorio.Salvar(aluno);

            aluno.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Aluno_InfraData_Deletar_DeveRemoverOk()
        {
            aluno = ObjectMother.ObterAlunoValido();
            aluno = repositorio.Salvar(aluno);

            repositorio.Deletar(aluno);

            aluno = repositorio.PegarPorId(aluno.Id);
            aluno.Should().BeNull();
        }

        [Test]
        public void Aluno_InfraData_PegarPorId_DevePegarAlunoOk()
        {
            aluno = ObjectMother.ObterAlunoValido();
            aluno = repositorio.Salvar(aluno);

            var resultado = repositorio.PegarPorId(aluno.Id);

            resultado.Should().NotBeNull();
            resultado.Id.Should().Equals(aluno.Id);
        }

        [Test]
        public void Aluno_InfraData_PegarTodos_DevePegarTodosOk()
        {
            IEnumerable<Aluno> alunos;
            aluno = ObjectMother.ObterAlunoValido();
            aluno = repositorio.Salvar(aluno);

            alunos = repositorio.PegarTodos();

            alunos.Count().Should().BeGreaterThan(0);
            alunos.First().Id.Should().Equals(aluno.Id);
        }

        [Test]
        public void Aluno_InfraData_Atualizar_DeveAtualizarOk()
        {
            aluno = ObjectMother.ObterAlunoValido();
            aluno = repositorio.Salvar(aluno);
            aluno.Nome = "Atualizado";

            var alunoAtualizado = repositorio.Atualizar(aluno);

            alunoAtualizado.Nome.Should().Be(aluno.Nome);
        }
    }
}
