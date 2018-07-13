using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzaria.Dominio.Base
{
    public abstract class Entidade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual long Id { get; set; }

        public abstract void Validar();
    }
}