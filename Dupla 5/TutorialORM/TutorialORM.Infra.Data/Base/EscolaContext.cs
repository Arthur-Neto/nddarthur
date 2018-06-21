using System.Data.Entity;
using TutorialORM.Dominio.Features.Alunos;
using TutorialORM.Dominio.Features.Enderecos;
using TutorialORM.Dominio.Features.Turmas;

namespace TutorialORM.Infra.Data.Base
{
    public class EscolaContext : DbContext
    {
        public EscolaContext() : base("TutorialORM")
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().ToTable("TBAluno");
            modelBuilder.Entity<Endereco>().ToTable("TBEndereco");
            modelBuilder.Entity<Turma>().ToTable("TBTurma");
        }
    }
}
