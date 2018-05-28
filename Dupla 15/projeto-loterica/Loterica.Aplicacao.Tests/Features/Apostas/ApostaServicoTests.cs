using FluentAssertions;
using Loterica.Aplicacao.Features.Apostas;
using Loterica.Common.Tests;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Concursos;
using Loterica.Dominio.Features.Resultados;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Loterica.Aplicacao.Tests.Features.Apostas
{
    [TestFixture]
    public class ApostaServicoTests
    {
        ApostaServico _servico;
        Mock<IApostaRepository> _repository;
        Mock<IConcursoRepository> _repositoryConcurso;
        Mock<IResultadoRepository> _repositoryResultado;
        Aposta _aposta;
        Concurso _concurso;
        Resultado _resultado;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IApostaRepository>();
            _servico = new ApostaServico(_repository.Object);
            _concurso = ObjectMother.GetValidConcursoAberto();
            _aposta = ObjectMother.GetValidAposta(_concurso);
            _resultado = ObjectMother.GetValidResultado();

            _repositoryConcurso = new Mock<IConcursoRepository>();
            _repositoryResultado = new Mock<IResultadoRepository>();

        }

        [Test]
        [Order(0)]
        public void Test_ApostaServico_ShouldAddOk()
        {
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_aposta)).Returns(new Aposta() { Id = idEsperadoNoBD });
            Aposta resultado = _servico.Adicionar(_aposta);

            _repository.Verify(x => x.Adicionar(_aposta));
            resultado.Id.Should().BeGreaterThan(0);
            resultado.Id.Should().Be(idEsperadoNoBD);
        }

        [Test]
        public void Test_ApostaServico_ShouldGetOk()
        {
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_aposta)).Returns(new Aposta() { Id = idEsperadoNoBD });
            _repository.Setup(x => x.ObterPorId(_aposta.Id)).Returns(_aposta);
            Aposta resultadoAdicionar = _servico.Adicionar(_aposta);
            Aposta resultadoGet = _servico.ConsultarPorId(_aposta.Id);

            _repository.Verify(x => x.ObterPorId(_aposta.Id));
            resultadoGet.Id.Should().Equals(resultadoAdicionar.Id);
        }

        [Test]
        [Order(1)]
        public void Test_ApostaServico_ShouldGetAllOk()
        {
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_aposta)).Returns(new Aposta() { Id = idEsperadoNoBD });
            _repository.Setup(x => x.PegarTodos()).Returns(new List<Aposta>() { _aposta });
            Aposta resultadoAdicionar = _servico.Adicionar(_aposta);
            IEnumerable<Aposta> resultadoGetAll = _servico.BuscarTodos();
            _repository.Verify(x => x.PegarTodos());

            resultadoGetAll.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_ApostaServico_ShouldUpdateOk()
        {
            var idEsperadoNoBD = 2;
            var valorAtualizado = 500;
            _repository.Setup(x => x.Adicionar(_aposta)).Returns(new Aposta() { Id = idEsperadoNoBD });
            _repository.Setup(x => x.ObterPorId(_aposta.Id)).Returns(_aposta);
            _repository.Setup(x => x.Atualizar(_aposta)).Returns(new Aposta() { Valor = 500 });
            Aposta resultadoAdicionar = _servico.Adicionar(_aposta);
            Aposta resultadoGet = _servico.ConsultarPorId(_aposta.Id);
            resultadoGet.Valor = valorAtualizado;
            Aposta resultadoAtualizar = _servico.Atualizar(resultadoGet);

            _repository.Verify(x => x.Atualizar(resultadoGet));
            resultadoGet.Valor.Should().Be(valorAtualizado);
        }

        [Test]
        public void Test_ApostaServico_ShouldDeleteOk()
        {
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_aposta)).Returns(new Aposta() { Id = idEsperadoNoBD });
            _repository.Setup(x => x.ObterPorId(_aposta.Id)).Returns(_aposta);
            _repository.Setup(x => x.Deletar(_aposta));
            Aposta resultadoAdicionar = _servico.Adicionar(_aposta);
            _servico.Excluir(_aposta);
            Aposta resultadoGet = _servico.ConsultarPorId(resultadoAdicionar.Id);

            _repository.Verify(x => x.Deletar(_aposta));

            resultadoGet.Should().BeNull();
        }

        [Test]
        public void Test_ApostaServico_ShouldReturnApostaPerdedora()
        {
            _aposta = ObjectMother.GetValidAposta(_concurso);
            _repositoryConcurso.Setup(x => x.ObterPorId(_concurso.Id)).Returns(new Concurso());
            _repositoryResultado.Setup(x => x.ObterPorId(_resultado.Id)).Returns(new Resultado() { NumerosSorteados = new List<int>() { 11, 22, 33, 44, 55, 66 } });

            EstadoAposta result = _servico.IsGanhadora(_aposta, _repositoryConcurso.Object, _repositoryResultado.Object);

            result.Should().Be(EstadoAposta.PERDEDORA);
        }
    }
}
