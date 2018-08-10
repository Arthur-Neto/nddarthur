using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Infra.Data.Base
{
    [ExcludeFromCodeCoverage]
    public class DbContextFactory : IDbContextFactory<BankContext>
    {
        public BankContext Create()
        {
            return new BankContext();
        }
    }
}
