using Projeto_NFe.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.Enderecos.Excecoes
{
    public class ExcecaoCidadeInvalida : ExcecaoDeNegocio
    {
        public ExcecaoCidadeInvalida() : base("A cidade precisa ser informada")
        {
        }
    }
}
