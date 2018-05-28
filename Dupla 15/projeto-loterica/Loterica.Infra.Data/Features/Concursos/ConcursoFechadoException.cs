using System;
using System.Diagnostics.CodeAnalysis;

namespace Loterica.Infra.Data.Features.Concursos
{
    [ExcludeFromCodeCoverage]
    public class ConcursoFechadoException : Exception
    {
        public ConcursoFechadoException() : base ("Não é possivel editar um concurso fechado")
        {
        }
    }
}