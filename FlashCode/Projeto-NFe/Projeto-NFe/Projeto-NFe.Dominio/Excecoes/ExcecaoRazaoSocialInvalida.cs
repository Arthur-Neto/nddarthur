using Projeto_NFe.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Excecoes
{
    public class ExcecaoRazaoSocialInvalida : ExcecaoDeNegocio
    {
        public ExcecaoRazaoSocialInvalida() : base("Razao Social não pode estar em branco!")
        {
        }
    }
}
