using Arthur.ORM.Dominio.Base;
using Arthur.ORM.Dominio.Features.Funcionarios;
using System;
using System.Collections.Generic;

namespace Arthur.ORM.Dominio.Features.Dependentes
{
    public class Dependente : Entidade
    {
        public Dependente()
        {
            Funcionarios = new List<Funcionario>();
        }

        public string Nome { get; set; }
        public int Idade { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
