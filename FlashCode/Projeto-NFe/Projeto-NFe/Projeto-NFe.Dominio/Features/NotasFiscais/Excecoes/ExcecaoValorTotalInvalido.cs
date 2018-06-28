using Projeto_NFe.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.NotasFiscais.Excecoes
{
    public class ExcecaoValorTotalInvalido : ExcecaoDeNegocio
    {
        public ExcecaoValorTotalInvalido() : base("O valor total da nota não pode ser menor que R$ 1,00")
        {
        }
    }
}
