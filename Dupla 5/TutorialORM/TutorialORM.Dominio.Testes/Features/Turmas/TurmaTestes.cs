using FluentAssertions;
using NUnit.Framework;
using System;
using TutorialORM.Common.Testes.Features;
using TutorialORM.Dominio.Features.Turmas;

namespace TutorialORM.Dominio.Testes.Features.Turmas
{
    [TestFixture]
    public class TurmaTestes
    {
        Turma turma;
        
        [Test]
        public void Turma_Dominio_Validar_DeveValidarOk()
        {
            turma = ObjectMother.ObterTurmaValida();

            Action action = turma.Validar;

            action.Should().NotThrow();
        }

        [Test]
        public void Turma_Dominio_Validar_DeveJogarExcecaoDescricaoVazia()
        {
            turma = ObjectMother.ObterTurmaDescricaoVazia();

            Action action = turma.Validar;

            action.Should().Throw<TurmaDescricaoVaziaException>();
        }

        [Test]
        public void Turma_Dominio_Validar_DeveJogarExcecaoDescricaoComEspaco()
        {
            turma = ObjectMother.ObterTurmaDescricaoComEspaco();

            Action action = turma.Validar;

            action.Should().Throw<TurmaDescricaoVaziaException>();
        }
    }
}
