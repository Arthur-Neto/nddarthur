using FluentAssertions;
using Loterica.Common.Tests;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Concursos;
using Loterica.Dominio.Features.Resultados;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Loterica.Dominio.Tests.Features.Apostas
{
    [TestFixture]
    public class ApostaTests
    {
        Aposta _aposta;
        Mock<Concurso> _concurso;
        Mock<Resultado> _resultado;

        [SetUp]
        public void SetUp()
        {
            _concurso = new Mock<Concurso>();
            _resultado = new Mock<Resultado>();
        }

        [Test]
        public void Test_Aposta_ShouldValidateAllOk()
        {
            _aposta = ObjectMother.GetValidAposta(_concurso.Object);
            Action action = () => _aposta.Validar();
            action.Should().NotThrow();
        }

        [Test]
        public void Test_Aposta_ShouldThrowExceptionNumerosInvalidos()
        {
            _aposta = ObjectMother.GetNumerosInvalidosAposta(_concurso.Object);

            Action action = () => _aposta.Validar();

            action.Should().Throw<ApostaNumeroInsufficientException>();
        }

        [Test]
        public void Test_Aposta_ShouldThrowExceptionDataInvalida()
        {
            _concurso.Setup(x => x.Data).Returns(DateTime.Now);
            _aposta = ObjectMother.GetDataInvalidaAposta(_concurso.Object);

            Action action = () => _aposta.Validar();

            action.Should().Throw<ApostaDateOverflowException>();
        }

        [Test]
        public void Test_Aposta_ShouldThrowConcursoNullException()
        {
            _aposta = ObjectMother.GetConcursoInvalidoAposta();

            Action action = () => _aposta.Validar();

            action.Should().Throw<ApostaConcursoNullException>();
        }

        [Test]
        public void Test_Aposta_ShouldValorInsuficienteException()
        {
            _aposta = ObjectMother.GetValorInvalidoAposta(_concurso.Object);

            Action action = () => _aposta.Validar();

            action.Should().Throw<ApostaValorInsufficientException>();
        }

        [Test]
        public void Test_Aposta_ShouldReturnFalseForWinner()
        {
            _concurso.Setup(x => x.Resultado.NumerosSorteados).Returns(new List<int>() { 11, 22, 33, 44, 55, 07 });
            _aposta = ObjectMother.GetValidAposta(_concurso.Object);
            EstadoAposta resultado = _aposta.IsGanhadora();
            resultado.Should().Be(EstadoAposta.PERDEDORA);
        }

        [Test]
        public void Test_Aposta_ShouldNumerosGetNumerosAcertados()
        {
            _concurso.Setup(x => x.Resultado.NumerosSorteados).Returns(new List<int>() { 01, 02, 03, 04, 05, 06 });
            _aposta = ObjectMother.GetValidAposta(_concurso.Object);

            int numeroAcertos = _aposta.NumerosAcertos();

            numeroAcertos.Should().Be(6);
        }

        [Test]
        public void Test_Aposta_ShouldNumerosSetNumerosAcertados()
        {
            _concurso.Setup(x => x.Resultado.NumerosSorteados).Returns(new List<int>() { 01, 02, 03, 04, 05, 06 });
            _aposta = ObjectMother.GetValidAposta(_concurso.Object);

            _aposta.NumerosAcertados = 6;

            _aposta.NumerosAcertados.Should().Be(6);
        }
    }
}
