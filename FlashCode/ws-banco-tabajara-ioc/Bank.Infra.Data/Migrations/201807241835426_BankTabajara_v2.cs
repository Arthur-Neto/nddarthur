namespace Bank.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BankTabajara_v2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TBAccount_Transaction", newName: "Account_Transaction");
            AlterColumn("dbo.Client", "Cpf", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Client", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Client", "Rg", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Client", "Rg", c => c.String());
            AlterColumn("dbo.Client", "Name", c => c.String());
            AlterColumn("dbo.Client", "Cpf", c => c.String());
            RenameTable(name: "dbo.Account_Transaction", newName: "TBAccount_Transaction");
        }
    }
}
