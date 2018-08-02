using Arthur.ORM.Dominio.Features.Dependentes;
using System.Data.Entity.ModelConfiguration;

namespace Arthur.ORM.Infra.Data.Features.Dependentes
{
    public class DependenteMap : EntityTypeConfiguration<Dependente>
    {
        public DependenteMap()
        {
            ToTable("TBDependente");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(50).IsRequired();
            Property(x => x.Id).IsRequired();

            HasMany(x => x.Funcionarios).WithMany(x => x.Dependentes).Map(m => { m.MapLeftKey("FuncionarioId"); m.MapRightKey("DependenteId"); m.ToTable("TBFuncionario_Dependente"); });
        }
    }
}
