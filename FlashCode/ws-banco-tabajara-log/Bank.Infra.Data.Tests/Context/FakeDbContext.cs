using Bank.Infra.Data.Base;
using System.Data.Common;

namespace Bank.Infra.Data.Tests.Context
{
    public class FakeDbContext : BankContext
    {
        public FakeDbContext(DbConnection connection) : base(connection)
        {
        }
    }
}
