using MF6.Infra.ORM.Contexts;
using System.Data.Common;

namespace MF6.Infra.ORM.Tests.Contexts {

    public class FakeDbContext : MF6Context {

        public FakeDbContext(DbConnection connection) : base(connection) {
        }
    }
}