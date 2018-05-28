using Loterica.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Loterica.Dominio.Features.Boloes
{
    [ExcludeFromCodeCoverage]
    public class BolaoApostasInsuficienteException : BusinessException
    {
        public BolaoApostasInsuficienteException() : base("O numero de apostas deve ser maior que 2")
        {
        }
    }
}
