using Loterica.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Loterica.Dominio.Features.Apostas
{
    [ExcludeFromCodeCoverage]
    public class ApostaConcursoNullException : BusinessException
    {
        public ApostaConcursoNullException() : base("O concurso não pode ser nulo")
        {
        }
    }
}