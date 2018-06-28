using FluentAssertions;
using NUnit.Framework;
using System;
using System.Data.Entity;
using System.Linq;
using TutorialORM.Aplicacao.Features.Turmas;
using TutorialORM.Common.Testes.Base;
using TutorialORM.Common.Testes.Features;
using TutorialORM.Dominio.Exceptions;
using TutorialORM.Dominio.Features.Turmas;
using TutorialORM.Infra.Data.Base;
using TutorialORM.Infra.Data.Features.Turmas;

namespace TutorialORM.Integracao.Sistema.Testes.Features.Turmas
{
    [TestFixture]
    public class TurmaServicoTestesSistema
    {
        EscolaContext contexto;
        ITurmaRepositorio repositorio;
        TurmaServico servico;
        Turma turma;

        [SetUp]
        public void SetUp()
        {
            contexto = new EscolaContext();
            repositorio = new TurmaRepositorio(contexto);
            servico = new TurmaServico(repositorio);
            Database.SetInitializer(new BaseSqlTestes());
            contexto.Database.Initialize(true);
        }

        [Test]
        public void Turma_Sistema_Aplicacao_Salvar_NaoDeveJogarExcecao()
        {
            turma = ObjectMother.ObterTurmaValida();

            var turmaSalva = servico.Salvar(turma);

            turmaSalva.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Turma_Sistema_Aplicacao_PegarPorId_NaoDeveJogarExcecao()
        {
            turma = ObjectMother.ObterTurmaValida();
            turma.Id = 1;
            servico.Salvar(turma);

            var turmaPego = servico.PegarPorId(turma.Id);

            turmaPego.Id.Should().Be(turma.Id);
        }

        [Test]
        public void Turma_Sistema_Aplicacao_PegarPorId_DeveJogarExcecaoIdentificadorInvalido()
        {
            var id = 0;

            Action acao = () => servico.PegarPorId(id);

            acao.Should().Throw<IdentificadorInvalidoException>();
        }

        [Test]
        public void Turma_Sistema_Aplicacao_PegarTodos_NaoDeveJogarExcecao()
        {
            turma = ObjectMother.ObterTurmaValida();
            turma = servico.Salvar(turma);

            var turmas = servico.PegarTodos();

            turmas.Last().Id.Should().Be(turma.Id);
        }

        [Test]
        public void Turma_Sistema_Aplicacao_Atualizar_NaoDeveJogarExcecao()
        {
            turma = ObjectMother.ObterTurmaValida();
            turma = servico.Salvar(turma);
            turma.Descricao = "atualizado";

            var turmaAtualizada = servico.Atualizar(turma);

            turmaAtualizada.Descricao.Should().Be(turma.Descricao);
        }

        [Test]
        public void Turma_Sistema_Aplicacao_Atualizar_DeveJogarIdentificadorInvalidoExcecao()
        {
            turma = ObjectMother.ObterTurmaValida();
            turma.Id = 0;

            Action acao = () => servico.Atualizar(turma);

            acao.Should().Throw<IdentificadorInvalidoException>();
        }

        [Test]
        public void Turma_Sistema_Aplicacao_Deletar_NaoDeveJogarExcecao()
        {
            turma = ObjectMother.ObterTurmaValida();
            turma = servico.Salvar(turma);

            servico.Deletar(turma);

            var turmaDeletada = servico.PegarPorId(turma.Id);

            turmaDeletada.Should().BeNull();
        }

        [Test]
        public void Turma_Sistema_Aplicacao_Deletar_DeveJogarIdentificadorInvalidoExcecao()
        {
            turma.Id = 0;

            Action acao = () => servico.Deletar(turma);

            acao.Should().Throw<IdentificadorInvalidoException>();
        }

        [Test]
        public void Turma_Sistema_Aplicacao_Deletar_DeveJogarTurmaReferenciadaExcecao()
        {
            turma = new Turma { Id = 1 };

            Action acao = () => servico.Deletar(turma);

            acao.Should().Throw<TurmaReferenciadaException>();
        }
    }
}
