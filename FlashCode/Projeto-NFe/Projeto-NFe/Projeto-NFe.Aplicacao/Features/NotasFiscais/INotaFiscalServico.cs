using Projeto_NFe.Dominio.Base;
using Projeto_NFe.Dominio.Features.NotasFiscais;

namespace Projeto_NFe.Aplicacao.Features.NotasFiscais
{
    public interface INotaFiscalServico : IServico<NotaFiscal>
    {
        bool EmitirNota(NotaFiscal notaFiscal);
        void ExportarNota(NotaFiscal notaFiscal);
    }
}
