using ProvaTDD.Dominio.Exceptions;

namespace ProvaTDD.Dominio.Features.Resultados
{
    public class ResultadoNotaInvalidaException : BusinessException
    {
        public ResultadoNotaInvalidaException() : base("Resultado deve conter uma nota válida")
        {
        }
    }
}