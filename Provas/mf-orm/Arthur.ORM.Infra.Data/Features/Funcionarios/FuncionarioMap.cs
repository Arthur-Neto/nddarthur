using Arthur.ORM.Dominio.Features.Funcionarios;
using System.Data.Entity.ModelConfiguration;

namespace Arthur.ORM.Infra.Data.Features.Funcionarios
{
    public class FuncionarioMap : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMap()
        {
            ToTable("TBFuncionario");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(100).IsRequired();
            Property(x => x.Endereco).HasMaxLength(200).IsRequired();
            Property(x => x.CPF).HasMaxLength(20).IsRequired();

            HasRequired(x => x.Cargo).WithMany().Map(m => m.MapKey("CargoId"));
            HasRequired(x => x.Departamento).WithMany().Map(m => m.MapKey("DepartamentoId"));
        }
    }
}
