using Arthur.ORM.Aplicacao.Features.Funcionarios;
using Arthur.ORM.Common.Testes.Base;
using Arthur.ORM.Common.Testes.Features;
using Arthur.ORM.Dominio.Features.Funcionarios;
using Arthur.ORM.Infra.Data.Base;
using Arthur.ORM.Infra.Data.Features.Funcionarios;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace Arthur.ORM.IntegracaoSistema.Testes.Features.Funcionarios
{
    [TestFixture]
    public class FuncionarioIntegracaoSistemaTestes
    {
        IFuncionarioRepositorio _repositorio;
        IFuncionarioServico _funcionarioServico;
        EmpresaContexto _context;
        Funcionario _funcionario;

        [SetUp]
        public void SetUp()
        {
            _funcionario = ObjetoMae.ObterFuncionarioComCargoEDepartamento();
            _context = new EmpresaContexto();
            _repositorio = new FuncionarioRepositorio(_context);
            _funcionarioServico = new FuncionarioServico(_repositorio);

            Database.SetInitializer(new BaseSqlTestes());
            _context.Database.Initialize(true);
        }

        [Test]
        public void Funcionario_IntegracaoSistema_Salvar_Deve_Salvar_Funcionario_Com_Nome_Valido()
        {
            _funcionario.Nome = "Novo nome";

            var resultado = _funcionarioServico.Adicionar(_funcionario);

            resultado.Nome.Should().Be(_funcionario.Nome);
        }

        [Test]
        public void Funcionario_IntegracaoSistema_Atualizar_Deve_Atualizar_Nome_Do_Funcionario_Com_Id_1()
        {
            _funcionario.Id = 1;
            _funcionario.Nome = "Novo nome";
            _funcionario = _funcionarioServico.ObterPorId(_funcionario.Id);

            var resultado = _funcionarioServico.Atualizar(_funcionario);

            resultado.Nome.Should().Be(_funcionario.Nome);
        }

        [Test]
        public void Funcionario_IntegracaoSistema_ObterPorId_Deve_Pegar_Funcionario_Com_Id_1()
        {
            _funcionario.Id = 1;

            var resultado = _funcionarioServico.ObterPorId(_funcionario.Id);

            resultado.Id.Should().Be(_funcionario.Id);
        }

        [Test]
        public void Funcionario_IntegracaoSistema_ObterTodos_Deve_Obter_Pelo_Menos_Um_Funcionario()
        {
            var resultado = _funcionarioServico.ObterTodos();

            resultado.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Funcionario_IntegracaoSistema_Excluir_Deve_Deletar_Um_Funcionario_Sem_Vinculo()
        {
            _funcionario = _funcionarioServico.Adicionar(_funcionario);

            _funcionarioServico.Excluir(_funcionario);

            var resultado = _funcionarioServico.ObterPorId(_funcionario.Id);
            resultado.Should().BeNull();
        }

        [Test]
        public void Funcionario_IntegracaoSistema_BuscarPorNome_Deve_Buscar_Por_Nome_Dado()
        {
            _funcionario.Nome = "Novo nome";
            _funcionarioServico.Adicionar(_funcionario);

            var resultado = _funcionarioServico.BuscarPorNome(_funcionario.Nome);

            resultado.Nome.Should().Be(_funcionario.Nome);
        }
    }
}
