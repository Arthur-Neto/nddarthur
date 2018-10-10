using Projeto_NFe.Application.Funcionalidades.Notas_Fiscais.Comandos;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using System;
using System.Linq;

namespace Projeto_NFe.Application.Funcionalidades.Notas_Fiscais
{
    public interface INotaFiscalServico
    {
        long Adicionar(NotaFiscalAdicionarComando comando);
        bool Atualizar(NotaFiscalEditarComando comando);
        bool Excluir(NotaFiscalRemoverComando comando);
        IQueryable<NotaFiscal> BuscarTodos();
        NotaFiscal BuscarPorId(long id);
        bool ConsultarExistenciaDeNotaEmitida(string chaveDeAcesso);
        NotaFiscal Emitir(NotaFiscal notaFiscal, Random sorteador);
        NotaFiscal BuscarNotaFiscalEmitidaPorChave(string chaveDeAcesso);
    }
}
