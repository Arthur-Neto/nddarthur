using System;
using FluentAssertions;
using Loterica.Common.Tests.Base;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Concursos;
using NUnit.Framework;
using Moq;
using Loterica.Dominio.Features.Resultados;

namespace Loterica.Dominio.Tests.Features.Resultados
{
    [TestFixture]
    public class ResultadoTests
    {
        Resultado resultado;
        Mock<Concurso> concurso;

        [SetUp]
        public void SetUp()
        {
            concurso = new Mock<Concurso>();
        }

        [Test]
        public void Test_Resultado_ShouldValidateAllOk()
        {
            resultado = ObjectMother.GetValidResultado();

            Action action = () => resultado.Validar();

            action.Should().NotThrow();
        }

        [Test]
        public void Test_Resultado_ShouldThrowInsufficientNumbers()
        {
            resultado = ObjectMother.GetResultadoNumeroSorteadosInsufficient(concurso.Object);

            Action action = () => resultado.Validar();

            action.Should().Throw<ResultadoNumerosSorteadosInsufficientException>();
        }
    }
}
