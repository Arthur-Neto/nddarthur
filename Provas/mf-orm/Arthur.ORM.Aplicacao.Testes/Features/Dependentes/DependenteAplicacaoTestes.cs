using Arthur.ORM.Aplicacao.Features.Dependentes;
using Arthur.ORM.Common.Testes.Features;
using Arthur.ORM.Dominio.Features.Dependentes;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Arthur.ORM.Aplicacao.Testes.Features.Dependentes
{
    [TestFixture]
    public class DependenteAplicacaoTestes
    {
        Mock<IDependenteRepositorio> _mockRepositorio;
        IDependenteServico _dependenteServico;
        Dependente _dependente;

        [SetUp]
        public void SetUp()
        {
            _dependente = ObjetoMae.ObterDependenteDeUmFuncionario();
            _mockRepositorio = new Mock<IDependenteRepositorio>();
            _dependenteServico = new DependenteServico(_mockRepositorio.Object);
        }

        [Test]
        public void Dependente_Aplicacao_Salvar_Deve_Salvar_Dependente_Com_Nome_Valido()
        {
            _dependente.Nome = "Novo nome";
            _mockRepositorio.Setup(x => x.Salvar(_dependente)).Returns(new Dependente() { Id = 2, Nome = _dependente.Nome });

            var resultado = _dependenteServico.Adicionar(_dependente);

            _mockRepositorio.Verify(x => x.Salvar(_dependente));
            resultado.Nome.Should().Be(_dependente.Nome);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Dependente_Aplicacao_Atualizar_Deve_Atualizar_Nome_Do_Dependente_Com_Id_1()
        {
            _dependente.Id = 1;
            _dependente.Nome = "Novo nome";
            _mockRepositorio.Setup(x => x.ObterPorId(_dependente.Id)).Returns(new Dependente() { Id = _dependente.Id, Nome = _dependente.Nome });
            _dependente = _dependenteServico.ObterPorId(_dependente.Id);
            _mockRepositorio.Setup(x => x.Atualizar(_dependente)).Returns(new Dependente() { Id = _dependente.Id, Nome = _dependente.Nome });

            var resultado = _dependenteServico.Atualizar(_dependente);

            _mockRepositorio.Verify(x => x.ObterPorId(_dependente.Id));
            _mockRepositorio.Verify(x => x.Atualizar(_dependente));
            resultado.Nome.Should().Be(_dependente.Nome);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Dependente_Aplicacao_ObterPorId_Deve_Pegar_Dependente_Com_Id_1()
        {
            _dependente.Id = 1;
            _mockRepositorio.Setup(x => x.ObterPorId(_dependente.Id)).Returns(new Dependente() { Id = _dependente.Id });

            var resultado = _dependenteServico.ObterPorId(_dependente.Id);

            _mockRepositorio.Verify(x => x.ObterPorId(_dependente.Id));
            resultado.Id.Should().Be(_dependente.Id);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Dependente_Aplicacao_ObterTodos_Deve_Obter_Pelo_Menos_Um_Dependente()
        {
            _mockRepositorio.Setup(x => x.ObterTodos()).Returns(new List<Dependente>() { new Dependente() });

            var resultado = _dependenteServico.ObterTodos();

            _mockRepositorio.Verify(x => x.ObterTodos());
            resultado.Count().Should().BeGreaterThan(0);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Dependente_Aplicacao_Excluir_Deve_Deletar_Um_Dependente_Sem_Vinculo()
        {
            _dependente.Id = 1;
            _mockRepositorio.Setup(x => x.Deletar(_dependente));
            _mockRepositorio.Setup(x => x.ObterPorId(_dependente.Id));

            _dependenteServico.Excluir(_dependente);

            var resultado = _dependenteServico.ObterPorId(_dependente.Id);
            _mockRepositorio.Verify(x => x.ObterPorId(_dependente.Id));
            _mockRepositorio.Verify(x => x.Deletar(_dependente));
            resultado.Should().BeNull();
            _mockRepositorio.VerifyNoOtherCalls();
        }
    }
}
