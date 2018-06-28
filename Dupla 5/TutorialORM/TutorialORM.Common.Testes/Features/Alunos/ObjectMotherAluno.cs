using System;
using TutorialORM.Dominio.Features.Alunos;

namespace TutorialORM.Common.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Aluno ObterAlunoValido()
        {
            return new Aluno()
            {
                Nome = "Juca",
                Cpf = "12312312",
                DataNascimento = DateTime.Now,
                Turma = ObterTurmaValida(),
                Endereco = ObterEnderecoValido()
            };
        }

        public static Aluno ObterAlunoSemNome()
        {
            return new Aluno()
            {
                Nome = String.Empty,
            };
        }

        public static Aluno ObterAlunoDataNascimentoInvalida()
        {
            return new Aluno()
            {
                Nome = "Juca",
                DataNascimento = DateTime.Now.AddDays(1)
            };
        }

        public static Aluno ObterAlunoSemTurma()
        {
            return new Aluno()
            {
                Nome = "Juca",
                DataNascimento = DateTime.Now,
                Turma = null
            };
        }

        public static Aluno ObterAlunoSemEndereco()
        {
            return new Aluno()
            {
                Nome = "Juca",
                DataNascimento = DateTime.Now,
                Turma = ObterTurmaValida(),
                Endereco = null
            };
        }
    }
}
