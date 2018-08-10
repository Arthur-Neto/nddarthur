using Bank.Infra.Data.Base;
using Bank.Infra.Data.Migrations;
using System.Data.Entity;

namespace Bank.Infra.Data.Initializer
{
    public class DbInitializer : MigrateDatabaseToLatestVersion<BankContext, Configuration>
    {
    }
}
