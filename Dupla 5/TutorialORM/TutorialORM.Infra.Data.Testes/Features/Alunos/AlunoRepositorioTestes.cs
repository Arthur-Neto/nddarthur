using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
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
        EscolaContext escolaContext;
        IAlunoRepositorio repositorio;
        Aluno aluno;

        [SetUp]
        public void SetUp()
        {
            escolaContext = new EscolaContext();
            repositorio = new AlunoRepositorio(escolaContext);
            Database.SetInitializer(new BaseSqlTestes());
            escolaContext.Database.Initialize(true);
        }

        [Test]
        public void Aluno_InfraData_Salvar_DeveInserirOk()
        {
            aluno = ObjectMother.ObterAlunoValido();
            aluno.Endereco.Id = 1;

            aluno = repositorio.Salvar(aluno);

            aluno.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Aluno_InfraData_Deletar_DeveRemoverOk()
        {
            aluno = ObjectMother.ObterAlunoValido();
            aluno.Endereco.Id = 1;
            aluno = repositorio.Salvar(aluno);

            repositorio.Deletar(aluno);

            aluno = repositorio.PegarPorId(aluno.Id);
            aluno.Should().BeNull();
        }

        [Test]
        public void Aluno_InfraData_PegarPorId_DevePegarAlunoOk()
        {
            aluno = ObjectMother.ObterAlunoValido();
            aluno.Endereco = ObjectMother.ObterEnderecoValido();
            aluno = repositorio.Salvar(aluno);

            var resultado = repositorio.PegarPorId(1);
            var endereco = resultado.Endereco;
            
            resultado.Should().NotBeNull();
            endereco.Should().NotBeNull();
            resultado.Id.Should().Equals(aluno.Id);
        }

        [Test]
        public void Aluno_InfraData_PegarTodos_DevePegarTodosOk()
        {
            IEnumerable<Aluno> alunos;
            aluno = ObjectMother.ObterAlunoValido();
            aluno.Endereco = ObjectMother.ObterEnderecoValido();
            aluno = repositorio.Salvar(aluno);

            alunos = repositorio.PegarTodos();

            alunos.Count().Should().BeGreaterThan(0);
            alunos.First().Id.Should().Equals(aluno.Id);
        }

        [Test]
        public void Aluno_InfraData_Atualizar_DeveAtualizarOk()
        {
            aluno = ObjectMother.ObterAlunoValido();
            aluno.Endereco = ObjectMother.ObterEnderecoValido();
            aluno = repositorio.Salvar(aluno);
            aluno.Nome = "Atualizado";

            var alunoAtualizado = repositorio.Atualizar(aluno);

            alunoAtualizado.Nome.Should().Be(aluno.Nome);
        }
    }
}
