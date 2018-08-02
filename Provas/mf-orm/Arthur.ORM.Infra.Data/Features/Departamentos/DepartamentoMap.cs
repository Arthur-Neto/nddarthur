using Arthur.ORM.Dominio.Features.Departamentos;
using System.Data.Entity.ModelConfiguration;

namespace Arthur.ORM.Infra.Data.Features.Departamentos
{
    public class DepartamentoMap : EntityTypeConfiguration<Departamento>
    {
        public DepartamentoMap()
        {
            ToTable("TBDepartamento");

            HasKey(x => x.Id);

            Property(x => x.Descricao).HasMaxLength(50).IsRequired();
        }
    }
}
