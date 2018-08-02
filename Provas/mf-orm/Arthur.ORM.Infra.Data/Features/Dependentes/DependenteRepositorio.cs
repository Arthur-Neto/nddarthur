using Arthur.ORM.Dominio.Features.Dependentes;
using Arthur.ORM.Infra.Data.Base;

namespace Arthur.ORM.Infra.Data.Features.Dependentes
{
    public class DependenteRepositorio : RepositorioGenerico<Dependente>, IDependenteRepositorio
    {
        public DependenteRepositorio(EmpresaContexto context) : base(context)
        {
        }
    }
}
