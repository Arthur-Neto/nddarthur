using Projeto_NFe.Application.Funcionalidades.Transportadoras.Comandos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using System.Linq;

namespace Projeto_NFe.Application.Funcionalidades.Transportadoras
{
    public interface ITransportadorServico
    {
        long Adicionar(TransportadorAdicionarComando comando);
        bool Atualizar(TransportadorEditarComando comando);
        bool Excluir(TransportadorRemoverComando comando);
        IQueryable<Transportador> BuscarTodos();
        Transportador BuscarPorId(long id);
    }
}
