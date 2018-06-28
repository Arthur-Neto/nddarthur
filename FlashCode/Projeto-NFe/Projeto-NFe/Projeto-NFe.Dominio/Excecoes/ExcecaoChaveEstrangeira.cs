using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Excecoes
{
    public class ExcecaoChaveEstrangeira : ExcecaoDeNegocio
    {
        public ExcecaoChaveEstrangeira() : base("Este item não pode ser deletado, pois possui chave estrangeira em outra tabela")
        {
        }
    }
}
