using Arthur.MF7.Infra.ORM.Base;
using System.Data.Common;


namespace Arthur.MF7.Infra.ORM.Tests.Context
{
    public class FakeDbContext : MF7Context
    {
        public FakeDbContext(DbConnection connection) : base(connection)
        {
        }
    }
}
