using Arthur.ORM.Dominio.Features.Cargos;
using Arthur.ORM.Dominio.Features.Departamentos;
using Arthur.ORM.Dominio.Features.Dependentes;
using Arthur.ORM.Dominio.Features.Funcionarios;
using Arthur.ORM.Dominio.Features.Projetos;
using Arthur.ORM.Infra.Data.Features.Cargos;
using Arthur.ORM.Infra.Data.Features.Departamentos;
using Arthur.ORM.Infra.Data.Features.Dependentes;
using Arthur.ORM.Infra.Data.Features.Funcionarios;
using Arthur.ORM.Infra.Data.Features.Projetos;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Arthur.ORM.Infra.Data.Base
{
    public class EmpresaContexto : DbContext
    {
        public EmpresaContexto() : base("MF_ORM_Arthur")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }
        public DbSet<Projeto> Projetos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties()
                   .Where(p => p.Name == p.ReflectedType.Name + "Id")
                   .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
                   .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                  .Configure(p => p.HasMaxLength(50));

            modelBuilder.Configurations.Add(new FuncionarioMap());
            modelBuilder.Configurations.Add(new CargoMap());
            modelBuilder.Configurations.Add(new DepartamentoMap());
            modelBuilder.Configurations.Add(new DependenteMap());
            modelBuilder.Configurations.Add(new ProjetoMap());
        }
    }
}
