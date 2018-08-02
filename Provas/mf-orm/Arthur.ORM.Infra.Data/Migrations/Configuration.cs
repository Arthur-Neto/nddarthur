namespace Arthur.ORM.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Arthur.ORM.Infra.Data.Base.EmpresaContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Arthur.ORM.Infra.Data.Base.EmpresaContexto";
        }

        protected override void Seed(Arthur.ORM.Infra.Data.Base.EmpresaContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
