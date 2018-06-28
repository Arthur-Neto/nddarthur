using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Excecoes
{
    public class ExcecaoIdentificadorInvalido : ExcecaoDeNegocio
    {
        public ExcecaoIdentificadorInvalido() : base("O ID não pode ser negativo!")
        {
        }
    }
}
