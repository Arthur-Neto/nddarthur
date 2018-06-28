using Projeto_NFe.Dominio.Base;

namespace Projeto_NFe.Dominio.Features.Transportadores
{
    public interface ITransportadorRepositorio : IRepositorio<Transportador>
    {
        Transportador ObterPorEnderecoID(long id);

    }
}
