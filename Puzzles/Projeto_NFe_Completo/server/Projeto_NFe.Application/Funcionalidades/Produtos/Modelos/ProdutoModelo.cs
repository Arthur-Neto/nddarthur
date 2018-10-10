using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Produtos.Modelos
{
    public class ProdutoModelo
    {
        public long Id { get; set; }

        public string Codigo { get; set; }

        public double Valor { get; set; }

        public double AliquotaIPI { get; set; }

        public double AliquotaICMS { get; set; }

        public string Descricao { get; set; }
    }
}
