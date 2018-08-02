using FluentAssertions;
using NUnit.Framework;
using ProvaTDD.Common.Testes.Base;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Features.Alunos;
using ProvaTDD.Infra.Data.Features.Alunos;
using System.Collections.Generic;
using System.Linq;

namespace ProvaTDD.Infra.Data.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoRepositorioTestes
    {
        IAlunoRepositorio repositorio;
        Aluno aluno;

        [SetUp]
        public void SetUp()
        {
            BaseSqlTeste.SeedDatabase();
            repositorio = new AlunoRepositorio();
            aluno = new Aluno();
        }

        [Test]
        public void Aluno_Repositorio_DeveSalvarNoBanco()
        {
            var idEsperado = 1;
            aluno = ObjectMother.ObterAlunoValido();

            aluno = repositorio.Salvar(aluno);

            aluno.Id.Should().Be(idEsperado);
        }

        [Test]
        public void Aluno_Repositorio_DeveAtualizar()
        {
            aluno = ObjectMother.ObterAlunoValido();
            aluno = repositorio.Salvar(aluno);
            aluno = repositorio.PegarPorId(aluno.Id);
            aluno.Nome = "Ciclano";

            repositorio.Atualizar(aluno);

            aluno.Nome.Should().Be("Ciclano");
        }

        [Test]
        public void Aluno_Repositorio_PegarPorId_DevePegarOk()
        {
            aluno = repositorio.Salvar(aluno);

            IList<Aluno> alunos = repositorio.PegarTodos();

            alunos.Count.Should().BeGreaterThan(0);
            alunos.First().Id.Should().Be(aluno.Id);
        }

        [Test]
        public void Aluno_Repositorio_Deletar_DeveDeletarOk()
        {
            aluno = ObjectMother.ObterAlunoValido();
            aluno = repositorio.Salvar(aluno);
            aluno = repositorio.PegarPorId(aluno.Id);

            repositorio.Deletar(aluno);
            aluno = repositorio.PegarPorId(aluno.Id);

            aluno.Should().BeNull();
        }
    }
}
