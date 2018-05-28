using FluentAssertions;
using Loterica.Aplicacao.Features.Apostas;
using Loterica.Aplicacao.Features.Concursos;
using Loterica.Aplicacao.Features.Resultados;
using Loterica.Common.Tests;
using Loterica.Common.Tests.Base;
using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Concursos;
using Loterica.Dominio.Features.Resultados;
using Loterica.Infra.Data.Features.Apostas;
using Loterica.Infra.Data.Features.Concursos;
using Loterica.Infra.Data.Features.Resultados;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Loterica.Integracao.Tests.Features.Apostas
{
    [TestFixture]
    public class ApostaIntegracaoBDTests
    {
        private IRepository<Aposta> _repositoryAposta;
        private ApostaServico _servicoAposta;
        private Aposta _aposta;
        private Concurso _concurso;
        private Aposta apostaResultado;

        [SetUp]
        public void SetUp()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();
            _aposta = ObjectMother.GetValidAposta(_concurso);
            _repositoryAposta = new ApostaRepository();
            _servicoAposta = new ApostaServico(_repositoryAposta);
            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void Test_ApostaIntegracaoBD_ShouldAddOk()
        {
            apostaResultado = _servicoAposta.Adicionar(_aposta);

            apostaResultado.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_ApostaIntegracaoBD_ShouldGetOk()
        {
            apostaResultado = _servicoAposta.Adicionar(_aposta);

            _aposta = _servicoAposta.ConsultarPorId(apostaResultado.Id);

            _aposta.Id.Should().Be(apostaResultado.Id);
        }

        [Test]
        public void Test_ApostaIntegracaoBD_ShouldUpdateOk()
        {
            apostaResultado = _servicoAposta.Adicionar(_aposta);
            _aposta = _servicoAposta.ConsultarPorId(apostaResultado.Id);

            int valorEsperado = 2000;
            _aposta.Valor = 2000;
            apostaResultado = _servicoAposta.Atualizar(_aposta);

            apostaResultado.Valor.Should().Be(valorEsperado);
        }

        [Test]
        public void Test_ApostaIntegracaoBD_ShouldGetAllOk()
        {
            apostaResultado = _servicoAposta.Adicionar(_aposta);
            IEnumerable<Aposta> apostas = _servicoAposta.BuscarTodos();

            apostas.Count().Should().BeGreaterThan(0);
            apostas.Last().Id.Should().Be(apostaResultado.Id);
        }

        [Test]
        public void Test_ApostaIntegracaoBD_ShouldDeleteOk()
        {
            apostaResultado = _servicoAposta.Adicionar(_aposta);
            _aposta = _servicoAposta.ConsultarPorId(apostaResultado.Id);

            _servicoAposta.Excluir(_aposta);

            IEnumerable<Aposta> apostas = _servicoAposta.BuscarTodos();

            apostas.Should().NotContain(_aposta);
        }

        [Test]
        public void Test_ApostaIntegracaoBD_ApostaShouldNotBeGanhadora()
        {
            IRepository<Concurso> repositoryConcurso = new ConcursoRepository();
            IRepository<Resultado> repositoryResultado = new ResultadoRepository();
            ConcursoServico servicoConcurso = new ConcursoServico(repositoryConcurso);
            ResultadoServico servicoResultado = new ResultadoServico(repositoryResultado);

            _concurso.Resultado = ObjectMother.GetValidResultado();
            _aposta.Numeros = new List<int>() { 08, 09, 10, 11, 12, 13 };
            servicoConcurso.Adicionar(_concurso);
            EstadoAposta resultado = _servicoAposta.IsGanhadora(_aposta, repositoryConcurso, repositoryResultado);
            resultado.Should().Be(EstadoAposta.PERDEDORA);
        }
    }
}
