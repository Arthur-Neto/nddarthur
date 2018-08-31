namespace Arthur.MF7.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MF7_v4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "UserId", "dbo.User");
            DropForeignKey("dbo.Spending", "EmployeeId", "dbo.Employee");
            AddForeignKey("dbo.Employee", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Spending", "EmployeeId", "dbo.Employee", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Spending", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "UserId", "dbo.User");
            AddForeignKey("dbo.Spending", "EmployeeId", "dbo.Employee", "Id");
            AddForeignKey("dbo.Employee", "UserId", "dbo.User", "Id");
        }
    }
}
