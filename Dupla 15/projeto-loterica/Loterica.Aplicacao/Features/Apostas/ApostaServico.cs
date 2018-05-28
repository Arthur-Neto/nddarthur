using Loterica.Aplicacao.Base;
using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Concursos;
using Loterica.Dominio.Features.Resultados;
using System.Collections.Generic;

namespace Loterica.Aplicacao.Features.Apostas
{
    public class ApostaServico : Servico<Aposta>
    {
        public ApostaServico(IRepository<Aposta> repositorio) : base(repositorio)
        {
        }

        public override Aposta Adicionar(Aposta entidade)
        {
            return base.Adicionar(entidade);
        }

        public override Aposta Atualizar(Aposta entidade)
        {
            return base.Atualizar(entidade);
        }

        public override IEnumerable<Aposta> BuscarTodos()
        {
            return base.BuscarTodos();
        }

        public override Aposta ConsultarPorId(long id)
        {
            return base.ConsultarPorId(id);
        }

        public override void Excluir(Aposta entidade)
        {
            base.Excluir(entidade);
        }

        public EstadoAposta IsGanhadora(Aposta aposta, IRepository<Concurso> repositoryConcurso, IRepository<Resultado> repositoryResultado)
        {
            Concurso concurso = repositoryConcurso.ObterPorId(aposta.Concurso.Id);
            concurso.Resultado = repositoryResultado.ObterPorId(concurso.Resultado.Id);
            aposta.Concurso = concurso;

            return aposta.IsGanhadora();
        }
    }
}
