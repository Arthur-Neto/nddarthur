using Projeto_NFe.Dominio.Base;
using Projeto_NFe.Dominio.Features.Impostos;
using Projeto_NFe.Dominio.Features.Produtos.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.Produtos
{
    public class Produto : Entidade
    {

        public string CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public double ValorUnitario { get; set; }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(CodigoProduto.Trim()))
                throw new ExcecaoCodigoProdutoInvalido();
            if (string.IsNullOrEmpty(Descricao.Trim()))
                throw new ExcecaoDescricaoInvalida();
            if (ValorUnitario < 1)
                throw new ExcecaoValorUnitarioInvalido();
        }
    }
}
