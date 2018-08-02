using FluentAssertions;
using NUnit.Framework;
using ProvaTDD.Common.Testes.Base;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Features.Resultados;
using ProvaTDD.Infra.Data.Features.Resultados;
using System.Collections.Generic;
using System.Linq;

namespace ProvaTDD.Infra.Data.Testes.Features.Resultados
{
    [TestFixture]
    public class ResultadoRepositorioTestes
    {
        IResultadoRepositorio repositorio;
        Resultado resultado;

        [SetUp]
        public void SetUp()
        {
            BaseSqlTeste.SeedDatabase();
            repositorio = new ResultadoRepositorio();
            resultado = new Resultado();
        }

        [Test]
        public void Resultado_Repositorio_DeveSalvarNoBanco()
        {
            var idEsperado = 1;
            resultado = ObjectMother.ObterResultadoValido();

            resultado = repositorio.Salvar(resultado);

            resultado.Id.Should().Be(idEsperado);
        }

        [Test]
        public void Resultado_Repositorio_DeveAtualizar()
        {
            resultado = ObjectMother.ObterResultadoValido();
            resultado = repositorio.Salvar(resultado);
            resultado = repositorio.PegarPorId(resultado.Id);
            resultado.Nota = 10;

            repositorio.Atualizar(resultado);

            resultado.Nota.Should().Be(10);
        }

        [Test]
        public void Resultado_Repositorio_PegarPorId_DevePegarOk()
        {
            resultado = repositorio.Salvar(resultado);

            IList<Resultado> resultados = repositorio.PegarTodos();

            resultados.Count.Should().BeGreaterThan(0);
            resultados.First().Id.Should().Be(resultado.Id);
        }

        [Test]
        public void Resultado_Repositorio_Deletar_DeveDeletarOk()
        {
            resultado = ObjectMother.ObterResultadoValido();
            resultado = repositorio.Salvar(resultado);
            resultado = repositorio.PegarPorId(resultado.Id);

            repositorio.Deletar(resultado);
            resultado = repositorio.PegarPorId(resultado.Id);

            resultado.Should().BeNull();
        }
    }
}
