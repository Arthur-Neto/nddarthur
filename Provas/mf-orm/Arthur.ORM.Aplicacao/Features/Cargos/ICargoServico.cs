using Arthur.ORM.Aplicacao.Base;
using Arthur.ORM.Dominio.Features.Cargos;

namespace Arthur.ORM.Aplicacao.Features.Cargos
{
    public interface ICargoServico : IServico<Cargo>
    {
        Cargo BuscarPorDescricao(string descricao);
    }
}
