using FluentAssertions;
using Loterica.Aplicacao.Features.Apostas;
using Loterica.Aplicacao.Features.Boloes;
using Loterica.Common.Tests;
using Loterica.Common.Tests.Base;
using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Boloes;
using Loterica.Dominio.Features.Concursos;
using Loterica.Infra.Data.Features.Apostas;
using Loterica.Infra.Data.Features.Boloes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loterica.Integracao.Tests.Features.Boloes
{
    [TestFixture]
    public class ApostaIntegracaoBDTests
    {
        private IRepository<Bolao> _repositoryBolao;
        private BolaoServico _servicoBolao;
        private Bolao _bolao;

        [SetUp]
        public void SetUp()
        {
            _repositoryBolao = new BolaoRepository();
            _servicoBolao = new BolaoServico(_repositoryBolao);
            _bolao = ObjectMother.GetBolaoValido();
            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void Test_BolaoIntegracaoBD_ShouldAddOk()
        {
            Bolao resultado = _servicoBolao.Adicionar(_bolao);

            resultado.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_BolaoIntegracaoBD_ShouldGetOk()
        {
            Bolao resultadoAdd = _servicoBolao.Adicionar(_bolao);
            Bolao resultadoGet = _servicoBolao.ConsultarPorId(resultadoAdd.Id);

            resultadoGet.Id.Should().Be(resultadoAdd.Id);
        }

        [Test]
        public void Test_BolaoIntegracaoBD_ShouldThrowOnUpdate()
        {
            Bolao resultadoAdd = _servicoBolao.Adicionar(_bolao);
            Bolao resultadoGet = _servicoBolao.ConsultarPorId(resultadoAdd.Id);
            Action action = () => _servicoBolao.Atualizar(resultadoGet);

            action.Should().Throw<NotImplementedException>();
        }

        [Test]
        public void Test_BolaoIntegracaoBD_ShouldGetAllOk()
        {
            Bolao resultadoAdd = _servicoBolao.Adicionar(_bolao);
            IEnumerable<Bolao> resultadoGetAll = _servicoBolao.BuscarTodos();

            resultadoGetAll.Count().Should().BeGreaterThan(0);
            resultadoGetAll.Last().Id.Should().Be(resultadoAdd.Id);
        }

        [Test]
        public void Test_BolaoIntegracaoBD_ShouldDeleteOk()
        {
            IRepository<Aposta> repositoryAposta = new ApostaRepository();
            ApostaServico servicoAposta = new ApostaServico(repositoryAposta);

            Bolao resultadoAdd = _servicoBolao.Adicionar(_bolao);
            Bolao resultadoGet = _servicoBolao.ConsultarPorId(resultadoAdd.Id);

            foreach (var aposta in resultadoGet.Apostas)
            {
                var apostaGet = servicoAposta.ConsultarPorId(aposta.Id);
                servicoAposta.Excluir(apostaGet);
            }

            _servicoBolao.Excluir(resultadoGet);
            resultadoGet = _servicoBolao.ConsultarPorId(resultadoAdd.Id);

            resultadoGet.Should().BeNull();
        }

        [Test]
        public void Test_BolaoIntegracaoBD_ShouldGenerateBolao()
        {
            Concurso concurso = ObjectMother.GetValidConcursoAberto();
            int numApostas = 5;
            Bolao resultado = _servicoBolao.GerarBolao(numApostas, concurso);

            resultado.Apostas.Count().Should().Be(numApostas);

        }

    }
}
