namespace Bank.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public partial class BankTabajarav4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Transactions_Accounts", name: "TransactionId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Transactions_Accounts", name: "AccountId", newName: "TransactionId");
            RenameColumn(table: "dbo.Transactions_Accounts", name: "__mig_tmp__0", newName: "AccountId");
            RenameIndex(table: "dbo.Transactions_Accounts", name: "IX_TransactionId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Transactions_Accounts", name: "IX_AccountId", newName: "IX_TransactionId");
            RenameIndex(table: "dbo.Transactions_Accounts", name: "__mig_tmp__0", newName: "IX_AccountId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Transactions_Accounts", name: "IX_AccountId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Transactions_Accounts", name: "IX_TransactionId", newName: "IX_AccountId");
            RenameIndex(table: "dbo.Transactions_Accounts", name: "__mig_tmp__0", newName: "IX_TransactionId");
            RenameColumn(table: "dbo.Transactions_Accounts", name: "AccountId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Transactions_Accounts", name: "TransactionId", newName: "AccountId");
            RenameColumn(table: "dbo.Transactions_Accounts", name: "__mig_tmp__0", newName: "TransactionId");
        }
    }
}
