using FluentAssertions;
using Loterica.Aplicacao.Features.Resultados;
using Loterica.Common.Tests;
using Loterica.Common.Tests.Base;
using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Resultados;
using Loterica.Infra.Data.Features.Resultados;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Loterica.Integracao.Tests.Features.Resultados
{
    [TestFixture]
    public class ResultadoIntegracaoBDTests
    {
        private IRepository<Resultado> _repositoryResultado;
        private ResultadoServico _servicoResultado;
        private Resultado _resultado;

        [SetUp]
        public void SetUp()
        {
            _resultado = ObjectMother.GetValidResultado();
            _repositoryResultado = new ResultadoRepository();
            _servicoResultado = new ResultadoServico(_repositoryResultado);
            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void Test_ResultadoIntegracaoBD_ShouldAddOk()
        {
            Resultado resultado = _servicoResultado.Adicionar(_resultado);

            resultado.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_ResultadoIntegracaoBD_ShouldGetOk()
        {
            Resultado resultadoAdd = _servicoResultado.Adicionar(_resultado);
            Resultado resultadoGet = _servicoResultado.ConsultarPorId(resultadoAdd.Id);

            resultadoGet.Id.Should().Be(resultadoAdd.Id);
        }

        [Test]
        public void Test_ResultadoIntegracaoBD_ShouldGetAllOk()
        {
            Resultado resultadoAdd = _servicoResultado.Adicionar(_resultado);
            IEnumerable<Resultado> resultados = _servicoResultado.BuscarTodos();

            resultados.Count().Should().BeGreaterThan(0);
            resultados.Last().Id.Should().Be(resultadoAdd.Id);
        }

        [Test]
        public void Test_ResultadoIntegracaoBD_ShouldUpdateOk()
        {
            Resultado resultadoAdd = _servicoResultado.Adicionar(_resultado);
            Resultado resultadoGet = _servicoResultado.ConsultarPorId(resultadoAdd.Id);

            List<int> numSorteados = new List<int>() { 01, 02, 03, 04, 05, 09 };
            resultadoGet.NumerosSorteados = numSorteados;
            resultadoAdd = _servicoResultado.Atualizar(resultadoGet);

            resultadoAdd.NumerosSorteados.Should().Equal(numSorteados);
        }

        [Test]
        public void Test_ResultadoIntegracaoBD_ShouldDeleteOk()
        {
            Resultado resultadoAdd = _servicoResultado.Adicionar(_resultado);
            _servicoResultado.Excluir(resultadoAdd);
            Resultado resultadoGet = _servicoResultado.ConsultarPorId(resultadoAdd.Id);

            resultadoGet.Should().BeNull();
        }
    }
}
