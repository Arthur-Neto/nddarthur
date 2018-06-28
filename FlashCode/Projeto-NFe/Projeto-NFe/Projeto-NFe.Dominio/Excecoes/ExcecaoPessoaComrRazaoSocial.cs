using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Infra.Documentos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Excecoes
{
    public class ExcecaoPessoaComRazaoSocial : ExcecaoDocumento
    {
        public ExcecaoPessoaComRazaoSocial() : base("uma pessoa não pode conter razão social")
        {
        }
    }
}
