using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Documentos.Base
{
    public class ExcecaoDocumento : Exception
    {
        public ExcecaoDocumento() : base("Documento invalido")
        {

        }

        public ExcecaoDocumento(string mensagem) : base(mensagem)
        {
        }
    }
}
