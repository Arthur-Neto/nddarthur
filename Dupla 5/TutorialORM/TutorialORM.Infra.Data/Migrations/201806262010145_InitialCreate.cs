namespace TutorialORM.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBAluno",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        EnderecoId = c.Long(nullable: false),
                        TurmaId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBEndereco", t => t.EnderecoId)
                .ForeignKey("dbo.TBTurma", t => t.TurmaId)
                .Index(t => t.EnderecoId)
                .Index(t => t.TurmaId);
            
            CreateTable(
                "dbo.TBEndereco",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Logradouro = c.String(nullable: false, maxLength: 100, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 35, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 35, unicode: false),
                        UF = c.String(nullable: false, maxLength: 25, unicode: false),
                        Numero = c.Short(nullable: false),
                        Complemento = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBTurma",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBAluno", "TurmaId", "dbo.TBTurma");
            DropForeignKey("dbo.TBAluno", "EnderecoId", "dbo.TBEndereco");
            DropIndex("dbo.TBAluno", new[] { "TurmaId" });
            DropIndex("dbo.TBAluno", new[] { "EnderecoId" });
            DropTable("dbo.TBTurma");
            DropTable("dbo.TBEndereco");
            DropTable("dbo.TBAluno");
        }
    }
}
