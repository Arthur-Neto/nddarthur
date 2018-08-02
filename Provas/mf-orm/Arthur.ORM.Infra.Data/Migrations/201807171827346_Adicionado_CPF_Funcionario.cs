namespace Arthur.ORM.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionado_CPF_Funcionario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBFuncionario", "CPF", c => c.String(nullable: false, maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBFuncionario", "CPF");
        }
    }
}
