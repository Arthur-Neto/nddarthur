using Arthur.ORM.Dominio.Features.Departamentos;
using Arthur.ORM.Infra.Data.Base;

namespace Arthur.ORM.Infra.Data.Features.Departamentos
{
    public class DepartamentoRepositorio : RepositorioGenerico<Departamento>, IDepartamentoRepositorio
    {
        public DepartamentoRepositorio(EmpresaContexto context) : base(context)
        {
        }
    }
}
