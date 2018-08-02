using Arthur.ORM.Common.Testes.Base;
using Arthur.ORM.Common.Testes.Features;
using Arthur.ORM.Dominio.Features.Cargos;
using Arthur.ORM.Infra.Data.Base;
using Arthur.ORM.Infra.Data.Features.Cargos;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Data.Entity;
using System.Linq;

namespace Arthur.ORM.Infra.Data.Testes.Features.Cargos
{
    [TestFixture]
    public class CargoInfraDataTestes
    {
        EmpresaContexto _contexto;
        ICargoRepositorio _cargoRepositorio;
        Cargo _cargo;

        [SetUp]
        public void SetUp()
        {
            _contexto = new EmpresaContexto();
            _cargoRepositorio = new CargoRepositorio(_contexto);
            _cargo = ObjetoMae.ObterCargoValido();

            Database.SetInitializer(new BaseSqlTestes());
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Cargo_InfraData_Salvar_Deve_Salvar_Cargo_Com_Descricao_Valida()
        {
            _cargo.Descricao = "Valido";

            var resultado = _cargoRepositorio.Salvar(_cargo);

            resultado.Id.Should().BeGreaterThan(0);
            resultado.Descricao.Should().Be(_cargo.Descricao);
        }

        [Test]
        public void Cargo_InfraData_Atualizar_Deve_Atualizar_Cargo_Com_Descricao_Diferente()
        {
            _cargo.Descricao = "Valido";
            var resultadoSalvar = _cargoRepositorio.Salvar(_cargo);
            resultadoSalvar.Descricao = "Nova descrição";

            var resultadoAtualizar = _cargoRepositorio.Atualizar(resultadoSalvar);

            resultadoAtualizar.Id.Should().BeGreaterThan(0);
            resultadoAtualizar.Descricao.Should().Be(resultadoSalvar.Descricao);
        }

        [Test]
        public void Cargo_InfraData_ObterPorId_Deve_Buscar_Cargo_Com_Id_1()
        {
            _cargo.Id = 1;

            var resultado = _cargoRepositorio.ObterPorId(_cargo.Id);

            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(_cargo.Id);
        }

        [Test]
        public void Cargo_InfraData_ObterTodos_Deve_Buscar_Todos_Cargos()
        {
            _cargo = _cargoRepositorio.Salvar(_cargo);

            var resultado = _cargoRepositorio.ObterTodos();

            resultado.Count().Should().BeGreaterThan(0);
            resultado.Last().Id.Should().Be(_cargo.Id);
        }

        [Test]
        public void Cargo_InfraData_Deletar_Deve_Deletar_Cargo_Sem_Vinculo()
        {
            var resultadoSalvar = _cargoRepositorio.Salvar(_cargo);

            _cargoRepositorio.Deletar(resultadoSalvar);

            var resultadoBuscar = _cargoRepositorio.ObterPorId(resultadoSalvar.Id);
            resultadoBuscar.Should().BeNull();
        }

        [Test]
        public void Cargo_Infra_Data_BuscarPorDescricao_Deve_Buscar_Um_Cargo_Por_Descricao_Dada()
        {
            _cargo.Descricao = "Descricao Buscar";
            _cargoRepositorio.Salvar(_cargo);

            var resultado = _cargoRepositorio.BuscarPorDescricao(_cargo.Descricao);

            resultado.Descricao.Should().Be(_cargo.Descricao);
        }
    }
}
