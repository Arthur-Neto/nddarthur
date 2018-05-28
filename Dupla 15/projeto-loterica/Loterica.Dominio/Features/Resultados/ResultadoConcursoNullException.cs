using Loterica.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Loterica.Dominio.Features.Resultados
{
    [ExcludeFromCodeCoverage]
    public class ResultadoConcursoNullException : BusinessException
    {
        public ResultadoConcursoNullException() : base("O resultado deve ter um concurso definido")
        {
        }
    }
}