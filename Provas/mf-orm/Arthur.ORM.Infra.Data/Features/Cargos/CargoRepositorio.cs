using Arthur.ORM.Dominio.Features.Cargos;
using Arthur.ORM.Infra.Data.Base;
using System.Linq;

namespace Arthur.ORM.Infra.Data.Features.Cargos
{
    public class CargoRepositorio : RepositorioGenerico<Cargo>, ICargoRepositorio
    {
        public CargoRepositorio(EmpresaContexto context) : base(context)
        {
        }

        public Cargo BuscarPorDescricao(string descricao)
        {
            return _contexto.Cargos.Where(c => c.Descricao == descricao).FirstOrDefault();
        }
    }
}
