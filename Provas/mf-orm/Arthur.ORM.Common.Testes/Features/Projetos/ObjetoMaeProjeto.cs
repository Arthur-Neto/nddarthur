using Arthur.ORM.Dominio.Features.Projetos;
using System;

namespace Arthur.ORM.Common.Testes.Features
{
    public static partial class ObjetoMae
    {
        public static Projeto ObterProjetoSemEquipe()
        {
            return new Projeto() { DataInicio = DateTime.Now, Nome = "Projeto X" };
        }

        public static Projeto ObterProjetoComUmFuncionario()
        {
            var projeto = new Projeto() { DataInicio = DateTime.Now, Nome = "Projeto com 1 funcionario" };
            projeto.Equipe.Add(ObterFuncionarioComCargoEDepartamento());
            return projeto;
        }
    }
}
