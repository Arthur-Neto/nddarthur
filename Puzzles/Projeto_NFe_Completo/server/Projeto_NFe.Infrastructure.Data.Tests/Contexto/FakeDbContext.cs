using Projeto_NFe.Infrastructure.Data.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Tests.Context
{
    public class FakeDbContext : ProjetoNFeContexto
    {
        public FakeDbContext(DbConnection connection) : base(connection)
        {

        }
    }
}
