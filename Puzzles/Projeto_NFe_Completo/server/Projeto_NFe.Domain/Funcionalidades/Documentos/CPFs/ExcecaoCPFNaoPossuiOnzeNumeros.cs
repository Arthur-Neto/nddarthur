using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Documentos.CPFs
{
    public class ExcecaoCPFNaoPossuiOnzeNumeros : Exception
    {
        public ExcecaoCPFNaoPossuiOnzeNumeros() : base("Um CPF deve possuir 11 numeros.")
        {
        }
    }
}
