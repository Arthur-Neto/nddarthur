namespace Bank.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public partial class BankTabajara_v5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Username", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.User", "Name");
            DropColumn("dbo.User", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Email", c => c.String());
            AddColumn("dbo.User", "Name", c => c.String());
            AlterColumn("dbo.User", "Password", c => c.String());
            DropColumn("dbo.User", "Username");
        }
    }
}
