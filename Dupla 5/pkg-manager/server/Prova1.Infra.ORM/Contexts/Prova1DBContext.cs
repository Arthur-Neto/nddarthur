using Prova1.Domain.Orders;
using Prova1.Domain.Products;
using System.Data.Common;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;

namespace Prova1.Infra.ORM.Contexts
{
    /// <summary>
    /// Contexto de banco de dados do Prova1
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Prova1DbContext : DbContext
    {
        public Prova1DbContext(string connection = "Name=Prova1DBContext") : base(connection)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        /// <summary>
        /// Test Only.
        /// 
        /// Esse construtor deve ser chamado pela classe de teste que herdará desse contexto.
        /// Para classes externas esse construtor não está acessível (protected).
        /// 
        /// </summary>
        /// <param name="connection"></param>
        protected Prova1DbContext(DbConnection connection) : base(connection, true) { }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Método que é executado quando o modelo de banco de dados está sendo criado pelo EF.
        /// Útil para realizar configurações
        /// </summary>
        /// <param name="modelBuilder">É o construtor de modelos do EF</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Busca todos as configurações criadas nesse assembly, que são as classes que são derivadas de EntityTypeConfiguration
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            // Chama o OnModelCreating do EF para dar continuidade na criação do modelo
            base.OnModelCreating(modelBuilder);
        }
    }
}
