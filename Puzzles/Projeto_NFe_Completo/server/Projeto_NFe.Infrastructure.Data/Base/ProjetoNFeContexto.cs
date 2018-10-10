using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Destinatarios;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Emitentes;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Produtos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Transportadoras;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Projeto_NFe.Infrastructure.Data.Base
{
    public class ProjetoNFeContexto : DbContext
    {
        public DbSet<Destinatario> Destinatarios { get; set; }
        public DbSet<Emitente> Emitentes { get; set; }
        public DbSet<Transportador> Transportadoras { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<ProdutoNotaFiscal> ProdutosNotaFiscal { get; set; }

        public ProjetoNFeContexto() : base("PuzzlesNFeDb")
        {
        }

        /// <summary>
        /// Test Only.
        /// 
        /// Esse construtor deve ser chamado pela classe de teste que herdará desse contexto.
        /// Para classes externas esse construtor não está acessível (protected).
        /// 
        /// </summary>
        /// <param name="connection"></param>
        protected ProjetoNFeContexto(DbConnection connection) : base(connection, true) { }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new DestinatarioConfiguracao());
            modelBuilder.Configurations.Add(new EmitenteConfiguracao());
            modelBuilder.Configurations.Add(new TransportadorConfiguracao());
            modelBuilder.Configurations.Add(new NotaFiscalConfiguracao());
            modelBuilder.Configurations.Add(new ProdutoConfiguracao());
            modelBuilder.Configurations.Add(new EnderecoConfiguracao());

            base.OnModelCreating(modelBuilder);
        }
    }
}
