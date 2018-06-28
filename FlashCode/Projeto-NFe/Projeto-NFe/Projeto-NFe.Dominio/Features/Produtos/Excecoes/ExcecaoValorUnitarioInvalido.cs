using Projeto_NFe.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.Produtos.Excecoes
{
    public class ExcecaoValorUnitarioInvalido : ExcecaoDeNegocio
    {
        public ExcecaoValorUnitarioInvalido() : base("O produto não possui um valor, deve ser definido")
        {
        }
    }
}
