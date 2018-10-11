namespace Projeto_NFe.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NFe_v2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TBTRANSPORTADOR", name: "Documento_Id", newName: "DocumentoId");
            RenameColumn(table: "dbo.TBTRANSPORTADOR", name: "Endereco_Id", newName: "EnderecoId");
            RenameIndex(table: "dbo.TBTRANSPORTADOR", name: "IX_Documento_Id", newName: "IX_DocumentoId");
            RenameIndex(table: "dbo.TBTRANSPORTADOR", name: "IX_Endereco_Id", newName: "IX_EnderecoId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TBTRANSPORTADOR", name: "IX_EnderecoId", newName: "IX_Endereco_Id");
            RenameIndex(table: "dbo.TBTRANSPORTADOR", name: "IX_DocumentoId", newName: "IX_Documento_Id");
            RenameColumn(table: "dbo.TBTRANSPORTADOR", name: "EnderecoId", newName: "Endereco_Id");
            RenameColumn(table: "dbo.TBTRANSPORTADOR", name: "DocumentoId", newName: "Documento_Id");
        }
    }
}
