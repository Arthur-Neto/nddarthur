using Arthur.ORM.Aplicacao.Features.Dependentes;
using Arthur.ORM.Common.Testes.Base;
using Arthur.ORM.Common.Testes.Features;
using Arthur.ORM.Dominio.Features.Dependentes;
using Arthur.ORM.Infra.Data.Base;
using Arthur.ORM.Infra.Data.Features.Dependentes;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace Arthur.ORM.IntegracaoSistema.Testes.Features.Dependentes
{
    [TestFixture]
    public class DependenteIntegracaoSistemaTestes
    {
        IDependenteRepositorio _repositorio;
        IDependenteServico _dependenteServico;
        EmpresaContexto _context;
        Dependente _dependente;

        [SetUp]
        public void SetUp()
        {
            _dependente = ObjetoMae.ObterDependenteDeUmFuncionario();
            _context = new EmpresaContexto();
            _repositorio = new DependenteRepositorio(_context);
            _dependenteServico = new DependenteServico(_repositorio);

            Database.SetInitializer(new BaseSqlTestes());
            _context.Database.Initialize(true);
        }

        [Test]
        public void Dependente_IntegracaoSistema_Salvar_Deve_Salvar_Dependente_Com_Nome_Valido()
        {
            _dependente.Nome = "Nome";

            var resultado = _dependenteServico.Adicionar(_dependente);

            resultado.Nome.Should().Be(_dependente.Nome);
        }

        [Test]
        public void Dependente_IntegracaoSistema_Atualizar_Deve_Atualizar_Nome_Do_Dependente_Com_Id_1()
        {
            _dependente.Id = 1;
            _dependente.Nome = "Novo nome";
            _dependente = _dependenteServico.ObterPorId(_dependente.Id);

            var resultado = _dependenteServico.Atualizar(_dependente);

            resultado.Nome.Should().Be(_dependente.Nome);
        }

        [Test]
        public void Dependente_IntegracaoSistema_ObterPorId_Deve_Pegar_Dependente_Com_Id_1()
        {
            _dependente.Id = 1;

            var resultado = _dependenteServico.ObterPorId(_dependente.Id);

            resultado.Id.Should().Be(_dependente.Id);
        }

        [Test]
        public void Dependente_IntegracaoSistema_ObterTodos_Deve_Obter_Pelo_Menos_Um_Dependente()
        {
            var resultado = _dependenteServico.ObterTodos();

            resultado.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Dependente_IntegracaoSistema_Excluir_Deve_Deletar_Um_Dependente_Sem_Vinculo()
        {
            _dependente = _dependenteServico.Adicionar(_dependente);

            _dependenteServico.Excluir(_dependente);

            var resultado = _dependenteServico.ObterPorId(_dependente.Id);
            resultado.Should().BeNull();
        }
    }
}
