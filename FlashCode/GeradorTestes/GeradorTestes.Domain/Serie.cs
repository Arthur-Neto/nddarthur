using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Domain
{
    public class Serie : Entidade
    {
        public string Nome { get; set; }

        public override string ToString()
        {
            return String.Format(Nome);
        }

        public void Validacao()
        {
            if (Nome.Equals("  ªSérie") || Nome.Equals("0 ªSérie"))
            {
                throw new Exception("Digite um número valido para a série");
            }
        }
    }
}
