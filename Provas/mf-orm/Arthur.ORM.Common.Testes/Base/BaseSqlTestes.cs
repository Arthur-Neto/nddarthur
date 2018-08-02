using Arthur.ORM.Common.Testes.Features;
using Arthur.ORM.Infra.Data.Base;
using System.Data.Entity;

namespace Arthur.ORM.Common.Testes.Base
{
    public class BaseSqlTestes : DropCreateDatabaseAlways<EmpresaContexto>
    {
        protected override void Seed(EmpresaContexto context)
        {
            var cargo = context.Cargos.Add(ObjetoMae.ObterCargoValido());
            var dep = context.Departamentos.Add(ObjetoMae.ObterDepartamentoValido());
            var funcionario = ObjetoMae.ObterFuncionarioSemCargoSemDepartamento();
            funcionario.Cargo = cargo;
            funcionario.Departamento = dep;
            context.Funcionarios.Add(funcionario);

            var dependente = ObjetoMae.ObterDependenteSemFuncionario();
            dependente.Funcionarios.Add(funcionario);
            context.Dependentes.Add(dependente);

            var projeto = ObjetoMae.ObterProjetoSemEquipe();
            projeto.Equipe.Add(funcionario);
            context.Projetos.Add(projeto);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
