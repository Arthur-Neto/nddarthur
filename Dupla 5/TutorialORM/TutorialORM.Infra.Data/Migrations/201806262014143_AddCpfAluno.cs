namespace TutorialORM.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public partial class AddCpfAluno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBAluno", "Cpf", c => c.String(nullable: false, maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBAluno", "Cpf");
        }
    }
}
