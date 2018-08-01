namespace MF6.Infra.ORM.Migrations {

    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    internal sealed class Configuration : DbMigrationsConfiguration<MF6.Infra.ORM.Contexts.MF6Context> {

        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MF6.Infra.ORM.Contexts.MF6Context context) {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}