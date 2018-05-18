using Loterica.Dominio.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Loterica.Dominio.Features.Apostas
{
    public class ApostaNumeroInsufficientException : BusinessException
    {
        public ApostaNumeroInsufficientException() : base("A aposta deve conter pelo menos seis numeros")
        {
        }
    }
}