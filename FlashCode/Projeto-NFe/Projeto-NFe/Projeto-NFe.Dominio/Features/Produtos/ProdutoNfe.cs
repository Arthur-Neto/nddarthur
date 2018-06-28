using Projeto_NFe.Dominio.Features.Impostos;
using Projeto_NFe.Dominio.Features.Produtos.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.Produtos
{
    public class ProdutoNfe : Produto
    {
        public long ProdutoID { get; set; }

        private Imposto _imposto;
        
        public Imposto Imposto
        {
            get
            {
                if (_imposto == null)
                    _imposto = new Imposto(this);
                return _imposto;
            }
            set
            {
                _imposto = value;
            }
        }

        public int Quantidade { get; set; }

        public double ValorTotal { get { return Quantidade * ValorUnitario; } set { } }

        public override void Validar()
        {
            if (Quantidade < 1)
                throw new ExcecaoQuantidadeInvalida();

            if (ValorTotal < 1)
                throw new ExcecaoValorTotalNegativo();
        }
    }
}
