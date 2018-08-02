using Arthur.ORM.Dominio.Features.Departamentos;

namespace Arthur.ORM.Common.Testes.Features
{
    public static partial class ObjetoMae
    {
        public static Departamento ObterDepartamentoValido()
        {
            return new Departamento() { Descricao = "Departamento X" };
        }
    }
}
