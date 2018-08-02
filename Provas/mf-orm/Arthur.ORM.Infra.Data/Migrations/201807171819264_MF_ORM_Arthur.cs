namespace Arthur.ORM.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MF_ORM_Arthur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBCargo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBDepartamento",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBDependente",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Idade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBFuncionario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Endereco = c.String(nullable: false, maxLength: 200, unicode: false),
                        TBFuncionario = c.Long(nullable: false),
                        TBDepartamento = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBCargo", t => t.TBFuncionario, cascadeDelete: true)
                .ForeignKey("dbo.TBDepartamento", t => t.TBDepartamento, cascadeDelete: true)
                .Index(t => t.TBFuncionario)
                .Index(t => t.TBDepartamento);
            
            CreateTable(
                "dbo.TBProjeto",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        DataInicio = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBFuncionario_Projeto",
                c => new
                    {
                        FuncionarioId = c.Long(nullable: false),
                        ProjetoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.FuncionarioId, t.ProjetoId })
                .ForeignKey("dbo.TBProjeto", t => t.FuncionarioId, cascadeDelete: true)
                .ForeignKey("dbo.TBFuncionario", t => t.ProjetoId, cascadeDelete: true)
                .Index(t => t.FuncionarioId)
                .Index(t => t.ProjetoId);
            
            CreateTable(
                "dbo.TBFuncionario_Dependente",
                c => new
                    {
                        FuncionarioId = c.Long(nullable: false),
                        DependenteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.FuncionarioId, t.DependenteId })
                .ForeignKey("dbo.TBDependente", t => t.FuncionarioId, cascadeDelete: true)
                .ForeignKey("dbo.TBFuncionario", t => t.DependenteId, cascadeDelete: true)
                .Index(t => t.FuncionarioId)
                .Index(t => t.DependenteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBFuncionario_Dependente", "DependenteId", "dbo.TBFuncionario");
            DropForeignKey("dbo.TBFuncionario_Dependente", "FuncionarioId", "dbo.TBDependente");
            DropForeignKey("dbo.TBFuncionario_Projeto", "ProjetoId", "dbo.TBFuncionario");
            DropForeignKey("dbo.TBFuncionario_Projeto", "FuncionarioId", "dbo.TBProjeto");
            DropForeignKey("dbo.TBFuncionario", "TBDepartamento", "dbo.TBDepartamento");
            DropForeignKey("dbo.TBFuncionario", "TBFuncionario", "dbo.TBCargo");
            DropIndex("dbo.TBFuncionario_Dependente", new[] { "DependenteId" });
            DropIndex("dbo.TBFuncionario_Dependente", new[] { "FuncionarioId" });
            DropIndex("dbo.TBFuncionario_Projeto", new[] { "ProjetoId" });
            DropIndex("dbo.TBFuncionario_Projeto", new[] { "FuncionarioId" });
            DropIndex("dbo.TBFuncionario", new[] { "TBDepartamento" });
            DropIndex("dbo.TBFuncionario", new[] { "TBFuncionario" });
            DropTable("dbo.TBFuncionario_Dependente");
            DropTable("dbo.TBFuncionario_Projeto");
            DropTable("dbo.TBProjeto");
            DropTable("dbo.TBFuncionario");
            DropTable("dbo.TBDependente");
            DropTable("dbo.TBDepartamento");
            DropTable("dbo.TBCargo");
        }
    }
}
