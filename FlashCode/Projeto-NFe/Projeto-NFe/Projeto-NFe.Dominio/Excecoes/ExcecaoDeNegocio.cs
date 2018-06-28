using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Excecoes
{
    public class ExcecaoDeNegocio : Exception
    {
        public ExcecaoDeNegocio(string mensagem) : base (mensagem)
        {
        }
    }
}
