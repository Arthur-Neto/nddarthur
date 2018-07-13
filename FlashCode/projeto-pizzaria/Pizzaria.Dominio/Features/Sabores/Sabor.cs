using Pizzaria.Dominio.Base;
using System;

namespace Pizzaria.Dominio.Features.Sabores
{
    public class Sabor : Entidade
    {
        public string Nome { get; set; }
        public virtual double Preco { get; set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
