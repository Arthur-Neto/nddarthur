namespace TutorialORM.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public sealed class MigrationConfiguration : DbMigrationsConfiguration<TutorialORM.Infra.Data.Base.EscolaContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TutorialORM.Infra.Data.Base.EscolaContext";
        }

        protected override void Seed(TutorialORM.Infra.Data.Base.EscolaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
