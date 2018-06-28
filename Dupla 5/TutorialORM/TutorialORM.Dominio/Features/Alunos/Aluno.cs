using System;
using System.ComponentModel.DataAnnotations.Schema;
using TutorialORM.Dominio.Base;
using TutorialORM.Dominio.Features.Enderecos;
using TutorialORM.Dominio.Features.Turmas;

namespace TutorialORM.Dominio.Features.Alunos
{
    public class Aluno : Entidade
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual Turma Turma { get; set; }
        public virtual Endereco Endereco { get; set; }

        public override void Validar()
        {
            if (String.IsNullOrWhiteSpace(Nome))
                throw new AlunoNomeVazioException();

            if (DataNascimento > DateTime.Now)
                throw new AlunoDataNascimentoInvalidaException();

            if (Turma == null)
                throw new AlunoTurmaNuloException();

            if (Endereco == null)
                throw new AlunoEnderecoNuloException();
        }
    }
}
