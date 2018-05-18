using Loterica.Dominio.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Loterica.Dominio.Features.Resultados
{
    public class ResultadoNumerosSorteadosInsufficientException : BusinessException
    {
        public ResultadoNumerosSorteadosInsufficientException() : base("O resultado deve conter pelo menos 6 numeros")
        {
        }
    }
}