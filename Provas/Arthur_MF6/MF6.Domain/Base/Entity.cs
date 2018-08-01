using System.Diagnostics.CodeAnalysis;

namespace MF6.Domain.Base {

    [ExcludeFromCodeCoverage]
    public abstract class Entity {
        public virtual long Id { get; set; }

        public virtual bool Validate() {
            return true;
        }
    }
}