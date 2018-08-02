using Arthur.ORM.Dominio.Base;
using Arthur.ORM.Dominio.Features.Cargos;
using Arthur.ORM.Dominio.Features.Departamentos;
using Arthur.ORM.Dominio.Features.Dependentes;
using Arthur.ORM.Dominio.Features.Projetos;
using System;
using System.Collections.Generic;

namespace Arthur.ORM.Dominio.Features.Funcionarios
{
    public class Funcionario : Entidade
    {
        public Funcionario()
        {
            Dependentes = new List<Dependente>();
            Projetos = new List<Projeto>();
        }

        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual ICollection<Dependente> Dependentes { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
