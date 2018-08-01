using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace MF6.Infra.ORM.Contexts {

    [ExcludeFromCodeCoverage]
    public class DbContextFactory : IDbContextFactory<MF6Context> {

        public MF6Context Create() {
            return new MF6Context();
        }
    }
}