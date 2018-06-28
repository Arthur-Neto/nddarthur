using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Base
{
    public abstract class Entidade
    {
        public int ID { get; set; }

        public abstract void Validar();
      
    }
}
