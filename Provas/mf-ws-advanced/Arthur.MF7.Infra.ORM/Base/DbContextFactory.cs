using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Infra.ORM.Base
{
    [ExcludeFromCodeCoverage]
    public class DbContextFactory : IDbContextFactory<MF7Context>
    {
        public MF7Context Create()
        {
            return new MF7Context();
        }
    }
}
