using Arthur.ORM.Dominio.Features.Funcionarios;

namespace Arthur.ORM.Common.Testes.Features
{
    public static partial class ObjetoMae
    {
        public static Funcionario ObterFuncionarioSemCargoSemDepartamento()
        {
            return new Funcionario() { Endereco = "Rua 123", Nome = "Funcionario X", CPF = "12312123123" };
        }

        public static Funcionario ObterFuncionarioComCargoEDepartamento()
        {
            return new Funcionario() { Endereco = "Rua 123", Nome = "Funcionario X", CPF = "12312123123", Cargo = ObterCargoValido(), Departamento = ObterDepartamentoValido() };
        }
    }
}
