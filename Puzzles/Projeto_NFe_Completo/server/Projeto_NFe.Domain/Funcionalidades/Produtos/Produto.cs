using Projeto_NFe.Domain.Base;
using Projeto_NFe.Domain.Funcionalidades.Produtos.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Produtos
{
    public class Produto : Entidade
    {
        private double _aliquotaICMS = 0.04;
        private double _aliquotaIPI = 0.10;

        public string Codigo { get; set; }

        public virtual double Valor { get; set; }

        public virtual double AliquotaIPI { get { return _aliquotaIPI; } }

        public virtual double AliquotaICMS { get { return _aliquotaICMS; } }

        public string Descricao { get; set; }
    }
}
