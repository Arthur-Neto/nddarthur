using Prova1.Infra.ORM.Contexts;
using System.Data.Common;

namespace Prova1.Infra.Data.Tests.Context
{
    /// <summary>
    /// Esse contexto deve ser usado para testar o EF através do Framework Effort
    /// </summary>
    public class FakeDbContext : Prova1DbContext
    {
        public FakeDbContext(DbConnection connection) : base(connection)
        {
        }
    }
}
