using Arthur.ORM.Aplicacao.Features.Funcionarios;
using Arthur.ORM.Common.Testes.Features;
using Arthur.ORM.Dominio.Features.Funcionarios;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Arthur.ORM.Aplicacao.Testes.Features.Funcionarios
{
    [TestFixture]
    public class FuncionarioAplicacaoTestes
    {
        Mock<IFuncionarioRepositorio> _mockRepositorio;
        IFuncionarioServico _funcionarioServico;
        Funcionario _funcionario;

        [SetUp]
        public void SetUp()
        {
            _funcionario = ObjetoMae.ObterFuncionarioComCargoEDepartamento();
            _mockRepositorio = new Mock<IFuncionarioRepositorio>();
            _funcionarioServico = new FuncionarioServico(_mockRepositorio.Object);
        }

        [Test]
        public void Funcionario_Aplicacao_Salvar_Deve_Salvar_Funcionario_Com_Nome_Valido()
        {
            _funcionario.Nome = "Novo nome";
            _mockRepositorio.Setup(x => x.Salvar(_funcionario)).Returns(new Funcionario() { Id = 2, Nome = _funcionario.Nome });

            var resultado = _funcionarioServico.Adicionar(_funcionario);

            _mockRepositorio.Verify(x => x.Salvar(_funcionario));
            resultado.Nome.Should().Be(_funcionario.Nome);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Funcionario_Aplicacao_Atualizar_Deve_Atualizar_Nome_Do_Funcionario_Com_Id_1()
        {
            _funcionario.Id = 1;
            _funcionario.Nome = "Novo nome";
            _mockRepositorio.Setup(x => x.ObterPorId(_funcionario.Id)).Returns(new Funcionario() { Id = _funcionario.Id, Nome = _funcionario.Nome });
            _funcionario = _funcionarioServico.ObterPorId(_funcionario.Id);
            _mockRepositorio.Setup(x => x.Atualizar(_funcionario)).Returns(new Funcionario() { Id = _funcionario.Id, Nome = _funcionario.Nome });

            var resultado = _funcionarioServico.Atualizar(_funcionario);

            _mockRepositorio.Verify(x => x.ObterPorId(_funcionario.Id));
            _mockRepositorio.Verify(x => x.Atualizar(_funcionario));
            resultado.Nome.Should().Be(_funcionario.Nome);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Funcionario_Aplicacao_ObterPorId_Deve_Pegar_Funcionario_Com_Id_1()
        {
            _funcionario.Id = 1;
            _mockRepositorio.Setup(x => x.ObterPorId(_funcionario.Id)).Returns(new Funcionario() { Id = _funcionario.Id });

            var resultado = _funcionarioServico.ObterPorId(_funcionario.Id);

            _mockRepositorio.Verify(x => x.ObterPorId(_funcionario.Id));
            resultado.Id.Should().Be(_funcionario.Id);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Funcionario_Aplicacao_ObterTodos_Deve_Obter_Pelo_Menos_Um_Funcionario()
        {
            _mockRepositorio.Setup(x => x.ObterTodos()).Returns(new List<Funcionario>() { new Funcionario() });

            var resultado = _funcionarioServico.ObterTodos();

            _mockRepositorio.Verify(x => x.ObterTodos());
            resultado.Count().Should().BeGreaterThan(0);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Funcionario_Aplicacao_Excluir_Deve_Deletar_Um_Funcionario_Sem_Vinculo()
        {
            _funcionario.Id = 1;
            _mockRepositorio.Setup(x => x.Deletar(_funcionario));
            _mockRepositorio.Setup(x => x.ObterPorId(_funcionario.Id));

            _funcionarioServico.Excluir(_funcionario);

            var resultado = _funcionarioServico.ObterPorId(_funcionario.Id);
            _mockRepositorio.Verify(x => x.ObterPorId(_funcionario.Id));
            _mockRepositorio.Verify(x => x.Deletar(_funcionario));
            resultado.Should().BeNull();
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Funcionario_Aplicacao_BuscarPorNome_Deve_Buscar_Por_Nome_Dado()
        {
            _funcionario.Nome = "Novo nome";
            _mockRepositorio.Setup(x => x.Salvar(_funcionario)).Returns(new Funcionario() { Id = 1, Nome = _funcionario.Nome });
            _mockRepositorio.Setup(x => x.BuscarPorNome(_funcionario.Nome)).Returns(new Funcionario() { Id = 1, Nome = _funcionario.Nome });
            _funcionarioServico.Adicionar(_funcionario);

            var resultado = _funcionarioServico.BuscarPorNome(_funcionario.Nome);

            _mockRepositorio.Verify(x => x.Salvar(_funcionario));
            _mockRepositorio.Verify(x => x.BuscarPorNome(_funcionario.Nome));
            resultado.Nome.Should().Be(_funcionario.Nome);
            _mockRepositorio.VerifyNoOtherCalls();
        }
    }
}
