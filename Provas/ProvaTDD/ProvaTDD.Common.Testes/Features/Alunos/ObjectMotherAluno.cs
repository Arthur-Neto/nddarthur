using ProvaTDD.Dominio.Features.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Common.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Aluno ObterAlunoValido()
        {
            return new Aluno()
            {
                Nome = "Fulano",
                Idade = 20
            };
        }
    }
}
