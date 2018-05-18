using Loterica.Dominio.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Loterica.Dominio.Features.Apostas
{
    public class ApostaValorInsufficientException : BusinessException
    {
        public ApostaValorInsufficientException() : base("O valor deve ser maior que R$3,50")
        {
        }
    }
}