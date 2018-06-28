using System;
using TutorialORM.Dominio.Features.Turmas;

namespace TutorialORM.Common.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Turma ObterTurmaValida()
        {
            return new Turma()
            {
                Descricao = "Academia do Programador"
            };
        }

        public static Turma ObterTurmaValidaSemReferencia()
        {
            return new Turma()
            {
                Descricao = "Academia do Programador"
            };
        }

        public static Turma ObterTurmaDescricaoVazia()
        {
            return new Turma()
            {
                Descricao = String.Empty
            };
        }

        public static Turma ObterTurmaDescricaoComEspaco()
        {
            return new Turma()
            {
                Descricao = " "
            };
        }
    }
}
