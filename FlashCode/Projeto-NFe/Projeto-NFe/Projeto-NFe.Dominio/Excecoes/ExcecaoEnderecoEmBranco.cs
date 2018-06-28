using Projeto_NFe.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Excecoes
{
    public class ExcecaoEnderecoEmBranco : ExcecaoDeNegocio
    {
        public ExcecaoEnderecoEmBranco() : base("Endereço não pode estar em branco!")
        {
        }
    }
}
