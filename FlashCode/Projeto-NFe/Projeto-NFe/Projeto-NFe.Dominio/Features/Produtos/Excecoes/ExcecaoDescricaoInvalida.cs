using Projeto_NFe.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.Produtos.Excecoes
{
    public class ExcecaoDescricaoInvalida : ExcecaoDeNegocio
    {
        public ExcecaoDescricaoInvalida() : base("Deve ser informada uma descrição para o produto")
        {
        }
    }
}
