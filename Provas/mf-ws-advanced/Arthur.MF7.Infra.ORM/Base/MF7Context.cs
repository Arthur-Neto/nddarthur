using Arthur.MF7.Domain.Features.Users;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics.CodeAnalysis;
namespace Arthur.MF7.Infra.ORM.Base
{
    [ExcludeFromCodeCoverage]
    public class MF7Context : DbContext
    {
        public MF7Context(string connection = "Name=MF_WSA_Arthur") : base(connection)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;
        }

        protected MF7Context(DbConnection connection) : base(connection, true) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
