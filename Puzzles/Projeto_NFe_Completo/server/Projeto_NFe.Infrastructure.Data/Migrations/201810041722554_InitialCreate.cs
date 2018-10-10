namespace Projeto_NFe.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBDESTINATARIO",
                c => new
                    {
                        IdDestinatario = c.Long(nullable: false, identity: true),
                        NomeRazaoSocial = c.String(nullable: false, maxLength: 100, unicode: false),
                        InscricaoEstadual = c.String(nullable: false, maxLength: 15, unicode: false),
                        Endereco_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.IdDestinatario)
                .ForeignKey("dbo.TBENDERECO", t => t.Endereco_Id, cascadeDelete: true)
                .Index(t => t.Endereco_Id);
            
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
                        CNPJ_NumeroComPontuacao = c.String(),
                        InscricaoEstadual = c.String(nullable: false, maxLength: 15, unicode: false),
                        InscricaoMunicipal = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Endereco_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.IdEmitente)
                .ForeignKey("dbo.TBENDERECO", t => t.Endereco_Id, cascadeDelete: true)
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
                "dbo.ProdutoNotaFiscal",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        NotaFiscal_Id = c.Long(),
                        Produto_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBNOTAFISCAL", t => t.NotaFiscal_Id)
                .ForeignKey("dbo.TBPRODUTO", t => t.Produto_Id)
                .Index(t => t.NotaFiscal_Id)
                .Index(t => t.Produto_Id);
            
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
                        TipoDocumento = c.String(nullable: false, maxLength: 4, unicode: false),
                        Endereco_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.IdTransportador)
                .ForeignKey("dbo.TBENDERECO", t => t.Endereco_Id, cascadeDelete: true)
                .Index(t => t.Endereco_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBNOTAFISCAL", "TransportadorId", "dbo.TBTRANSPORTADOR");
            DropForeignKey("dbo.TBTRANSPORTADOR", "Endereco_Id", "dbo.TBENDERECO");
            DropForeignKey("dbo.ProdutoNotaFiscal", "Produto_Id", "dbo.TBPRODUTO");
            DropForeignKey("dbo.ProdutoNotaFiscal", "NotaFiscal_Id", "dbo.TBNOTAFISCAL");
            DropForeignKey("dbo.TBNOTAFISCAL", "EmitenteId", "dbo.TBEMITENTE");
            DropForeignKey("dbo.TBNOTAFISCAL", "DestinatarioId", "dbo.TBDESTINATARIO");
            DropForeignKey("dbo.TBEMITENTE", "Endereco_Id", "dbo.TBENDERECO");
            DropForeignKey("dbo.TBDESTINATARIO", "Endereco_Id", "dbo.TBENDERECO");
            DropIndex("dbo.TBTRANSPORTADOR", new[] { "Endereco_Id" });
            DropIndex("dbo.ProdutoNotaFiscal", new[] { "Produto_Id" });
            DropIndex("dbo.ProdutoNotaFiscal", new[] { "NotaFiscal_Id" });
            DropIndex("dbo.TBNOTAFISCAL", new[] { "EmitenteId" });
            DropIndex("dbo.TBNOTAFISCAL", new[] { "DestinatarioId" });
            DropIndex("dbo.TBNOTAFISCAL", new[] { "TransportadorId" });
            DropIndex("dbo.TBEMITENTE", new[] { "Endereco_Id" });
            DropIndex("dbo.TBDESTINATARIO", new[] { "Endereco_Id" });
            DropTable("dbo.TBTRANSPORTADOR");
            DropTable("dbo.TBPRODUTO");
            DropTable("dbo.ProdutoNotaFiscal");
            DropTable("dbo.TBNOTAFISCAL");
            DropTable("dbo.TBEMITENTE");
            DropTable("dbo.TBENDERECO");
            DropTable("dbo.TBDESTINATARIO");
        }
    }
}
