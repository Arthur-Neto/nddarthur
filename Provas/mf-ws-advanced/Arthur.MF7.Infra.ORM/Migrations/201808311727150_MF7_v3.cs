namespace Arthur.MF7.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MF7_v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Spending", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Employee", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Employee", "LastName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Employee", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Employee", "LastName");
            DropColumn("dbo.Employee", "FirstName");
            DropColumn("dbo.Spending", "Price");
        }
    }
}
