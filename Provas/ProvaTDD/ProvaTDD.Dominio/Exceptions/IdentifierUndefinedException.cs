using System.Diagnostics.CodeAnalysis;

namespace ProvaTDD.Dominio.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class IdentifierUndefinedException : BusinessException
    {
        public IdentifierUndefinedException() : base("O id não pode ser vazio")
        {

        }
    }
}
