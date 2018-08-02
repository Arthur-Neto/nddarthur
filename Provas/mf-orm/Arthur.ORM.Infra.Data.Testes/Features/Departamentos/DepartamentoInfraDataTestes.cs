using Arthur.ORM.Common.Testes.Base;
using Arthur.ORM.Common.Testes.Features;
using Arthur.ORM.Dominio.Features.Departamentos;
using Arthur.ORM.Infra.Data.Base;
using Arthur.ORM.Infra.Data.Features.Departamentos;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace Arthur.ORM.Infra.Data.Testes.Features.Departamentos
{
    [TestFixture]
    public class DepartamentoInfraDataTestes
    {
        EmpresaContexto _contexto;
        IDepartamentoRepositorio _departamentoRepositorio;
        Departamento _departamento;

        [SetUp]
        public void SetUp()
        {
            _contexto = new EmpresaContexto();
            _departamentoRepositorio = new DepartamentoRepositorio(_contexto);
            _departamento = ObjetoMae.ObterDepartamentoValido();

            Database.SetInitializer(new BaseSqlTestes());
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Departamento_InfraData_Salvar_Deve_Salvar_Departamento_Com_Descricao_Valida()
        {
            _departamento.Descricao = "Valido";

            var resultado = _departamentoRepositorio.Salvar(_departamento);

            resultado.Id.Should().BeGreaterThan(0);
            resultado.Descricao.Should().Be(_departamento.Descricao);
        }

        [Test]
        public void Departamento_InfraData_Atualizar_Deve_Atualizar_Departamento_Com_Descricao_Diferente()
        {
            _departamento.Descricao = "Valido";
            var resultadoSalvar = _departamentoRepositorio.Salvar(_departamento);
            resultadoSalvar.Descricao = "Nova descrição";

            var resultadoAtualizar = _departamentoRepositorio.Atualizar(resultadoSalvar);

            resultadoAtualizar.Id.Should().BeGreaterThan(0);
            resultadoAtualizar.Descricao.Should().Be(resultadoSalvar.Descricao);
        }

        [Test]
        public void Departamento_InfraData_ObterPorId_Deve_Buscar_Departamento_Com_Id_1()
        {
            _departamento.Id = 1;

            var resultado = _departamentoRepositorio.ObterPorId(_departamento.Id);

            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(_departamento.Id);
        }

        [Test]
        public void Departamento_InfraData_ObterTodos_Deve_Buscar_Todos_Departamentos()
        {
            _departamento = _departamentoRepositorio.Salvar(_departamento);

            var resultado = _departamentoRepositorio.ObterTodos();

            resultado.Count().Should().BeGreaterThan(0);
            resultado.Last().Id.Should().Be(_departamento.Id);
        }

        [Test]
        public void Departamento_InfraData_Deletar_Deve_Deletar_Departamento_Sem_Vinculo()
        {
            var resultadoSalvar = _departamentoRepositorio.Salvar(_departamento);

            _departamentoRepositorio.Deletar(resultadoSalvar);

            var resultadoBuscar = _departamentoRepositorio.ObterPorId(resultadoSalvar.Id);
            resultadoBuscar.Should().BeNull();
        }
    }
}
