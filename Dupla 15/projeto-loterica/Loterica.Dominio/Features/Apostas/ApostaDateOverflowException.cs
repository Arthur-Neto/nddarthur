using Loterica.Dominio.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Loterica.Dominio.Features.Apostas
{
    public class ApostaDateOverflowException : BusinessException
    {
        public ApostaDateOverflowException() : base("A data da aposta não pode ser menor que a data do concurso")
        {
        }
    }
}