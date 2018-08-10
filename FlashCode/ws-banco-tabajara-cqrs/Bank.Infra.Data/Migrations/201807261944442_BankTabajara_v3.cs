namespace Bank.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BankTabajara_v3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Account_Transaction", newName: "Transactions_Accounts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Transactions_Accounts", newName: "Account_Transaction");
        }
    }
}
