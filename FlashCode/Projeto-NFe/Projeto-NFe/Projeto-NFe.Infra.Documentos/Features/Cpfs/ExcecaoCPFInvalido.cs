using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Infra.Documentos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Documentos.Features.Cpfs
{
    public class ExcecaoCPFInvalido : ExcecaoDocumento
    {
        public ExcecaoCPFInvalido() : base("O CPF informado é inválido")
        {
        }
    }
}
