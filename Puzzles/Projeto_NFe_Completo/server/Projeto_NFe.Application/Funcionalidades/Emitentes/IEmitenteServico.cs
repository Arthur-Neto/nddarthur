using Projeto_NFe.Application.Funcionalidades.Emitentes.Comandos;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using System.Linq;

namespace Projeto_NFe.Application.Funcionalidades.Emitentes
{
    public interface IEmitenteServico
    {
        long Adicionar(EmitenteAdicionarComando comando);
        bool Atualizar(EmitenteEditarComando comando);
        bool Excluir(EmitenteRemoverComando comando);
        IQueryable<Emitente> BuscarTodos();
        Emitente BuscarPorId(long id);
    }
}
