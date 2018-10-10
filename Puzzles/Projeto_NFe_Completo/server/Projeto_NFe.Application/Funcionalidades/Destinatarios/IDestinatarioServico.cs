using Projeto_NFe.Application.Funcionalidades.Destinatarios.Comandos;
using Projeto_NFe.Application.Funcionalidades.Destinatarios.Modelos;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using System.Linq;

namespace Projeto_NFe.Application.Funcionalidades.Destinatarios
{
    public interface IDestinatarioServico
    {
        long Adicionar(DestinatarioAdicionarComando comando);
        bool Atualizar(DestinatarioEditarComando comando);
        bool Excluir(DestinatarioRemoverComando comando);
        IQueryable<Destinatario> BuscarTodos();
        Destinatario BuscarPorId(long id);
    }
}
