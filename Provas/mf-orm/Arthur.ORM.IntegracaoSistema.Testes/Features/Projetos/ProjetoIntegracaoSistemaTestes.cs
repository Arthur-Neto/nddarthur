using Arthur.ORM.Aplicacao.Features.Projetos;
using Arthur.ORM.Common.Testes.Base;
using Arthur.ORM.Common.Testes.Features;
using Arthur.ORM.Dominio.Features.Projetos;
using Arthur.ORM.Infra.Data.Base;
using Arthur.ORM.Infra.Data.Features.Projetos;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace Arthur.ORM.IntegracaoSistema.Testes.Features.Projetos
{
    [TestFixture]
    public class ProjetoIntegracaoSistemaTestes
    {
        IProjetoRepositorio _repositorio;
        IProjetoServico _projetoServico;
        EmpresaContexto _context;
        Projeto _projeto;

        [SetUp]
        public void SetUp()
        {
            _projeto = ObjetoMae.ObterProjetoComUmFuncionario();
            _context = new EmpresaContexto();
            _repositorio = new ProjetoRepositorio(_context);
            _projetoServico = new ProjetoServico(_repositorio);

            Database.SetInitializer(new BaseSqlTestes());
            _context.Database.Initialize(true);
        }

        [Test]
        public void Projeto_IntegracaoSistema_Salvar_Deve_Salvar_Projeto_Com_Nome_Valido()
        {
            _projeto.Nome = "Novo nome";

            var resultado = _projetoServico.Adicionar(_projeto);

            resultado.Nome.Should().Be(_projeto.Nome);
        }

        [Test]
        public void Projeto_IntegracaoSistema_Atualizar_Deve_Atualizar_Nome_Do_Projeto_Com_Id_1()
        {
            _projeto.Id = 1;
            _projeto.Nome = "Novo nome";
            _projeto = _projetoServico.ObterPorId(_projeto.Id);

            var resultado = _projetoServico.Atualizar(_projeto);

            resultado.Nome.Should().Be(_projeto.Nome);
        }

        [Test]
        public void Projeto_IntegracaoSistema_ObterPorId_Deve_Pegar_Projeto_Com_Id_1()
        {
            _projeto.Id = 1;

            var resultado = _projetoServico.ObterPorId(_projeto.Id);

            resultado.Id.Should().Be(_projeto.Id);
        }

        [Test]
        public void Projeto_IntegracaoSistema_ObterTodos_Deve_Obter_Pelo_Menos_Um_Projeto()
        {
            var resultado = _projetoServico.ObterTodos();

            resultado.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Projeto_IntegracaoSistema_Excluir_Deve_Deletar_Um_Projeto_Sem_Vinculo()
        {
            _projeto = _projetoServico.Adicionar(_projeto);

            _projetoServico.Excluir(_projeto);

            var resultado = _projetoServico.ObterPorId(_projeto.Id);
            resultado.Should().BeNull();
        }
    }
}
