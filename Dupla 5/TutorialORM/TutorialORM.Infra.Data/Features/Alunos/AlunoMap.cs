using System.Data.Entity.ModelConfiguration;
using TutorialORM.Dominio.Features.Alunos;

namespace TutorialORM.Infra.Data.Features.Alunos
{
    public class AlunoMap : EntityTypeConfiguration<Aluno>
    {
        public AlunoMap()
        {
            ToTable("TBAluno");

            HasKey(x => x.Id);

            Property(x => x.DataNascimento).IsRequired();
            Property(x => x.Nome).HasMaxLength(100).IsRequired();
            Property(x => x.Cpf).HasMaxLength(20).IsRequired();

            HasRequired(x => x.Endereco).WithMany().Map(m => m.MapKey("EnderecoId"));
            HasOptional(x => x.Turma).WithMany().Map(m => m.MapKey("TurmaId"));
        }
    }
}
