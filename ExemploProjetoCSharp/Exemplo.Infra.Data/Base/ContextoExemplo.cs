using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Exemplo.Infra.Data.Base {
    public class ContextoExemplo : DbContext {
        public ContextoExemplo() : base("ContextoExemplo") {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties()
                   .Where(p => p.Name == p.ReflectedType.Name + "Id")
                   .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
                   .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                  .Configure(p => p.HasMaxLength(50));
        }
    }
}
