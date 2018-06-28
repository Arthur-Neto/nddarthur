using Projeto_NFe.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.Impostos.Exceptions
{
    public class ExcecaoProdutoNulo : ExcecaoDeNegocio
    {
        public ExcecaoProdutoNulo() : base("O produto passado para o cálculo de imposto não pode ser vazio")
        {
        }
    }
}
