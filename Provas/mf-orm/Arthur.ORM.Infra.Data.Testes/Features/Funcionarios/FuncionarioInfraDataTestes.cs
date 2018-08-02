using Arthur.ORM.Common.Testes.Base;
using Arthur.ORM.Common.Testes.Features;
using Arthur.ORM.Dominio.Features.Funcionarios;
using Arthur.ORM.Infra.Data.Base;
using Arthur.ORM.Infra.Data.Features.Funcionarios;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace Arthur.ORM.Infra.Data.Testes.Features.Funcionarios
{
    [TestFixture]
    public class FuncionarioInfraDataTestes
    {
        EmpresaContexto _contexto;
        IFuncionarioRepositorio _funcionarioRepositorio;
        Funcionario _funcionario;

        [SetUp]
        public void SetUp()
        {
            _contexto = new EmpresaContexto();
            _funcionarioRepositorio = new FuncionarioRepositorio(_contexto);
            _funcionario = ObjetoMae.ObterFuncionarioComCargoEDepartamento();

            Database.SetInitializer(new BaseSqlTestes());
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Funcionario_InfraData_Salvar_Deve_Salvar_Funcionario_Com_Nome_Valida()
        {
            _funcionario.Nome = "Fulano";

            var resultado = _funcionarioRepositorio.Salvar(_funcionario);

            resultado.Id.Should().BeGreaterThan(0);
            resultado.Nome.Should().Be(_funcionario.Nome);
        }

        [Test]
        public void Funcionario_InfraData_Atualizar_Deve_Atualizar_Funcionario_Com_Nome_Diferente()
        {
            _funcionario.Nome = "Nome";
            var resultadoSalvar = _funcionarioRepositorio.Salvar(_funcionario);
            resultadoSalvar.Nome = "Novo nome";

            var resultadoAtualizar = _funcionarioRepositorio.Atualizar(resultadoSalvar);

            resultadoAtualizar.Id.Should().BeGreaterThan(0);
            resultadoAtualizar.Nome.Should().Be(resultadoSalvar.Nome);
        }

        [Test]
        public void Funcionario_InfraData_ObterPorId_Deve_Buscar_Funcionario_Com_Id_1()
        {
            _funcionario.Id = 1;

            var resultado = _funcionarioRepositorio.ObterPorId(_funcionario.Id);

            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(_funcionario.Id);
        }

        [Test]
        public void Funcionario_InfraData_ObterTodos_Deve_Buscar_Todos_Funcionarios()
        {
            _funcionario = _funcionarioRepositorio.Salvar(_funcionario);

            var resultado = _funcionarioRepositorio.ObterTodos();

            resultado.Count().Should().BeGreaterThan(0);
            resultado.Last().Id.Should().Be(_funcionario.Id);
        }

        [Test]
        public void Funcionario_InfraData_Deletar_Deve_Deletar_Funcionario_Sem_Vinculo()
        {
            var resultadoSalvar = _funcionarioRepositorio.Salvar(_funcionario);

            _funcionarioRepositorio.Deletar(resultadoSalvar);

            var resultadoBuscar = _funcionarioRepositorio.ObterPorId(resultadoSalvar.Id);
            resultadoBuscar.Should().BeNull();
        }

        [Test]
        public void Funcionario_Infra_Data_BuscarPorNome_Deve_Buscar_Um_Funcionario_Por_Nome_Dado()
        {
            _funcionario.Nome = "Nome Buscar";
            _funcionarioRepositorio.Salvar(_funcionario);

            var resultado = _funcionarioRepositorio.BuscarPorNome(_funcionario.Nome);

            resultado.Nome.Should().Be(_funcionario.Nome);
        }
    }
}
