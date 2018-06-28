using Projeto_NFe.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.Enderecos.Excecoes
{
    public class ExcecaoBairroInvalido : ExcecaoDeNegocio
    {
        public ExcecaoBairroInvalido() : base("O Bairro precisa ser informado")
        {
        }
    }
}
