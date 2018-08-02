using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProvaTDD.Aplicacao.Features.Resultados;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Features.Resultados;
using System.Collections.Generic;
using System.Linq;

namespace ProvaTDD.Aplicacao.Testes.Features.Resultados
{
    [TestFixture]
    public class ResultadoAplicacaoTestes
    {
        Mock<IResultadoRepositorio> repositorio;
        ResultadoServico servico;
        Resultado resultado;

        [SetUp]
        public void SetUp()
        {
            repositorio = new Mock<IResultadoRepositorio>();
            servico = new ResultadoServico(repositorio.Object);
        }

        [Test]
        public void Resultado_Servico_Salvar_DeveSalvarOk()
        {
            resultado = ObjectMother.ObterResultadoValido();
            repositorio.Setup(m => m.Salvar(resultado)).Returns(new Resultado { Id = 1 });

            resultado = servico.Salvar(resultado);

            resultado.Id.Should().BeGreaterThan(0);
            repositorio.Verify(m => m.Salvar(resultado));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Resultado_Servico_Atualizar_DeveAtualizarOk()
        {
            resultado = ObjectMother.ObterResultadoValido();
            repositorio.Setup(m => m.Salvar(resultado)).Returns(new Resultado { Id = 1 });
            repositorio.Setup(m => m.Atualizar(resultado)).Returns(new Resultado { Id = 1 });
            repositorio.Setup(m => m.PegarPorId(resultado.Id)).Returns(new Resultado { Id = 1 });
            resultado = servico.Salvar(resultado);
            resultado = servico.PegarPorId(resultado.Id);
            resultado.Nota = 10;

            resultado = servico.Atualizar(resultado);

            resultado.Id.Should().BeGreaterThan(0);
            resultado.Nota.Should().Be(10);
            repositorio.Verify(m => m.Atualizar(resultado));
            repositorio.Verify(m => m.Salvar(resultado));
            repositorio.Verify(m => m.PegarPorId(resultado.Id));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Resultado_Servico_PegarPorId_DevePegarPorIdOk()
        {
            resultado = ObjectMother.ObterResultadoValido();
            repositorio.Setup(m => m.Salvar(resultado)).Returns(new Resultado { Id = 1 });
            repositorio.Setup(m => m.PegarPorId(resultado.Id)).Returns(new Resultado { Id = 1 });
            resultado = servico.Salvar(resultado);

            Resultado resultadoPego = servico.PegarPorId(resultado.Id);

            resultadoPego.Id.Should().Equals(resultado.Id);
            repositorio.Verify(m => m.PegarPorId(resultado.Id));
            repositorio.Verify(m => m.Salvar(resultado));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Resultado_Servico_PegarTodos_DevePegarTodosOk()
        {
            resultado = ObjectMother.ObterResultadoValido();
            repositorio.Setup(m => m.Salvar(resultado)).Returns(new Resultado { Id = 1 });
            repositorio.Setup(m => m.PegarTodos()).Returns(new List<Resultado>());
            resultado = servico.Salvar(resultado);

            IList<Resultado> resultados = servico.PegarTodos();

            resultados.Count.Should().BeGreaterThan(0);
            resultados.Last().Id.Should().Be(resultado.Id);
            repositorio.Verify(m => m.PegarTodos());
            repositorio.Verify(m => m.Salvar(resultado));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Resultado_Servico_Deletar_DeveDeletarOk()
        {
            resultado = ObjectMother.ObterResultadoValido();
            repositorio.Setup(m => m.Salvar(resultado)).Returns(new Resultado { Id = 1 });
            repositorio.Setup(m => m.Deletar(resultado));
            resultado = servico.Salvar(resultado);

            servico.Deletar(resultado);

            resultado = servico.PegarPorId(resultado.Id);
            resultado.Should().BeNull();
            repositorio.Verify(m => m.Deletar(resultado));
            repositorio.Verify(m => m.Salvar(resultado));
            repositorio.VerifyNoOtherCalls();
        }
    }
}
