using Projeto_NFe.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.Produtos.Excecoes
{
    public class ExcecaoQuantidadeInvalida : ExcecaoDeNegocio
    {
        public ExcecaoQuantidadeInvalida( ) : base("A quantidade do produto não pode ser menor que 1")
        {
        }
    }
}
