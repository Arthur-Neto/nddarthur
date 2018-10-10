using Prova1.Infra.ORM.Contexts;
using System.Data.Entity.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace Prova1.Infra.ORM.Initializer
{
    /// <summary>
    /// Define as configurações para realização da migração do banco conforme alterações no o
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MigrationConfiguration : DbMigrationsConfiguration<Prova1DbContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Prova1DbContext context)
        {
            // Popula o banco
        }
    }
}
