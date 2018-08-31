using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Domain.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class Entity
    {
        public virtual long Id { get; set; }
    }
}
