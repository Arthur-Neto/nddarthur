using System;
using System.Diagnostics.CodeAnalysis;

namespace Loterica.Infra.Data.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class DependenciaException : Exception
    {
        public DependenciaException() : base("Não pode remover a entidade com dependencias")
        {
        }
    }
}