using Projeto_NFe.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.Emitentes.Excercoes
{
    public class ExcecaoInscricaoEstadualInvalido : ExcecaoDeNegocio
    {
        public ExcecaoInscricaoEstadualInvalido() : base("Inscrição estadual não foi informada")
        {
        }
    }
}
