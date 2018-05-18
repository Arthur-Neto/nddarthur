using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.dominio
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return String.Format("Nome: {0} - Email: {1} - Endereço: {2}", Nome, Email, Endereco);
        }
    }
}
