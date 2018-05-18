using Loterica.Dominio.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Loterica.Dominio.Features.Apostas
{
    public class ApostaConcursoNullException : BusinessException
    {
        public ApostaConcursoNullException() : base("O concurso não pode ser nulo")
        {
        }
    }
}