using Arthur.ORM.Common.Testes.Base;
using Arthur.ORM.Common.Testes.Features;
using Arthur.ORM.Dominio.Features.Dependentes;
using Arthur.ORM.Infra.Data.Base;
using Arthur.ORM.Infra.Data.Features.Dependentes;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace Arthur.ORM.Infra.Data.Testes.Features.Dependentes
{
    [TestFixture]
    public class DependenteInfraDataTestes
    {
        EmpresaContexto _contexto;
        IDependenteRepositorio _dependenteRepositorio;
        Dependente _dependente;

        [SetUp]
        public void SetUp()
        {
            _contexto = new EmpresaContexto();
            _dependenteRepositorio = new DependenteRepositorio(_contexto);
            _dependente = ObjetoMae.ObterDependenteSemFuncionario();

            Database.SetInitializer(new BaseSqlTestes());
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Dependente_InfraData_Salvar_Deve_Salvar_Dependente_Com_Nome_Valida()
        {
            _dependente.Nome = "Fulano";

            var resultado = _dependenteRepositorio.Salvar(_dependente);

            resultado.Id.Should().BeGreaterThan(0);
            resultado.Nome.Should().Be(_dependente.Nome);
        }

        [Test]
        public void Dependente_InfraData_Atualizar_Deve_Atualizar_Dependente_Com_Nome_Diferente()
        {
            _dependente.Nome = "Nome";
            var resultadoSalvar = _dependenteRepositorio.Salvar(_dependente);
            resultadoSalvar.Nome = "Novo nome";

            var resultadoAtualizar = _dependenteRepositorio.Atualizar(resultadoSalvar);

            resultadoAtualizar.Id.Should().BeGreaterThan(0);
            resultadoAtualizar.Nome.Should().Be(resultadoSalvar.Nome);
        }

        [Test]
        public void Dependente_InfraData_ObterPorId_Deve_Buscar_Dependente_Com_Id_1()
        {
            _dependente.Id = 1;

            var resultado = _dependenteRepositorio.ObterPorId(_dependente.Id);

            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(_dependente.Id);
        }

        [Test]
        public void Dependente_InfraData_ObterTodos_Deve_Buscar_Todos_Dependentes()
        {
            _dependente = _dependenteRepositorio.Salvar(_dependente);

            var resultado = _dependenteRepositorio.ObterTodos();

            resultado.Count().Should().BeGreaterThan(0);
            resultado.Last().Id.Should().Be(_dependente.Id);
        }

        [Test]
        public void Dependente_InfraData_Deletar_Deve_Deletar_Dependente_Sem_Vinculo()
        {
            var resultadoSalvar = _dependenteRepositorio.Salvar(_dependente);

            _dependenteRepositorio.Deletar(resultadoSalvar);

            var resultadoBuscar = _dependenteRepositorio.ObterPorId(resultadoSalvar.Id);
            resultadoBuscar.Should().BeNull();
        }
    }
}
