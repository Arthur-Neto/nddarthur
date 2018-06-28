using Projeto_NFe.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.NotasFiscais.Excecoes
{
    public class ExcecaoDataEntradaInvalida : ExcecaoDeNegocio
    {
        public ExcecaoDataEntradaInvalida() : base("A data de entrada da nota fiscal é inválida")
        {
        }
    }
}
