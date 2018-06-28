using FluentAssertions;
using NUnit.Framework;
using System;
using System.Data.Entity;
using System.Linq;
using TutorialORM.Aplicacao.Features.Alunos;
using TutorialORM.Common.Testes.Base;
using TutorialORM.Common.Testes.Features;
using TutorialORM.Dominio.Exceptions;
using TutorialORM.Dominio.Features.Alunos;
using TutorialORM.Infra.Data.Base;
using TutorialORM.Infra.Data.Features.Alunos;

namespace TutorialORM.Integracao.Sistema.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoServicoTestesSistema
    {
        EscolaContext contexto;
        IAlunoRepositorio repositorio;
        AlunoServico servico;
        Aluno aluno;

        [SetUp]
        public void SetUp()
        {
            contexto = new EscolaContext();
            repositorio = new AlunoRepositorio(contexto);
            servico = new AlunoServico(repositorio);
            Database.SetInitializer(new BaseSqlTestes());
            contexto.Database.Initialize(true);
        }

        [Test]
        public void Aluno_Sistema_Aplicacao_Salvar_NaoDeveJogarExcecao()
        {
            aluno = ObjectMother.ObterAlunoValido();

            var alunoSalva = servico.Salvar(aluno);

            alunoSalva.Id.Should().Be(aluno.Id);
        }

        [Test]
        public void Aluno_Sistema_Aplicacao_PegarPorId_NaoDeveJogarExcecao()
        {
            aluno = ObjectMother.ObterAlunoValido();
            aluno.Id = 2;
            servico.Salvar(aluno);

            var alunoPego = servico.PegarPorId(aluno.Id);

            alunoPego.Id.Should().Be(aluno.Id);
        }

        [Test]
        public void Aluno_Sistema_Aplicacao_PegarPorId_DeveJogarExcecaoIdentificadorInvalido()
        {
            var id = 0;

            Action acao = () => servico.PegarPorId(id);

            acao.Should().Throw<IdentificadorInvalidoException>();
        }

        [Test]
        public void Aluno_Sistema_Aplicacao_PegarTodos_NaoDeveJogarExcecao()
        {
            aluno = ObjectMother.ObterAlunoValido();
            aluno = servico.Salvar(aluno);

            var alunos = servico.PegarTodos();

            alunos.Last().Id.Should().Be(aluno.Id);
        }

        [Test]
        public void Aluno_Sistema_Aplicacao_Atualizar_NaoDeveJogarExcecao()
        {
            aluno = ObjectMother.ObterAlunoValido();
            aluno = servico.Salvar(aluno);
            aluno.Nome = "atualizado";

            var alunoAtualizada = servico.Atualizar(aluno);

            alunoAtualizada.Nome.Should().Be(aluno.Nome);
        }

        [Test]
        public void Aluno_Sistema_Aplicacao_Atualizar_DeveJogarIdentificadorInvalidoExcecao()
        {
            aluno = ObjectMother.ObterAlunoValido();
            aluno.Id = 0;

            Action acao = () => servico.Atualizar(aluno);

            acao.Should().Throw<IdentificadorInvalidoException>();
        }

        [Test]
        public void Aluno_Sistema_Aplicacao_Deletar_NaoDeveJogarExcecao()
        {
            aluno = ObjectMother.ObterAlunoValido();
            aluno = servico.Salvar(aluno);

            servico.Deletar(aluno);

            var alunoDeletada = servico.PegarPorId(aluno.Id);
            
            alunoDeletada.Should().BeNull();
        }

        [Test]
        public void Aluno_Sistema_Aplicacao_Deletar_DeveJogarIdentificadorInvalidoExcecao()
        {
            aluno.Id = 0;

            Action acao = () => servico.Deletar(aluno);

            acao.Should().Throw<IdentificadorInvalidoException>();
        }
    }
}
