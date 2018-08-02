using Arthur.ORM.Dominio.Base;

namespace Arthur.ORM.Dominio.Features.Cargos
{
    public interface ICargoRepositorio : IRepositorio<Cargo>
    {
        Cargo BuscarPorDescricao(string descricao);
    }
}
