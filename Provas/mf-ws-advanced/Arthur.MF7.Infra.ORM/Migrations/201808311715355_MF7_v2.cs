namespace Arthur.MF7.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MF7_v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Spending",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        Date = c.DateTime(nullable: false),
                        Type = c.String(nullable: false, maxLength: 50),
                        EmployeeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Position = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Spending", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "UserId", "dbo.User");
            DropIndex("dbo.Employee", new[] { "UserId" });
            DropIndex("dbo.Spending", new[] { "EmployeeId" });
            DropTable("dbo.Employee");
            DropTable("dbo.Spending");
        }
    }
}
