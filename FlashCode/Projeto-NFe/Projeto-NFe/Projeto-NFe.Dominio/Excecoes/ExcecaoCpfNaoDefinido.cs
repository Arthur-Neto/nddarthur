using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Infra.Documentos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Excecoes
{
    public class ExcecaoCpfNaoDefinido : ExcecaoDocumento
    {
        public ExcecaoCpfNaoDefinido() : base("Não foi definido um cpf")
        {
        }
    }
}
