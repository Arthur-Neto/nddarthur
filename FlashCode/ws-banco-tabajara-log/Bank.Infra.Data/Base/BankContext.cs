using Bank.Domain.Features.Accounts;
using Bank.Domain.Features.Clients;
using Bank.Domain.Features.Transactions;
using Bank.Domain.Features.Users;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Infra.Data.Base
{
    [ExcludeFromCodeCoverage]
    public class BankContext : DbContext
    {
        public BankContext(string connection = "Name=FlashCode_BancoTabajara") : base(connection)
        {
            //Necessário desabilitar e adicionar os Includes nas classes pois com o Proxy habilitado
            //ocorre erro no get type xml
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;
        }

        protected BankContext(DbConnection connection) : base(connection, true) { }

        public DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
