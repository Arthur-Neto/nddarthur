using Projeto_NFe.Dominio.Base;
using System.Collections.Generic;

namespace Projeto_NFe.Dominio.Features.NotasFiscais
{
    public interface INotaFiscalRepositorio : IRepositorio<NotaFiscal>
    {
        void InserirNotaFiscalEmitida(NotaFiscal notaFiscal);
        bool ValidarExistenciaPorChave(string chave);
        NotaFiscal ObterPorChave(string chave);

        NotaFiscal ObterPorDestinatarioID(long destinatarioId);
        NotaFiscal ObterPorEmitenteID(long emitenteId);
        NotaFiscal ObterPorTransportadorID(long transportadorId);
    }
}
