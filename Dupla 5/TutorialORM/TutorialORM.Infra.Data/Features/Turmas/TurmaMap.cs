using System.Data.Entity.ModelConfiguration;
using TutorialORM.Dominio.Features.Turmas;

namespace TutorialORM.Infra.Data.Features.Turmas
{
    public class TurmaMap : EntityTypeConfiguration<Turma>
    {
        public TurmaMap()
        {
            ToTable("TBTurma");

            HasKey(x => x.Id);

            Property(x => x.Descricao).HasMaxLength(150).IsRequired();
        }
    }
}
