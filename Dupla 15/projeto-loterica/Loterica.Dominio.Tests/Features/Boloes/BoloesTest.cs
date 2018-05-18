using System;
using FluentAssertions;
using Loterica.Common.Tests.Base;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Concursos;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using Loterica.Dominio.Features.Resultados;
using Loterica.Dominio.Features.Boloes;

namespace Loterica.Dominio.Tests.Features.Boloes
{
    [TestFixture]
    public class BoloesTest
    {
        Bolao _bolao;
        Mock<Aposta> _apostas;

        [SetUp]
        public void SetUp()
        {
            _apostas = new Mock<Aposta>();
        }

        [Test]
        public void Test_Boloes_ShouldThrowInvalidBolao()
        {
            _bolao = new Bolao();
            _bolao.Apostas.Add(_apostas.Object);

            Action action = () => _bolao.Validar();

            action.Should().Throw<BolaoApostasInsuficienteException>();
        }

        [Test]
        public void Test_Boloes_ShouldValidBolao()
        {
            _bolao = new Bolao();
            _bolao.Apostas.Add(_apostas.Object);
            _bolao.Apostas.Add(_apostas.Object);

            Action action = () => _bolao.Validar();

            action.Should().NotThrow();
            _bolao.Apostas.Should().HaveCount(2);
        }
    }
}
