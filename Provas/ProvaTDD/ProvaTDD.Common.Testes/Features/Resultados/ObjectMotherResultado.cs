using ProvaTDD.Dominio.Features.Resultados;

namespace ProvaTDD.Common.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Resultado ObterResultadoValido()
        {
            return new Resultado()
            {
                Nota = 5
            };
        }

        public static Resultado ObterResultadoValidoComAluno()
        {
            return new Resultado()
            {
                Nota = 5,
                Aluno = ObterAlunoValido()
            };
        }
        public static Resultado ObterResultadoValidoComAlunoNotaCincoMeio()
        {
            return new Resultado()
            {
                Nota = 5.5,
                Aluno = ObterAlunoValido()
            };
        }
        public static Resultado ObterResultadoValidoComAlunoNotaSeis()
        {
            return new Resultado()
            {
                Nota = 5.8,
                Aluno = ObterAlunoValido()
            };
        }

        public static Resultado ObterResultadoInvalido()
        {
            return new Resultado()
            {
                Nota = -1
            };
        }
    }
}
