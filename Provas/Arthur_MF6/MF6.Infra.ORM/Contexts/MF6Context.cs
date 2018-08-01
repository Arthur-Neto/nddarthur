using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics.CodeAnalysis;

namespace MF6.Infra.ORM.Contexts {

    [ExcludeFromCodeCoverage]
    public class MF6Context : DbContext {

        public MF6Context() : base("MF6_Arthur") {
        }

        public MF6Context(string connectionStringName) : base(string.Format("name={0}", connectionStringName)) {
            Database.Initialize(true);
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = true;
        }

        protected MF6Context(DbConnection connection) : base(connection, true) {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}