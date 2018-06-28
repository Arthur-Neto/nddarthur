using Projeto_NFe.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.Enderecos.Excecoes
{
    public class ExcecaoNumeroInvalido : ExcecaoDeNegocio
    {
        public ExcecaoNumeroInvalido() : base("O número precisa ser informado")
        {
        }
    }
}
