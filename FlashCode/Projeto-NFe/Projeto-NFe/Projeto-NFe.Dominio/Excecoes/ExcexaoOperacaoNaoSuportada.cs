using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Excecoes
{
    public class ExcexaoOperacaoNaoSuportada : ExcecaoDeNegocio
    {
        public ExcexaoOperacaoNaoSuportada() : base("Operação não suportada")
        {
        }
    }
}
