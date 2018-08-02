using Arthur.ORM.Aplicacao.Features.Cargos;
using Arthur.ORM.Common.Testes.Base;
using Arthur.ORM.Common.Testes.Features;
using Arthur.ORM.Dominio.Features.Cargos;
using Arthur.ORM.Infra.Data.Base;
using Arthur.ORM.Infra.Data.Features.Cargos;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace Arthur.ORM.IntegracaoSistema.Testes.Features.Cargos
{
    [TestFixture]
    public class CargoIntegracaoSistemaTestes
    {
        ICargoRepositorio _repositorio;
        ICargoServico _cargoServico;
        EmpresaContexto _context;
        Cargo _cargo;

        [SetUp]
        public void SetUp()
        {
            _cargo = ObjetoMae.ObterCargoValido();
            _context = new EmpresaContexto();
            _repositorio = new CargoRepositorio(_context);
            _cargoServico = new CargoServico(_repositorio);

            Database.SetInitializer(new BaseSqlTestes());
            _context.Database.Initialize(true);
        }

        [Test]
        public void Cargo_IntegracaoSistema_Salvar_Deve_Salvar_Cargo_Com_Descricao_Valida()
        {
            _cargo.Descricao = "Nova descrição";

            var resultado = _cargoServico.Adicionar(_cargo);

            resultado.Descricao.Should().Be(_cargo.Descricao);
        }

        [Test]
        public void Cargo_IntegracaoSistema_Atualizar_Deve_Atualizar_Descricao_Do_Cargo_Com_Id_1()
        {
            _cargo.Id = 1;
            _cargo.Descricao = "Nova descrição";
            _cargo = _cargoServico.ObterPorId(_cargo.Id);

            var resultado = _cargoServico.Atualizar(_cargo);

            resultado.Descricao.Should().Be(_cargo.Descricao);
        }

        [Test]
        public void Cargo_IntegracaoSistema_ObterPorId_Deve_Pegar_Cargo_Com_Id_1()
        {
            _cargo.Id = 1;

            var resultado = _cargoServico.ObterPorId(_cargo.Id);

            resultado.Id.Should().Be(_cargo.Id);
        }

        [Test]
        public void Cargo_IntegracaoSistema_ObterTodos_Deve_Obter_Pelo_Menos_Um_Cargo()
        {
            var resultado = _cargoServico.ObterTodos();

            resultado.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Cargo_IntegracaoSistema_Excluir_Deve_Deletar_Um_Cargo_Sem_Vinculo()
        {
            _cargo = _cargoServico.Adicionar(_cargo);

            _cargoServico.Excluir(_cargo);

            var resultado = _cargoServico.ObterPorId(_cargo.Id);
            resultado.Should().BeNull();
        }

        [Test]
        public void Cargo_IntegracaoSistema_BuscarPorDescricao_Deve_Buscar_Por_Descricao_Dado()
        {
            _cargo.Descricao = "Nova descricao";
            _cargoServico.Adicionar(_cargo);

            var resultado = _cargoServico.BuscarPorDescricao(_cargo.Descricao);

            resultado.Descricao.Should().Be(_cargo.Descricao);
        }
    }
}
