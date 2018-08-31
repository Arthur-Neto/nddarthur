using Arthur.MF7.Infra.ORM.Base;
using Arthur.MF7.Infra.ORM.Migrations;
using System.Data.Entity;

namespace Arthur.MF7.Infra.ORM.Initializer
{
    public class DbInitializer : MigrateDatabaseToLatestVersion<MF7Context, Configuration>
    {
    }
}
