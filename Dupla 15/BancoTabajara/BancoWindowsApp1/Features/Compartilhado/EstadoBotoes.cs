using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoWindowsApp1.Features.Compartilhado
{
    public class EstadoBotoes
    {
        public bool Cadastrar { get; set; }
        public bool Sacar { get; set; }
        public bool Depositar { get; set; }
        public bool Transferir { get; set; }
        public bool Extrato { get; set; }
        public bool Excluir { get; set; }
    }
}
