using Arthur.ORM.Aplicacao.Features.Departamentos;
using Arthur.ORM.Common.Testes.Base;
using Arthur.ORM.Common.Testes.Features;
using Arthur.ORM.Dominio.Features.Departamentos;
using Arthur.ORM.Infra.Data.Base;
using Arthur.ORM.Infra.Data.Features.Departamentos;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace Arthur.ORM.IntegracaoSistema.Testes.Features.Departamentos
{
    [TestFixture]
    public class DepartamentoIntegracaoSistemaTestes
    {
        IDepartamentoRepositorio _repositorio;
        IDepartamentoServico _departamentoServico;
        EmpresaContexto _context;
        Departamento _departamento;

        [SetUp]
        public void SetUp()
        {
            _departamento = ObjetoMae.ObterDepartamentoValido();
            _context = new EmpresaContexto();
            _repositorio = new DepartamentoRepositorio(_context);
            _departamentoServico = new DepartamentoServico(_repositorio);

            Database.SetInitializer(new BaseSqlTestes());
            _context.Database.Initialize(true);
        }

        [Test]
        public void Departamento_IntegracaoSistema_Salvar_Deve_Salvar_Departamento_Com_Descricao_Valida()
        {
            _departamento.Descricao = "Nova descrição";

            var resultado = _departamentoServico.Adicionar(_departamento);

            resultado.Descricao.Should().Be(_departamento.Descricao);
        }

        [Test]
        public void Departamento_IntegracaoSistema_Atualizar_Deve_Atualizar_Descricao_Do_Departamento_Com_Id_1()
        {
            _departamento.Id = 1;
            _departamento.Descricao = "Nova descrição";
            _departamento = _departamentoServico.ObterPorId(_departamento.Id);

            var resultado = _departamentoServico.Atualizar(_departamento);

            resultado.Descricao.Should().Be(_departamento.Descricao);
        }

        [Test]
        public void Departamento_IntegracaoSistema_ObterPorId_Deve_Pegar_Departamento_Com_Id_1()
        {
            _departamento.Id = 1;

            var resultado = _departamentoServico.ObterPorId(_departamento.Id);

            resultado.Id.Should().Be(_departamento.Id);
        }

        [Test]
        public void Departamento_IntegracaoSistema_ObterTodos_Deve_Obter_Pelo_Menos_Um_Departamento()
        {
            var resultado = _departamentoServico.ObterTodos();

            resultado.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Departamento_IntegracaoSistema_Excluir_Deve_Deletar_Um_Departamento_Sem_Vinculo()
        {
            _departamento = _departamentoServico.Adicionar(_departamento);

            _departamentoServico.Excluir(_departamento);

            var resultado = _departamentoServico.ObterPorId(_departamento.Id);
            resultado.Should().BeNull();
        }
    }
}
