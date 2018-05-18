using Loterica.Dominio.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Loterica.Dominio.Features.Resultados
{
    public class ResultadoConcursoNullException : BusinessException
    {
        public ResultadoConcursoNullException() : base("O resultado deve ter um concurso definido")
        {
        }
    }
}