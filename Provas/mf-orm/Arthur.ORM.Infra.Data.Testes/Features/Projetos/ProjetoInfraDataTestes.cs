using Arthur.ORM.Common.Testes.Base;
using Arthur.ORM.Common.Testes.Features;
using Arthur.ORM.Dominio.Features.Projetos;
using Arthur.ORM.Infra.Data.Base;
using Arthur.ORM.Infra.Data.Features.Projetos;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace Arthur.ORM.Infra.Data.Testes.Features.Projetos
{
    [TestFixture]
    public class ProjetoInfraDataTestes
    {
        EmpresaContexto _contexto;
        IProjetoRepositorio _projetoRepositorio;
        Projeto _projeto;

        [SetUp]
        public void SetUp()
        {
            _contexto = new EmpresaContexto();
            _projetoRepositorio = new ProjetoRepositorio(_contexto);
            _projeto = ObjetoMae.ObterProjetoComUmFuncionario();

            Database.SetInitializer(new BaseSqlTestes());
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Projeto_InfraData_Salvar_Deve_Salvar_Projeto_Com_Nome_Valida()
        {
            _projeto.Nome = "Projeto 1";

            var resultado = _projetoRepositorio.Salvar(_projeto);

            resultado.Id.Should().BeGreaterThan(0);
            resultado.Nome.Should().Be(_projeto.Nome);
        }

        [Test]
        public void Projeto_InfraData_Atualizar_Deve_Atualizar_Projeto_Com_Nome_Diferente()
        {
            _projeto.Nome = "Projeto 2";
            var resultadoSalvar = _projetoRepositorio.Salvar(_projeto);
            resultadoSalvar.Nome = "Novo projeto";

            var resultadoAtualizar = _projetoRepositorio.Atualizar(resultadoSalvar);

            resultadoAtualizar.Id.Should().BeGreaterThan(0);
            resultadoAtualizar.Nome.Should().Be(resultadoSalvar.Nome);
        }

        [Test]
        public void Projeto_InfraData_ObterPorId_Deve_Buscar_Projeto_Com_Id_1()
        {
            _projeto.Id = 1;

            var resultado = _projetoRepositorio.ObterPorId(_projeto.Id);

            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(_projeto.Id);
        }

        [Test]
        public void Projeto_InfraData_ObterTodos_Deve_Buscar_Todos_Projetos()
        {
            _projeto = _projetoRepositorio.Salvar(_projeto);

            var resultado = _projetoRepositorio.ObterTodos();

            resultado.Count().Should().BeGreaterThan(0);
            resultado.Last().Id.Should().Be(_projeto.Id);
        }

        [Test]
        public void Projeto_InfraData_Deletar_Deve_Deletar_Projeto_Sem_Vinculo()
        {
            var resultadoSalvar = _projetoRepositorio.Salvar(_projeto);

            _projetoRepositorio.Deletar(resultadoSalvar);

            var resultadoBuscar = _projetoRepositorio.ObterPorId(resultadoSalvar.Id);
            resultadoBuscar.Should().BeNull();
        }
    }
}
