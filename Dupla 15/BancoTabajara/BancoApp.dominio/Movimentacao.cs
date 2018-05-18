using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.dominio
{
    public class Movimentacao
    {

        public double Valor { get; set; }
        public String Tipo { get; set; }
        public String Operacao { get; set; }

        public override string ToString()
        {
            return String.Format("Valor: {0} - Tipo: {1} - Operacao: {2}", Valor, Tipo, Operacao);
        }
    }
}
