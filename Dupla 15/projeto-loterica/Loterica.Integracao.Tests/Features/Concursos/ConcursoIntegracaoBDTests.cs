using FluentAssertions;
using Loterica.Aplicacao.Features.Concursos;
using Loterica.Common.Tests;
using Loterica.Common.Tests.Base;
using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Concursos;
using Loterica.Infra.Data.Features.Concursos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loterica.Integracao.Tests.Features.Concursos
{
    [TestFixture]
    public class ConcursoIntegracaoBDTests
    {
        private IRepository<Concurso> _repositoryConcurso;
        private ConcursoServico _servicoConcurso;
        private Concurso _concurso;

        [SetUp]
        public void SetUp()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();
            _repositoryConcurso = new ConcursoRepository();
            _servicoConcurso = new ConcursoServico(_repositoryConcurso);
            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void Test_ConcursoIntegracaoBD_ShouldAddOk()
        {
            Concurso resultado = _servicoConcurso.Adicionar(_concurso);

            resultado.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_ConcursoIntegracaoBD_ShouldGetOk()
        {
            Concurso resultado = _servicoConcurso.Adicionar(_concurso);
            Concurso resultadoGet = _servicoConcurso.ConsultarPorId(resultado.Id);

            resultadoGet.Id.Should().Be(resultado.Id);
        }

        [Test]
        public void Test_ConcursoIntegracaoBD_ShouldUpdateOk()
        {
            Concurso resultado = _servicoConcurso.Adicionar(_concurso);
            Concurso resultadoGet = _servicoConcurso.ConsultarPorId(resultado.Id);
            resultadoGet.Faturamento = 1000;
            resultado = _servicoConcurso.Atualizar(resultadoGet);

            resultado.Faturamento.Should().Be(resultado.Faturamento);
        }

        [Test]
        public void Test_ConcursoIntegracaoBD_ShouldGeAlltOk()
        {
            Concurso resultado = _servicoConcurso.Adicionar(_concurso);
            IEnumerable<Concurso> concursos = _servicoConcurso.BuscarTodos();

            concursos.Count().Should().BeGreaterThan(0);
            concursos.Last().Id.Should().Be(resultado.Id);
        }

        [Test]
        public void Test_ConcursoIntegracaoBD_ShouldDeleteOk()
        {
            Concurso resultado = _servicoConcurso.Adicionar(_concurso);
            _servicoConcurso.Excluir(resultado);
            Concurso resultadoGet = _servicoConcurso.ConsultarPorId(resultado.Id);

            resultadoGet.Should().BeNull();
        }

        [Test]
        public void Test_ConcursoIntegracaoBD_ShouldGenerateRelatorioFaturamento()
        {
            Concurso resultado = _servicoConcurso.Adicionar(_concurso);
            string faturamento = _servicoConcurso.RelatorioFaturamento();

            faturamento.Should().NotBeEmpty();
        }

        [Test]
        public void Test_ConcursoIntergracaoDB_ShouldGenerateCSV()
        {
            Concurso resultado = _servicoConcurso.Adicionar(_concurso);
            string caminho = "C:\\temp\\teste.csv";
            Action action = () => _servicoConcurso.GerarCSVConcursos(caminho);

            action.Should().NotThrow();

        }
    }
}
