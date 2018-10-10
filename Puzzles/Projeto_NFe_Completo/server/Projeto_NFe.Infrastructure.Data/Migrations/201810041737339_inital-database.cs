namespace Projeto_NFe.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initaldatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProdutoNotaFiscal", "NotaFiscal_Id", "dbo.TBNOTAFISCAL");
            DropForeignKey("dbo.ProdutoNotaFiscal", "Produto_Id", "dbo.TBPRODUTO");
            DropIndex("dbo.ProdutoNotaFiscal", new[] { "NotaFiscal_Id" });
            DropIndex("dbo.ProdutoNotaFiscal", new[] { "Produto_Id" });
            RenameColumn(table: "dbo.ProdutoNotaFiscal", name: "NotaFiscal_Id", newName: "NotaFiscalId");
            RenameColumn(table: "dbo.ProdutoNotaFiscal", name: "Produto_Id", newName: "ProdutoId");
            AlterColumn("dbo.ProdutoNotaFiscal", "NotaFiscalId", c => c.Long(nullable: false));
            AlterColumn("dbo.ProdutoNotaFiscal", "ProdutoId", c => c.Long(nullable: false));
            CreateIndex("dbo.ProdutoNotaFiscal", "ProdutoId");
            CreateIndex("dbo.ProdutoNotaFiscal", "NotaFiscalId");
            AddForeignKey("dbo.ProdutoNotaFiscal", "NotaFiscalId", "dbo.TBNOTAFISCAL", "IdNotaFiscal", cascadeDelete: true);
            AddForeignKey("dbo.ProdutoNotaFiscal", "ProdutoId", "dbo.TBPRODUTO", "IdProduto", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoNotaFiscal", "ProdutoId", "dbo.TBPRODUTO");
            DropForeignKey("dbo.ProdutoNotaFiscal", "NotaFiscalId", "dbo.TBNOTAFISCAL");
            DropIndex("dbo.ProdutoNotaFiscal", new[] { "NotaFiscalId" });
            DropIndex("dbo.ProdutoNotaFiscal", new[] { "ProdutoId" });
            AlterColumn("dbo.ProdutoNotaFiscal", "ProdutoId", c => c.Long());
            AlterColumn("dbo.ProdutoNotaFiscal", "NotaFiscalId", c => c.Long());
            RenameColumn(table: "dbo.ProdutoNotaFiscal", name: "ProdutoId", newName: "Produto_Id");
            RenameColumn(table: "dbo.ProdutoNotaFiscal", name: "NotaFiscalId", newName: "NotaFiscal_Id");
            CreateIndex("dbo.ProdutoNotaFiscal", "Produto_Id");
            CreateIndex("dbo.ProdutoNotaFiscal", "NotaFiscal_Id");
            AddForeignKey("dbo.ProdutoNotaFiscal", "Produto_Id", "dbo.TBPRODUTO", "IdProduto");
            AddForeignKey("dbo.ProdutoNotaFiscal", "NotaFiscal_Id", "dbo.TBNOTAFISCAL", "IdNotaFiscal");
        }
    }
}
