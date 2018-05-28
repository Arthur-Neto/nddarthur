using Loterica.Dominio.Features.Boloes;
using Loterica.Dominio.Features.Concursos;

namespace Loterica.Common.Tests
{
    public static partial class ObjectMother
    {
       
        public static Bolao GetBolaoValido()
        {
            Concurso concurso = ObjectMother.GetValidConcursoAberto();
            Bolao bolao = new Bolao();
            bolao.Apostas.Add(ObjectMother.GetValidAposta(concurso));
            bolao.Apostas.Add(ObjectMother.GetValidAposta(concurso));
            bolao.Apostas.Add(ObjectMother.GetValidAposta(concurso));
            bolao.Apostas.Add(ObjectMother.GetValidAposta(concurso));
            return bolao;
        }

        public static Bolao GetBolaoValidoComApostasSenaQuinaeQuadra()
        {
            Concurso concurso = ObjectMother.GetValidConcursoAberto();
            Bolao bolao = new Bolao();
            bolao.Apostas.Add(ObjectMother.GetValidApostaQuadra(concurso));
            bolao.Apostas.Add(ObjectMother.GetValidApostaQuina(concurso));
            bolao.Apostas.Add(ObjectMother.GetValidApostaSena(concurso));
            return bolao;
        }


        public static Bolao GetBolaoVazio()
        {
            return new Bolao();
        }
    }
}
