using Arthur.ORM.Dominio.Features.Cargos;
using System.Data.Entity.ModelConfiguration;

namespace Arthur.ORM.Infra.Data.Features.Cargos
{
    public class CargoMap : EntityTypeConfiguration<Cargo>
    {
        public CargoMap()
        {
            ToTable("TBCargo");

            HasKey(x => x.Id);

            Property(x => x.Descricao).HasMaxLength(50).IsRequired();
        }
    }
}
