using Projeto_NFe.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.Emitentes.Excercoes
{
    public class ExcecaoInscricaoMunicipalInvalido : ExcecaoDeNegocio
    {
        public ExcecaoInscricaoMunicipalInvalido() : base("Não foi informado inscrição municipal")
        {
        }
    }
}
