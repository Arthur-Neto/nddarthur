using Arthur.ORM.Dominio.Features.Projetos;
using System.Data.Entity.ModelConfiguration;

namespace Arthur.ORM.Infra.Data.Features.Projetos
{
    public class ProjetoMap : EntityTypeConfiguration<Projeto>
    {
        public ProjetoMap()
        {
            ToTable("TBProjeto");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(50).IsRequired();
            Property(x => x.DataInicio).IsRequired();

            HasMany(x => x.Equipe).WithMany(x => x.Projetos).Map(m => { m.MapLeftKey("FuncionarioId"); m.MapRightKey("ProjetoId"); m.ToTable("TBFuncionario_Projeto"); });
        }
    }
}
