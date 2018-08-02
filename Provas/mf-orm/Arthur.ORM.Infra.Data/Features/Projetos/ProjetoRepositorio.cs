using Arthur.ORM.Dominio.Features.Projetos;
using Arthur.ORM.Infra.Data.Base;

namespace Arthur.ORM.Infra.Data.Features.Projetos
{
    public class ProjetoRepositorio : RepositorioGenerico<Projeto>, IProjetoRepositorio
    {
        public ProjetoRepositorio(EmpresaContexto context) : base(context)
        {
        }
    }
}
