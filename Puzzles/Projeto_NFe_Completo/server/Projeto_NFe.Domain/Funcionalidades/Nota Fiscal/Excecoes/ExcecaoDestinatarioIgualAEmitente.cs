using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoDestinatarioIgualAEmitente : ExcecaoDeNegocio
    {
        public ExcecaoDestinatarioIgualAEmitente() : base(CodigosErros.InvalidObject, "Nota Fiscal deve possuir um destinatário diferente do emitente.")
        {            
        }
    }
}
