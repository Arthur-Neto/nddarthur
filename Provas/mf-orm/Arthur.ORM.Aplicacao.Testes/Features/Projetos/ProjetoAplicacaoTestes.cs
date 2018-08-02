using Arthur.ORM.Aplicacao.Features.Projetos;
using Arthur.ORM.Common.Testes.Features;
using Arthur.ORM.Dominio.Features.Projetos;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Arthur.ORM.Aplicacao.Testes.Features.Projetos
{
    [TestFixture]
    public class ProjetoAplicacaoTestes
    {
        Mock<IProjetoRepositorio> _mockRepositorio;
        IProjetoServico _projetoServico;
        Projeto _projeto;

        [SetUp]
        public void SetUp()
        {
            _projeto = ObjetoMae.ObterProjetoComUmFuncionario();
            _mockRepositorio = new Mock<IProjetoRepositorio>();
            _projetoServico = new ProjetoServico(_mockRepositorio.Object);
        }

        [Test]
        public void Projeto_Aplicacao_Salvar_Deve_Salvar_Projeto_Com_Nome_Valido()
        {
            _projeto.Nome = "Novo nome";
            _mockRepositorio.Setup(x => x.Salvar(_projeto)).Returns(new Projeto() { Id = 2, Nome = _projeto.Nome });

            var resultado = _projetoServico.Adicionar(_projeto);

            _mockRepositorio.Verify(x => x.Salvar(_projeto));
            resultado.Nome.Should().Be(_projeto.Nome);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Projeto_Aplicacao_Atualizar_Deve_Atualizar_Nome_Do_Projeto_Com_Id_1()
        {
            _projeto.Id = 1;
            _projeto.Nome = "Novo nome";
            _mockRepositorio.Setup(x => x.ObterPorId(_projeto.Id)).Returns(new Projeto() { Id = _projeto.Id, Nome = _projeto.Nome });
            _projeto = _projetoServico.ObterPorId(_projeto.Id);
            _mockRepositorio.Setup(x => x.Atualizar(_projeto)).Returns(new Projeto() { Id = _projeto.Id, Nome = _projeto.Nome });

            var resultado = _projetoServico.Atualizar(_projeto);

            _mockRepositorio.Verify(x => x.ObterPorId(_projeto.Id));
            _mockRepositorio.Verify(x => x.Atualizar(_projeto));
            resultado.Nome.Should().Be(_projeto.Nome);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Projeto_Aplicacao_ObterPorId_Deve_Pegar_Projeto_Com_Id_1()
        {
            _projeto.Id = 1;
            _mockRepositorio.Setup(x => x.ObterPorId(_projeto.Id)).Returns(new Projeto() { Id = _projeto.Id });

            var resultado = _projetoServico.ObterPorId(_projeto.Id);

            _mockRepositorio.Verify(x => x.ObterPorId(_projeto.Id));
            resultado.Id.Should().Be(_projeto.Id);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Projeto_Aplicacao_ObterTodos_Deve_Obter_Pelo_Menos_Um_Projeto()
        {
            _mockRepositorio.Setup(x => x.ObterTodos()).Returns(new List<Projeto>() { new Projeto() });

            var resultado = _projetoServico.ObterTodos();

            _mockRepositorio.Verify(x => x.ObterTodos());
            resultado.Count().Should().BeGreaterThan(0);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Projeto_Aplicacao_Excluir_Deve_Deletar_Um_Projeto_Sem_Vinculo()
        {
            _projeto.Id = 1;
            _mockRepositorio.Setup(x => x.Deletar(_projeto));
            _mockRepositorio.Setup(x => x.ObterPorId(_projeto.Id));

            _projetoServico.Excluir(_projeto);

            var resultado = _projetoServico.ObterPorId(_projeto.Id);
            _mockRepositorio.Verify(x => x.ObterPorId(_projeto.Id));
            _mockRepositorio.Verify(x => x.Deletar(_projeto));
            resultado.Should().BeNull();
            _mockRepositorio.VerifyNoOtherCalls();
        }
    }
}
