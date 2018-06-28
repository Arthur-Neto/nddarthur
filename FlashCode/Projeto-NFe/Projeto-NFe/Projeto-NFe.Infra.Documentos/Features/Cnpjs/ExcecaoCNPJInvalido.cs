using Projeto_NFe.Infra.Documentos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Excecoes
{
    public class ExcecaoCNPJInvalido : ExcecaoDocumento
    {
        public ExcecaoCNPJInvalido() : base("O CNPJ informado é inválido")
        {
        }
    }
}
