using FluentAssertions;
using Loterica.Common.Tests;
using Loterica.Dominio.Features.Concursos;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Loterica.Infra.CSV.Features.Concursos
{
    [TestFixture]
    public class ConcursoCSVRepositoryTests
    {
        List<Concurso> _concursos;

        [SetUp]
        public void SetUp()
        {
            _concursos = ObjectMother.GetConcursos();
        }

        [Test]
        public void Test_CSVTests_ShouldGenerateCSVComVariasApostas()
        {
            string caminho = "C:\\temp\\teste.csv";
            _concursos.Clear();

            Concurso concurso = ObjectMother.GetValidConcursoComApostas();
            Concurso concursoFechado = ObjectMother.GetValidConcursoFechadoComApostas();
            _concursos.Add(concurso);
            _concursos.Add(concursoFechado);

            Action action = () => ConcursoCSVRepository.GerarCSV(_concursos, caminho);

            action.Should().NotThrow();
        }
    }
}
