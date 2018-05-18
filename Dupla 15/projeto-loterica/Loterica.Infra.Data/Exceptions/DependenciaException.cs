using System;
using System.Runtime.Serialization;

namespace Loterica.Infra.Data.Exceptions
{
    [Serializable]
    public class DependenciaException : Exception
    {
        public DependenciaException() : base("Não pode remover a entidade com dependencias")
        {
        }
    }
}