using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Documentos.CNPJs
{
    public class ExcecaoCNPJNaoPossuiQuatorzeNumeros : Exception
    {
        public ExcecaoCNPJNaoPossuiQuatorzeNumeros() : base ("Um CNPJ deve possuir 14 numeros.")
        {
        }
    }
}
