using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TutorialORM.Dominio.Features.Alunos;
using TutorialORM.Dominio.Features.Enderecos;
using TutorialORM.Dominio.Features.Turmas;
using TutorialORM.Infra.Data.Features.Alunos;
using TutorialORM.Infra.Data.Features.Enderecos;
using TutorialORM.Infra.Data.Features.Turmas;

namespace TutorialORM.Infra.Data.Base
{
    public class EscolaContext : DbContext
    {
        public EscolaContext() : base("name=TutorialORM")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlunoMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new TurmaMap());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
        }
    }
}
