using Arthur.ORM.Aplicacao.Features.Cargos;
using Arthur.ORM.Common.Testes.Features;
using Arthur.ORM.Dominio.Features.Cargos;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Arthur.ORM.Aplicacao.Testes.Features.Cargos
{
    [TestFixture]
    public class CargoAplicacaoTestes
    {
        Mock<ICargoRepositorio> _mockRepositorio;
        ICargoServico _cargoServico;
        Cargo _cargo;

        [SetUp]
        public void SetUp()
        {
            _cargo = ObjetoMae.ObterCargoValido();
            _mockRepositorio = new Mock<ICargoRepositorio>();
            _cargoServico = new CargoServico(_mockRepositorio.Object);
        }

        [Test]
        public void Cargo_Aplicacao_Salvar_Deve_Salvar_Cargo_Com_Descricao_Valida()
        {
            _cargo.Descricao = "Nova descrição";
            _mockRepositorio.Setup(x => x.Salvar(_cargo)).Returns(new Cargo() { Id = 2, Descricao = _cargo.Descricao });

            var resultado = _cargoServico.Adicionar(_cargo);

            _mockRepositorio.Verify(x => x.Salvar(_cargo));
            resultado.Descricao.Should().Be(_cargo.Descricao);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Cargo_Aplicacao_Atualizar_Deve_Atualizar_Descricao_Do_Cargo_Com_Id_1()
        {
            _cargo.Id = 1;
            _cargo.Descricao = "Nova descrição";
            _mockRepositorio.Setup(x => x.ObterPorId(_cargo.Id)).Returns(new Cargo() { Id = _cargo.Id, Descricao = _cargo.Descricao });
            _cargo = _cargoServico.ObterPorId(_cargo.Id);
            _mockRepositorio.Setup(x => x.Atualizar(_cargo)).Returns(new Cargo() { Id = _cargo.Id, Descricao = _cargo.Descricao });

            var resultado = _cargoServico.Atualizar(_cargo);

            _mockRepositorio.Verify(x => x.ObterPorId(_cargo.Id));
            _mockRepositorio.Verify(x => x.Atualizar(_cargo));
            resultado.Descricao.Should().Be(_cargo.Descricao);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Cargo_Aplicacao_ObterPorId_Deve_Pegar_Cargo_Com_Id_1()
        {
            _cargo.Id = 1;
            _mockRepositorio.Setup(x => x.ObterPorId(_cargo.Id)).Returns(new Cargo() { Id = _cargo.Id });

            var resultado = _cargoServico.ObterPorId(_cargo.Id);

            _mockRepositorio.Verify(x => x.ObterPorId(_cargo.Id));
            resultado.Id.Should().Be(_cargo.Id);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Cargo_Aplicacao_ObterTodos_Deve_Obter_Pelo_Menos_Um_Cargo()
        {
            _mockRepositorio.Setup(x => x.ObterTodos()).Returns(new List<Cargo>() { new Cargo() });

            var resultado = _cargoServico.ObterTodos();

            _mockRepositorio.Verify(x => x.ObterTodos());
            resultado.Count().Should().BeGreaterThan(0);
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Cargo_Aplicacao_Excluir_Deve_Deletar_Um_Cargo_Sem_Vinculo()
        {
            _cargo.Id = 1;
            _mockRepositorio.Setup(x => x.Deletar(_cargo));
            _mockRepositorio.Setup(x => x.ObterPorId(_cargo.Id));

            _cargoServico.Excluir(_cargo);

            var resultado = _cargoServico.ObterPorId(_cargo.Id);
            _mockRepositorio.Verify(x => x.ObterPorId(_cargo.Id));
            _mockRepositorio.Verify(x => x.Deletar(_cargo));
            resultado.Should().BeNull();
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Cargo_Aplicacao_BuscarPorDescricao_Deve_Buscar_Por_Descricao_Dado()
        {
            _cargo.Descricao = "Nova descricao";
            _mockRepositorio.Setup(x => x.Salvar(_cargo)).Returns(new Cargo() { Id = 1, Descricao = _cargo.Descricao });
            _mockRepositorio.Setup(x => x.BuscarPorDescricao(_cargo.Descricao)).Returns(new Cargo() { Id = 1, Descricao = _cargo.Descricao });
            _cargoServico.Adicionar(_cargo);

            var resultado = _cargoServico.BuscarPorDescricao(_cargo.Descricao);

            _mockRepositorio.Verify(x => x.Salvar(_cargo));
            _mockRepositorio.Verify(x => x.BuscarPorDescricao(_cargo.Descricao));
            resultado.Descricao.Should().Be(_cargo.Descricao);
            _mockRepositorio.VerifyNoOtherCalls();
        }
    }
}
