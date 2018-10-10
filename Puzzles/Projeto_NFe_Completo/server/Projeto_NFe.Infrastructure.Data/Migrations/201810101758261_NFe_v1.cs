namespace Projeto_NFe.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NFe_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBDESTINATARIO",
                c => new
                    {
                        IdDestinatario = c.Long(nullable: false, identity: true),
                        NomeRazaoSocial = c.String(nullable: false, maxLength: 100, unicode: false),
                        InscricaoEstadual = c.String(maxLength: 15, unicode: false),
                        EnderecoId = c.Long(nullable: false),
                        DocumentoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.IdDestinatario)
                .ForeignKey("dbo.TBDOCUMENTO", t => t.DocumentoId)
                .ForeignKey("dbo.TBENDERECO", t => t.EnderecoId)
                .Index(t => t.EnderecoId)
                .Index(t => t.DocumentoId);
            
            CreateTable(
                "dbo.TBDOCUMENTO",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Número = c.String(nullable: false, maxLength: 18, unicode: false),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBENDERECO",
                c => new
                    {
                        IdEndereco = c.Long(nullable: false, identity: true),
                        Logradouro = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Numero = c.Int(nullable: false),
                        Bairro = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Municipio = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Pais = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.IdEndereco);
            
            CreateTable(
                "dbo.TBEMITENTE",
                c => new
                    {
                        IdEmitente = c.Long(nullable: false, identity: true),
                        NomeFantasia = c.String(nullable: false, maxLength: 100, unicode: false),
                        RazaoSocial = c.String(nullable: false, maxLength: 100, unicode: false),
                        InscricaoEstadual = c.String(nullable: false, maxLength: 15, unicode: false),
                        InscricaoMunicipal = c.String(nullable: false, maxLength: 8000, unicode: false),
                        CNPJ_Id = c.Long(nullable: false),
                        Endereco_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.IdEmitente)
                .ForeignKey("dbo.TBDOCUMENTO", t => t.CNPJ_Id)
                .ForeignKey("dbo.TBENDERECO", t => t.Endereco_Id, cascadeDelete: true)
                .Index(t => t.CNPJ_Id)
                .Index(t => t.Endereco_Id);
            
            CreateTable(
                "dbo.TBNOTAFISCAL",
                c => new
                    {
                        IdNotaFiscal = c.Long(nullable: false, identity: true),
                        TransportadorId = c.Long(nullable: false),
                        DestinatarioId = c.Long(nullable: false),
                        EmitenteId = c.Long(nullable: false),
                        NaturezaOperacao = c.String(nullable: false, maxLength: 8000, unicode: false),
                        DataEntrada = c.DateTime(nullable: false),
                        DataEmissao = c.DateTime(),
                        ChaveAcesso = c.String(),
                        ValorTotalICMS = c.Double(nullable: false),
                        ValorTotalIPI = c.Double(nullable: false),
                        ValorTotalProdutos = c.Double(nullable: false),
                        ValorTotalFrete = c.Double(nullable: false),
                        ValorTotalImpostos = c.Double(nullable: false),
                        ValorTotalNota = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdNotaFiscal)
                .ForeignKey("dbo.TBDESTINATARIO", t => t.DestinatarioId)
                .ForeignKey("dbo.TBEMITENTE", t => t.EmitenteId)
                .ForeignKey("dbo.TBTRANSPORTADOR", t => t.TransportadorId)
                .Index(t => t.TransportadorId)
                .Index(t => t.DestinatarioId)
                .Index(t => t.EmitenteId);
            
            CreateTable(
                "dbo.TBPRODUTONOTAFISCAL",
                c => new
                    {
                        IdProdutoNotaFiscal = c.Long(nullable: false, identity: true),
                        ProdutoId = c.Long(nullable: false),
                        NotaFiscalId = c.Long(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProdutoNotaFiscal)
                .ForeignKey("dbo.TBNOTAFISCAL", t => t.NotaFiscalId, cascadeDelete: true)
                .ForeignKey("dbo.TBPRODUTO", t => t.ProdutoId)
                .Index(t => t.ProdutoId)
                .Index(t => t.NotaFiscalId);
            
            CreateTable(
                "dbo.TBPRODUTO",
                c => new
                    {
                        IdProduto = c.Long(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 100, unicode: false),
                        Valor = c.Double(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.IdProduto);
            
            CreateTable(
                "dbo.TBTRANSPORTADOR",
                c => new
                    {
                        IdTransportador = c.Long(nullable: false, identity: true),
                        NomeRazaoSocial = c.String(nullable: false, maxLength: 100, unicode: false),
                        InscricaoEstadual = c.String(nullable: false, maxLength: 15, unicode: false),
                        ResponsabilidadeFrete = c.Boolean(nullable: false),
                        Documento_Id = c.Long(nullable: false),
                        Endereco_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.IdTransportador)
                .ForeignKey("dbo.TBDOCUMENTO", t => t.Documento_Id)
                .ForeignKey("dbo.TBENDERECO", t => t.Endereco_Id)
                .Index(t => t.Documento_Id)
                .Index(t => t.Endereco_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBNOTAFISCAL", "TransportadorId", "dbo.TBTRANSPORTADOR");
            DropForeignKey("dbo.TBTRANSPORTADOR", "Endereco_Id", "dbo.TBENDERECO");
            DropForeignKey("dbo.TBTRANSPORTADOR", "Documento_Id", "dbo.TBDOCUMENTO");
            DropForeignKey("dbo.TBPRODUTONOTAFISCAL", "ProdutoId", "dbo.TBPRODUTO");
            DropForeignKey("dbo.TBPRODUTONOTAFISCAL", "NotaFiscalId", "dbo.TBNOTAFISCAL");
            DropForeignKey("dbo.TBNOTAFISCAL", "EmitenteId", "dbo.TBEMITENTE");
            DropForeignKey("dbo.TBNOTAFISCAL", "DestinatarioId", "dbo.TBDESTINATARIO");
            DropForeignKey("dbo.TBEMITENTE", "Endereco_Id", "dbo.TBENDERECO");
            DropForeignKey("dbo.TBEMITENTE", "CNPJ_Id", "dbo.TBDOCUMENTO");
            DropForeignKey("dbo.TBDESTINATARIO", "EnderecoId", "dbo.TBENDERECO");
            DropForeignKey("dbo.TBDESTINATARIO", "DocumentoId", "dbo.TBDOCUMENTO");
            DropIndex("dbo.TBTRANSPORTADOR", new[] { "Endereco_Id" });
            DropIndex("dbo.TBTRANSPORTADOR", new[] { "Documento_Id" });
            DropIndex("dbo.TBPRODUTONOTAFISCAL", new[] { "NotaFiscalId" });
            DropIndex("dbo.TBPRODUTONOTAFISCAL", new[] { "ProdutoId" });
            DropIndex("dbo.TBNOTAFISCAL", new[] { "EmitenteId" });
            DropIndex("dbo.TBNOTAFISCAL", new[] { "DestinatarioId" });
            DropIndex("dbo.TBNOTAFISCAL", new[] { "TransportadorId" });
            DropIndex("dbo.TBEMITENTE", new[] { "Endereco_Id" });
            DropIndex("dbo.TBEMITENTE", new[] { "CNPJ_Id" });
            DropIndex("dbo.TBDESTINATARIO", new[] { "DocumentoId" });
            DropIndex("dbo.TBDESTINATARIO", new[] { "EnderecoId" });
            DropTable("dbo.TBTRANSPORTADOR");
            DropTable("dbo.TBPRODUTO");
            DropTable("dbo.TBPRODUTONOTAFISCAL");
            DropTable("dbo.TBNOTAFISCAL");
            DropTable("dbo.TBEMITENTE");
            DropTable("dbo.TBENDERECO");
            DropTable("dbo.TBDOCUMENTO");
            DropTable("dbo.TBDESTINATARIO");
        }
    }
}
