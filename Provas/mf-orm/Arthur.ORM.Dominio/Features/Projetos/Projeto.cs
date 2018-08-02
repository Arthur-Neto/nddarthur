using Arthur.ORM.Dominio.Base;
using Arthur.ORM.Dominio.Features.Funcionarios;
using System;
using System.Collections.Generic;

namespace Arthur.ORM.Dominio.Features.Projetos
{
    public class Projeto : Entidade
    {
        public Projeto()
        {
            Equipe = new List<Funcionario>();
        }

        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public virtual ICollection<Funcionario> Equipe { get; set; }
    }
}
