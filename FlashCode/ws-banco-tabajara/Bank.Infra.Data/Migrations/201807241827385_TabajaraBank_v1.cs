namespace Bank.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabajaraBank_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckingAccount",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        Limit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClientId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Cpf = c.String(),
                        Name = c.String(),
                        Rg = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBAccount_Transaction",
                c => new
                    {
                        TransactionId = c.Long(nullable: false),
                        AccountId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.TransactionId, t.AccountId })
                .ForeignKey("dbo.CheckingAccount", t => t.TransactionId, cascadeDelete: true)
                .ForeignKey("dbo.Transaction", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.TransactionId)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBAccount_Transaction", "AccountId", "dbo.Transaction");
            DropForeignKey("dbo.TBAccount_Transaction", "TransactionId", "dbo.CheckingAccount");
            DropForeignKey("dbo.CheckingAccount", "ClientId", "dbo.Client");
            DropIndex("dbo.TBAccount_Transaction", new[] { "AccountId" });
            DropIndex("dbo.TBAccount_Transaction", new[] { "TransactionId" });
            DropIndex("dbo.CheckingAccount", new[] { "ClientId" });
            DropTable("dbo.TBAccount_Transaction");
            DropTable("dbo.Transaction");
            DropTable("dbo.Client");
            DropTable("dbo.CheckingAccount");
        }
    }
}
