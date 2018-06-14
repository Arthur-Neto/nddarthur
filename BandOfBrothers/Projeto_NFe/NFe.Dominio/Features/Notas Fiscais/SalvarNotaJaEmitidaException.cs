using NFe.Dominio.Exceptions;

namespace NFe.Dominio.Features.Notas_Fiscais
{
    public class SalvarNotaJaEmitidaException : BusinessException
    {
        public SalvarNotaJaEmitidaException() : base("Não é possivel salvar uma nota já emitida")
        {

        }
    }
}
