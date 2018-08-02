using Arthur.ORM.Aplicacao.Features.Departamentos;
using Arthur.ORM.Common.Testes.Features;
using Arthur.ORM.Dominio.Features.Departamentos;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Arthur.ORM.Aplicacao.Testes.Features.Departamentos
{
    [TestFixture]
    public class DepartamentoAplicacaoTestes
    {
        Mock<IDepartamentoRepositorio> _mockRepositorio;
        IDepartamentoServico _departamentoServico;
        Departamento _departamento;

        [SetUp]
        public void SetUp()
        {
            _departamento = ObjetoMae.ObterDepartamentoValido();
            _mockRepositorio = new Mock<IDepartamentoRepositorio>();
            _departamentoServico = new DepartamentoServico(_mockRepositorio.Object);
        }

        [Test]
        public void Departamento_Aplicacao_Salvar_Deve_Salvar_Departamento_Com_Descricao_Valida()
        {
            _departamento.Descricao = "Nova descrição";
            _mockRepositorio.Setup(x => x.Salvar(_departamento)).Returns(new Departamento() { Id = 2, Descricao = _departamento.Descricao });

            var resultado = _departamentoServico.Adicionar(_departamento);

            _mockRepositorio.Verify(x => x.Salvar(_departamento));
            resultado.Descricao.Should().Be(_departamento.Descricao);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Departamento_Aplicacao_Atualizar_Deve_Atualizar_Descricao_Do_Departamento_Com_Id_1()
        {
            _departamento.Id = 1;
            _departamento.Descricao = "Nova descrição";
            _mockRepositorio.Setup(x => x.ObterPorId(_departamento.Id)).Returns(new Departamento() { Id = _departamento.Id, Descricao = _departamento.Descricao });
            _departamento = _departamentoServico.ObterPorId(_departamento.Id);
            _mockRepositorio.Setup(x => x.Atualizar(_departamento)).Returns(new Departamento() { Id = _departamento.Id, Descricao = _departamento.Descricao });

            var resultado = _departamentoServico.Atualizar(_departamento);

            _mockRepositorio.Verify(x => x.ObterPorId(_departamento.Id));
            _mockRepositorio.Verify(x => x.Atualizar(_departamento));
            resultado.Descricao.Should().Be(_departamento.Descricao);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Departamento_Aplicacao_ObterPorId_Deve_Pegar_Departamento_Com_Id_1()
        {
            _departamento.Id = 1;
            _mockRepositorio.Setup(x => x.ObterPorId(_departamento.Id)).Returns(new Departamento() { Id = _departamento.Id });

            var resultado = _departamentoServico.ObterPorId(_departamento.Id);

            _mockRepositorio.Verify(x => x.ObterPorId(_departamento.Id));
            resultado.Id.Should().Be(_departamento.Id);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Departamento_Aplicacao_ObterTodos_Deve_Obter_Pelo_Menos_Um_Departamento()
        {
            _mockRepositorio.Setup(x => x.ObterTodos()).Returns(new List<Departamento>() { new Departamento() });

            var resultado = _departamentoServico.ObterTodos();

            _mockRepositorio.Verify(x => x.ObterTodos());
            resultado.Count().Should().BeGreaterThan(0);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Departamento_Aplicacao_Excluir_Deve_Deletar_Um_Departamento_Sem_Vinculo()
        {
            _departamento.Id = 1;
            _mockRepositorio.Setup(x => x.Deletar(_departamento));
            _mockRepositorio.Setup(x => x.ObterPorId(_departamento.Id));

            _departamentoServico.Excluir(_departamento);

            var resultado = _departamentoServico.ObterPorId(_departamento.Id);
            _mockRepositorio.Verify(x => x.ObterPorId(_departamento.Id));
            _mockRepositorio.Verify(x => x.Deletar(_departamento));
            resultado.Should().BeNull();
            _mockRepositorio.VerifyNoOtherCalls();
        }
    }
}
