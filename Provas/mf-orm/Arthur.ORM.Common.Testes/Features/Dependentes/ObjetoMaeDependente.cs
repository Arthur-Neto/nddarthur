using Arthur.ORM.Dominio.Features.Dependentes;

namespace Arthur.ORM.Common.Testes.Features
{
    public static partial class ObjetoMae
    {
        public static Dependente ObterDependenteSemFuncionario()
        {
            return new Dependente() { Idade = 10, Nome = "Dependente X" };
        }

        public static Dependente ObterDependenteDeUmFuncionario()
        {
            var dependente = new Dependente() { Idade = 10, Nome = "Dependente de um Funcionario" };
            dependente.Funcionarios.Add(ObterFuncionarioComCargoEDepartamento());
            return dependente;
        }
    }
}
