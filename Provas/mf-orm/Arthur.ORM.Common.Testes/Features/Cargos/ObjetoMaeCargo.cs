using Arthur.ORM.Dominio.Features.Cargos;

namespace Arthur.ORM.Common.Testes.Features
{
    public static partial class ObjetoMae
    {
        public static Cargo ObterCargoValido()
        {
            return new Cargo() { Descricao = "Cargo X" };
        }
    }
}
