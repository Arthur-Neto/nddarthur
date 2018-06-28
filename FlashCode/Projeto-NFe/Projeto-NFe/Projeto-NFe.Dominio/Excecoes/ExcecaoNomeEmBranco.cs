using Projeto_NFe.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Excecoes
{
    public class ExcecaoNomeEmBranco : ExcecaoDeNegocio
    {
        public ExcecaoNomeEmBranco() : base("Nome não pode estar em branco!")
        {
        }
    }
}
