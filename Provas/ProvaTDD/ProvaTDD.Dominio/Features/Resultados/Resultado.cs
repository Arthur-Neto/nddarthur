using ProvaTDD.Dominio.Base;
using ProvaTDD.Dominio.Features.Alunos;

namespace ProvaTDD.Dominio.Features.Resultados
{
    public class Resultado : Entidade
    {
        public double Nota { get; set; }
        public Aluno Aluno { get; set; }

        public override void Validar()
        {
            if (Nota < 0)
                throw new ResultadoNotaInvalidaException();
            if (Aluno == null)
                throw new ResultadoAlunoNuloException();
        }
    }
}
