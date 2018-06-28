using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Infra.Documentos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Excecoes
{
    public class ExcecaoPessoaComCnpj : ExcecaoDocumento
    {
        public ExcecaoPessoaComCnpj() : base("Uma pessoa não pode conter cnpj")
        {
        }
    }
}
